using CongestionTaxCalculator.Domain.Common;

namespace CongestionTaxCalculator.Domain.Model
{
    public sealed class PublicHoliday : ValueObject<PublicHoliday>
    {

        public DateTime DateHoliday { get; init; }

        public string Description { get; init; } = String.Empty;

        private PublicHoliday()
        {

        }

        public PublicHoliday(DateTime dateHoliday)
        {
            this.DateHoliday = new DateTime(dateHoliday.Year, dateHoliday.Month, dateHoliday.Day);
        }

        public PublicHoliday(DateTime dateHoliday,string description)
        {
            this.DateHoliday = new DateTime(dateHoliday.Year, dateHoliday.Month, dateHoliday.Day);
            this.Description = description; 
        }

        protected override bool EqualsCore(PublicHoliday other) => DateHoliday.CompareTo(other.DateHoliday) == 0 && Description == other.Description;


        protected override int GetHashCodeCore()
        {
            unchecked
            {
                int hashCode = DateHoliday.GetHashCode();
                hashCode = (hashCode * 397) ^ Description.GetHashCode();
                return hashCode;
            }
        }
    }
}