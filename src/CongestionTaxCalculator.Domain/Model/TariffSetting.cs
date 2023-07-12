using CongestionTaxCalculator.Domain.Common;

namespace CongestionTaxCalculator.Domain.Model
{
    public sealed class TariffSetting : ValueObject<TariffSetting>
    {

        public int NumberTaxFreeDaysBeforeHoliday { get; init; } 

        public Decimal MaxTaxAmount { get; init; }

        public MONTH TaxFreeMonthCalender { get; init; }

        private PublicHoliday[] _publicHolidays;

        private DAYS[] _weekendDays;

        private TariffSetting() { }

        public TariffSetting(int numberTaxFreeDaysBeforeHoliday , Decimal maxTaxAmount,
            MONTH taxFreeMonthCalender, PublicHoliday[] publicHolidays, DAYS[] weekendDays)
        {
            this.NumberTaxFreeDaysBeforeHoliday = numberTaxFreeDaysBeforeHoliday;
            this.MaxTaxAmount = maxTaxAmount;
            this.TaxFreeMonthCalender = taxFreeMonthCalender;

            this._publicHolidays = new PublicHoliday[publicHolidays.Length];
            for (int i = 0; i < publicHolidays.Length; i++)
            {
                this._publicHolidays[i] = new PublicHoliday(publicHolidays[i].DateHoliday);
            }


            this._weekendDays = new DAYS[weekendDays.Length];
            for (int i = 0; i < weekendDays.Length; i++)
            {
                this._weekendDays[i] = weekendDays[i];
            }

        }

        public TariffSetting(TariffSetting copyTariffSetting ) : this(copyTariffSetting.NumberTaxFreeDaysBeforeHoliday,
                copyTariffSetting.MaxTaxAmount,
                copyTariffSetting.TaxFreeMonthCalender,
                copyTariffSetting._publicHolidays,
                copyTariffSetting._weekendDays)
        { }

        public IEnumerable<PublicHoliday> GetPublicHolidays()
        {
            foreach (var item in _publicHolidays)
            {
                yield return item;
            }
        }

        public IEnumerable<DAYS> GetDays()
        {
            foreach (var item in _weekendDays)
            {
                yield return item;
            }
        }

        protected override bool EqualsCore(TariffSetting other)
        {
            throw new NotImplementedException();
        }

        protected override int GetHashCodeCore()
        {
            throw new NotImplementedException();
        }
    }
}