using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CongestionTaxCalculator.Domain.Common;

namespace CongestionTaxCalculator.Domain.Persistence
{
    public class CityVehicle
    {
        public City City { get; set; } = new City();
        public int CityId { get; set; }

        public Vehicle Vehicle { get; set; } = new Vehicle();
        public int VehicleId { get; set; }
        public bool IsExempt { get; set; } = false;

    }
}