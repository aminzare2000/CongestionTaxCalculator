using CongestionTaxCalculator.Domain.Common;

namespace CongestionTaxCalculator.Domain.Model    
{
    public class City : ValueObject<City>
    {
        public string Name { get; private set; }

        
        private City() { }
        public City(string? name)
        {
            this.Name = name!;


        }
        public City(City city) : this(city.Name) { }
        


        protected override bool EqualsCore(City other)
        {
            return Name == other.Name;
        }

        protected override int GetHashCodeCore()
        {
            return (Name.GetHashCode());
        }
    }
}