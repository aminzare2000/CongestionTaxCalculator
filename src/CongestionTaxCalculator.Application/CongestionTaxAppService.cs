using CongestionTaxCalculator.Application.Contracts;
using CongestionTaxCalculator.EFCore.Repository;
using CongestionTaxCalculator.Domain.Persistence.InterfaceRepository;
using AutoMapper;
using CongestionTaxCalculator.EFCore.Data;
using Persistence = CongestionTaxCalculator.Domain.Persistence;
using Model = CongestionTaxCalculator.Domain.Model;
using CongestionTaxCalculator.Domain.Model;
using System.Linq;
using CongestionTaxCalculator.Infrastructure;

namespace CongestionTaxCalculator.Application
{
    public class CongestionTaxAppService : ICongestionTaxAppService
    {
        private readonly ITariffDefinitionRepository _tariffDefinitionRepository;
        private readonly ICityRepository _cityRepository;

        public CongestionTaxAppService(CongestionTaxContext context)
        {
            _tariffDefinitionRepository = new TariffDefinitionRepository(context);
            _cityRepository = new CityRepository(context);
        }
        public Model.City GetACity(string name) => MyMapper.Map(_cityRepository.GetByName(name)!);

        /// <summary>
        /// This function generate TariffDefination value object based on request
        /// </summary>
        public TariffDefinition GenrateTariffDefination(CongestionTaxRequestDto request)
        {

            Persistence.TariffDefinition pTariffDefinition = _tariffDefinitionRepository.GetActiveTariff(cityName: request.CityName,
                                                                                                         startTariffYear: request.StartTariffYear,
                                                                                                         tariffNO: request.TariffNO);
            return (new TariffDefinition(MyMapper.Map(pTariffDefinition)));
        }

        private bool IsTollFreeVehicle(string vehicleType, TariffDefinition tariffDefinition)
        {
            return tariffDefinition.GetExemptVehicles().Any(vehicle => vehicle.VehicleType == vehicleType);
        }

        private bool IsTollFreeDate(DateTime date, TariffDefinition tariffDefinition)
        {

            bool flagPublicHoliday = false;
            flagPublicHoliday = tariffDefinition.TariffSetting.GetPublicHolidays().ToList().Any(x => x.DateHoliday.Year == date.Year &&
                                                                               x.DateHoliday.Month == date.Month &&
                                                                               x.DateHoliday.Day == date.Day);
            bool flagDaysBeforePublicHoliday = false;
            foreach (var hday in tariffDefinition.TariffSetting.GetPublicHolidays().ToList())
            {
                var beforeHday = hday.DateHoliday.Subtract(TimeSpan.FromDays(tariffDefinition.TariffSetting.NumberTaxFreeDaysBeforeHoliday));
                if (beforeHday.Year == date.Year && beforeHday.Month == date.Month && beforeHday.Day == date.Day)
                {
                    flagDaysBeforePublicHoliday = true;
                    break;
                }
            }


            bool flagWeekend = false;
            if (tariffDefinition.TariffSetting.GetWeekendDays().ToList().Contains(date.DayOfWeek))
                flagWeekend = true;


            bool flagTaxFreeMonthCalender = false;
            if (date.Month == (int)tariffDefinition.TariffSetting.TaxFreeMonthCalender)
                flagTaxFreeMonthCalender = true;

            if (flagPublicHoliday || flagDaysBeforePublicHoliday || flagWeekend || flagTaxFreeMonthCalender)
                return true;
            return false;
        }

        public Decimal GetTaxRule(DateTime datetime, TariffDefinition tariffDefinition)
        {
            Decimal tax = 0;
            foreach (var tariffCost in tariffDefinition.GetTariffCosts().ToList())
            {
                TimeRange tariffRange = new TimeRange(TimeOnly.FromTimeSpan(tariffCost.FromTime), TimeOnly.FromTimeSpan(tariffCost.ToTime));
                if (tariffRange.InRange(TimeOnly.FromDateTime(datetime)))
                {
                    tax += tariffCost.Amount;
                    break;
                }
            }
            return tax;
        }

        public Decimal GetTax(CongestionTaxRequestDto request)
        {
            TariffDefinition tariffDefinition = GenrateTariffDefination(request);

            //free tax
            if (IsTollFreeVehicle(vehicleType: request.VehicleType, tariffDefinition: tariffDefinition))
                return 0;

            if (request.TrafficTimeSequence == null || request.TrafficTimeSequence.Count() == 0)
                return 0;


            request.TrafficTimeSequence = TimeUtils.sortDateDesc(request.TrafficTimeSequence);

            //Remove Free day Tax
            List<DateTime> sequenceList = new List<DateTime>();
            foreach (var item in request.TrafficTimeSequence)
            {
                if (!IsTollFreeDate(date: item, tariffDefinition))
                    sequenceList.Add(item);
            }


            Dictionary<DateOnly, List<Decimal>> taxPerDay = new Dictionary<DateOnly, List<Decimal>>();
            List<DateOnly> oneDayPass = new List<DateOnly>();
            for (int start = 0; start < sequenceList.Count() - 1; start++)
            {
                DateTime entrance = sequenceList[start];
                if (oneDayPass.Contains(DateOnly.FromDateTime(entrance)))
                    continue;
                Decimal tax = GetTaxRule(entrance, tariffDefinition);
                for (int end = start + 1; end < sequenceList.Count(); end++)
                {
                    DateTime exit = sequenceList[end];
                    TimeSpan duration = exit.Subtract(entrance);
                    var durationInMinute = duration.TotalMinutes;
                    if (durationInMinute < tariffDefinition.TariffSetting.SingleCharegeInterval)
                    {
                        oneDayPass.Add(DateOnly.FromDateTime(exit));
                        Decimal tax2 = GetTaxRule(exit, tariffDefinition);
                        if (tax2 > tax)
                            tax = tax2;
                    }
                    else break;

                }//end end for 

                if (taxPerDay.ContainsKey(DateOnly.FromDateTime(entrance)))
                    taxPerDay.Add(DateOnly.FromDateTime(entrance), new List<decimal>() { tax });
                else
                    taxPerDay[DateOnly.FromDateTime(entrance)].Add(tax);
            }//end start for

            Decimal totalTax = 0;
            foreach (KeyValuePair<DateOnly, List<Decimal>> taxday in taxPerDay)
            {
                Decimal tatalTaxPerDay = taxday.Value.Sum();
                if (tatalTaxPerDay > tariffDefinition.TariffSetting.MaxTaxAmount)
                {
                    tatalTaxPerDay = tariffDefinition.TariffSetting.MaxTaxAmount;
                    taxday.Value.Clear();
                    taxday.Value.Add(tatalTaxPerDay);
                }
                totalTax += tatalTaxPerDay;
            }


            return totalTax;
        }//end function

    }
}