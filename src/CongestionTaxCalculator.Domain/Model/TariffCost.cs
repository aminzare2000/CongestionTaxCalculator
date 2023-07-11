using CongestionTaxCalculator.Domain.Common;

namespace CongestionTaxCalculator.Domain.Model
{
    public sealed class TariffCost : ValueObject<TariffCost>
    {
        public TimeSpan FromTime { get; init; }
        public TimeSpan ToTime { get; init; }
        public Decimal Amount { get; init; }


        protected override bool EqualsCore(TariffCost other)
        {
            return (FromTime.CompareTo(other.FromTime) == 0 &&
                ToTime.CompareTo(other.ToTime) == 0 &&
                Amount == other.Amount);
        }

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                int hashCode = FromTime.GetHashCode();
                hashCode = (hashCode * 397) ^ ToTime.GetHashCode();
                hashCode = (hashCode * 397) ^ Amount.GetHashCode();
                return hashCode;
            }
            
        }
    }
}
