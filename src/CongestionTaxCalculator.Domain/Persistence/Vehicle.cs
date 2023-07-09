using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CongestionTaxCalculator.Domain.Persistence
{
    public class Vehicle
    {

        public int Id { get; set; }
        public string VehicleType { get; set; } = string.Empty;

        public virtual ICollection<City> Cities { get; set; } = new HashSet<City>();
    }
}