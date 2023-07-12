using CongestionTaxCalculator.Domain.Common;

namespace CongestionTaxCalculator.Domain.Model    
{
    public class City : ValueObject<City>
    {
        public string Name { get; private set; }

        private Vehicle[] _vehicles;
        private City() { }
        public City(string name, Vehicle[] vehicles)
        {
            this.Name = name;

            _vehicles = new Vehicle[vehicles.Length];
            for (int i = 0; i < vehicles.Length; i++)
            {
                this._vehicles[i] = new Vehicle(vehicles[i]);
            }
        }
        public City(City city) : this(city.Name, city._vehicles) { }
        
        public IEnumerable<Vehicle> GetVehicles()
        {
            foreach (var item in _vehicles)
            {
                yield return item;
            }
        }

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