using CongestionTaxCalculator.Domain.Common;

namespace CongestionTaxCalculator.Domain.Model    
{
    public sealed class CongestionTaxRule : ValueObject<CongestionTaxRule>
    {
        public City City { get; init; }

        private Vehicle[] Vehicles { get; init; }
        
        public CongestionTaxRule(City city, Vehicle[] vehicles)
        {
            City = city; //value assignment

        }

        public IEnumerable<Vehicle> GetVehicles()
        {
            foreach (var item in Vehicles)
            {
                yield return item;
            }
        }
        protected override int GetHashCodeCore()
        {
            throw new NotImplementedException();
        }

        protected override bool EqualsCore(CongestionTaxRule other)
        {
            throw new NotImplementedException();
        }
    }
}