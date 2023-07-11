
using CongestionTaxCalculator.Domain.Common;


//---Not Used
namespace CongestionTaxCalculator.Domain.Model
{
    public sealed class WorkingDay : ValueObject<WorkingDay>
    {

        public DAYS day { get; init; }

        public bool IsWeekend { get; init; }

        private WorkingDay()
        {

        }

        public WorkingDay(DAYS day, bool isWeekend)
        {
            this.day = day; 
            this.IsWeekend = isWeekend;
        }

        protected override bool EqualsCore(WorkingDay other) => other.day == this.day && other.IsWeekend == this.IsWeekend;


        protected override int GetHashCodeCore()
        {
            unchecked
            {
                int hashCode = day.GetHashCode();
                hashCode = (hashCode * 397) ^ IsWeekend.GetHashCode();
                return hashCode;
            }
        }
    }
}