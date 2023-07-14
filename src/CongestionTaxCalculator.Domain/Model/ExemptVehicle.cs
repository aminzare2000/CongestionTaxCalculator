using CongestionTaxCalculator.Domain.Common;

namespace CongestionTaxCalculator.Domain.Model
{
    public sealed class ExemptVehicle : ValueObject<ExemptVehicle>
    {
        public string VehicleType { get; init; }// = String.Empty;

        public ExemptVehicle(string? vehicleType)
        {
            this.VehicleType = vehicleType!;
        }
        public ExemptVehicle(ExemptVehicle vehicle ) : this(vehicle.VehicleType) { }

       

    protected override bool EqualsCore(ExemptVehicle other)
        {
            return VehicleType == other.VehicleType;
        }

        protected override int GetHashCodeCore()
        {
            return (VehicleType.GetHashCode());
        }
    }
}