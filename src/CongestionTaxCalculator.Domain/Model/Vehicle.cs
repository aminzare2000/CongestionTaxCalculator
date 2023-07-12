using CongestionTaxCalculator.Domain.Common;

namespace CongestionTaxCalculator.Domain.Model
{
    public sealed class Vehicle : ValueObject<Vehicle>
    {
        public string VehicleType { get; init; }// = String.Empty;

        public Vehicle(string VehicleType)
        {
            this.VehicleType = VehicleType;
        }
        public Vehicle(Vehicle vehicle ) : this(vehicle.VehicleType) { }

       

    protected override bool EqualsCore(Vehicle other)
        {
            return VehicleType == other.VehicleType;
        }

        protected override int GetHashCodeCore()
        {
            return (VehicleType.GetHashCode());
        }
    }
}