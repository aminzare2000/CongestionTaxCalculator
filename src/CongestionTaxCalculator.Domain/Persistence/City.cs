using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CongestionTaxCalculator.Domain.Common;

namespace CongestionTaxCalculator.Domain.Persistence
{
    public class City
    {
        public City()
        {
            Id = Guid.NewGuid();
        }

        public City(Guid Id)
        {
            this.Id = Id;
        }
        public virtual Guid Id { get; private set; }
        public string Name { get; set; } = string.Empty;

        public virtual ICollection<Vehicle>? Vehicles { get; set; }

    }
}