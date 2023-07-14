using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CongestionTaxCalculator.Domain.Persistence
{
    public class ExemptVehicle
    {

        public int Id { get; set; }
        public string VehicleType { get; set; } = String.Empty;
        public TariffDefinition? TariffDefinition { get; set; }
        public int TariffDefinitionId { get; set; }
    }
}