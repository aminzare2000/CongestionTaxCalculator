using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CongestionTaxCalculator.Domain.Persistence
{
    public class Vehicle
    {

        public int Id { get; set; }
        public string VehicleType { get; set; } = String.Empty;

        public virtual ICollection<CityVehicle>? CityVehicles { get; set; }
    }
}