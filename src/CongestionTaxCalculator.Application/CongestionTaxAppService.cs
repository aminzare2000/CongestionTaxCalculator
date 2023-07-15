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
        private readonly TariffDefinition _tariffDefinition;

        public CongestionTaxAppService(TariffDefinition tariffDefinition)
        {
            this._tariffDefinition = new TariffDefinition(tariffDefinition);
        }
        private bool IsTollFreeVehicle(string vehicleType)
        {
            return _tariffDefinition.GetExemptVehicles().Any(vehicle => vehicle.VehicleType == vehicleType);
        }

        private bool IsTollFreeDate(DateTime date)
        {

            bool flagPublicHoliday = false;
            flagPublicHoliday = _tariffDefinition.TariffSetting.GetPublicHolidays().ToList().Any(x => x.DateHoliday.Year == date.Year &&
                                                                               x.DateHoliday.Month == date.Month &&
                                                                               x.DateHoliday.Day == date.Day);
            bool flagDaysBeforePublicHoliday = false;
            foreach (var hday in _tariffDefinition.TariffSetting.GetPublicHolidays().ToList())
            {
                var beforeHday = hday.DateHoliday.Subtract(TimeSpan.FromDays(_tariffDefinition.TariffSetting.NumberTaxFreeDaysBeforeHoliday));
                if (beforeHday.Year == date.Year && beforeHday.Month == date.Month && beforeHday.Day == date.Day)
                {
                    flagDaysBeforePublicHoliday = true;
                    break;
                }
            }


            bool flagWeekend = false;
            if (_tariffDefinition.TariffSetting.GetWeekendDays().ToList().Contains(date.DayOfWeek))
                flagWeekend = true;


            bool flagTaxFreeMonthCalender = false;
            if (date.Month == (int)_tariffDefinition.TariffSetting.TaxFreeMonthCalender)
                flagTaxFreeMonthCalender = true;

            if (flagPublicHoliday || flagDaysBeforePublicHoliday || flagWeekend || flagTaxFreeMonthCalender)
                return true;
            return false;
        }

        private Decimal GetTaxRule(DateTime datetime)
        {
            Decimal tax = 0;
            foreach (var tariffCost in _tariffDefinition.GetTariffCosts().ToList())
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
            //free tax
            if (IsTollFreeVehicle(vehicleType: request.VehicleType))
                return 0;

            if (request.TrafficTimeSequence == null || request.TrafficTimeSequence.Count() == 0)
                return 0;


            request.TrafficTimeSequence = TimeUtils.sortDateDesc(request.TrafficTimeSequence);

            //Remove Free day Tax
            List<DateTime> sequenceList = new List<DateTime>();
            foreach (var item in request.TrafficTimeSequence)
            {
                if (!IsTollFreeDate(date: item))
                    sequenceList.Add(item);
            }


            Dictionary<DateOnly, List<Decimal>> taxPerDay = new Dictionary<DateOnly, List<Decimal>>();
            List<TimeOnly> oneDayPass = new List<TimeOnly>();
            for (int start = 0; start < sequenceList.Count() - 1; start++)
            {
                DateTime entrance = sequenceList[start];
                if (oneDayPass.Contains(TimeOnly.FromDateTime(entrance)))
                    continue;
                Decimal tax = GetTaxRule(entrance);
                for (int end = start + 1; end < sequenceList.Count(); end++)
                {
                    DateTime exit = sequenceList[end];
                    TimeSpan duration = exit.Subtract(entrance);
                    var durationInMinute = duration.TotalMinutes;
                    if (durationInMinute < _tariffDefinition.TariffSetting.SingleCharegeInterval)
                    {
                        oneDayPass.Add(TimeOnly.FromDateTime(exit));
                        Decimal tax2 = GetTaxRule(exit);
                        if (tax2 > tax)
                            tax = tax2;
                    }
                    else break;

                }//end end for 

                if (taxPerDay.ContainsKey(DateOnly.FromDateTime(entrance)))
                    taxPerDay[DateOnly.FromDateTime(entrance)].Add(tax);                
                else
                    taxPerDay.Add(DateOnly.FromDateTime(entrance), new List<decimal>() { tax });
            }//end start for

            Decimal totalTax = 0;
            foreach (KeyValuePair<DateOnly, List<Decimal>> taxday in taxPerDay)
            {
                Decimal tatalTaxPerDay = taxday.Value.Sum();
                if (tatalTaxPerDay > _tariffDefinition.TariffSetting.MaxTaxAmount)
                {
                    tatalTaxPerDay = _tariffDefinition.TariffSetting.MaxTaxAmount;
                    taxday.Value.Clear();
                    taxday.Value.Add(tatalTaxPerDay);
                }
                totalTax += tatalTaxPerDay;
            }


            return totalTax;
        }//end function

    }
}