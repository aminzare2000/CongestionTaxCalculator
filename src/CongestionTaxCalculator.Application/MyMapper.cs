using System;
using AutoMapper;
using System.Collections;
using Persistence = CongestionTaxCalculator.Domain.Persistence;
using Model = CongestionTaxCalculator.Domain.Model;
using CongestionTaxCalculator.Domain.Common;


namespace CongestionTaxCalculator.Application
{
    public class MyMapper
    {
        public static Model.City Map(Persistence.City city) => new Model.City(city?.Name);
        private static Model.ExemptVehicle Map(Persistence.ExemptVehicle vehicle) => new Model.ExemptVehicle(vehicle.VehicleType);
        private static Model.PublicHoliday Map(Persistence.PublicHoliday publicHoliday) => new Model.PublicHoliday(publicHoliday.DateHoliday, publicHoliday.Description);
        private static Model.TariffSetting Map(Persistence.TariffSetting tariffSetting)
        {

            Model.PublicHoliday[]? publicHolidays = null;
            if (tariffSetting.PublicHolidays is not null)
            {
                publicHolidays = new Model.PublicHoliday[tariffSetting.PublicHolidays.Count()];
                for (int i = 0; i < publicHolidays.Length; i++)
                {
             
                        publicHolidays[i] = Map(tariffSetting.PublicHolidays.ElementAt(i));

                }

            }
            else
                throw new ApplicationException("NotFoundPublicHolidaysException");

            DAYS[]? weekends = null;
            if (tariffSetting.WorkingDays is not null)
            {
                List<Persistence.WorkingDay> pWeekends = tariffSetting.WorkingDays.Where(w => w.IsWeekend).ToList();
                if (pWeekends.Count() > 0)
                {
                    weekends = new DAYS[pWeekends.Count()];
                    for (int i = 0; i < weekends.Length; i++)
                    {
                        weekends[i] = pWeekends[i].day;
                    }
                }else
                    throw new ApplicationException("NotFoundWeekendsException");
            }
            else
                throw new ApplicationException("NotFoundWeekendsException");

            return new Model.TariffSetting(tariffSetting.NumberTaxFreeDaysBeforeHoliday,
                tariffSetting.MaxTaxAmount,
                tariffSetting.TaxFreeMonthCalender,
                publicHolidays,
                weekends);
        }
        private static Model.TariffCost Map(Persistence.TariffCost tariffCost) => new Model.TariffCost(tariffCost.FromTime, tariffCost.ToTime, tariffCost.Amount);

        public static Model.TariffDefinition Map(Persistence.TariffDefinition tariffDefinition)
        {

            //tariffDefinition.ExemptVehicles?.ToArray().
            //    .ForEach(vehicle => Map(vehicle));

            Model.ExemptVehicle[]? exemptVehicles = null;
            if (tariffDefinition.ExemptVehicles is not null)
            {
                exemptVehicles = new Model.ExemptVehicle[tariffDefinition.ExemptVehicles.Count()];
                for (int i = 0; i < exemptVehicles.Length; i++)
                {
                    {
                        exemptVehicles[i] = Map(tariffDefinition.ExemptVehicles.ElementAt(i));
                    };

                }
            }

            Model.TariffCost[] tariffCosts;
            if (tariffDefinition.TariffCosts is not null)
            {
                tariffCosts = new Model.TariffCost[tariffDefinition.TariffCosts.Count()];
                for (int i = 0; i < tariffCosts.Length; i++)
                {
                    {
                        tariffCosts[i] = Map(tariffDefinition.TariffCosts.ElementAt(i));
                    };

                }
            }
            else
                throw new ApplicationException("NotFoundTariffCostsException");

            if(tariffDefinition.TariffSetting is null)
                throw new ApplicationException("NotFoundTariffSettingException");

           return new Model.TariffDefinition(
                     tariffDefinition.TariffNO,
                     tariffDefinition.StartTariffYear,
                     tariffDefinition.IsActive,
                     Map(tariffDefinition.City),
                     exemptVehicles,
                     tariffCosts,
                     Map(tariffDefinition.TariffSetting)
                 );
        }
    }
}
