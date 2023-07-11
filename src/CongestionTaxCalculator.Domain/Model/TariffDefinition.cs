using CongestionTaxCalculator.Domain.Common;

namespace CongestionTaxCalculator.Domain.Model
{
    public sealed class TariffDefinition : ValueObject<TariffDefinition>
    {

        //Tariff Number
        public int TariffNO { get; init; } 
        public int StartTariffYear { get; init; }

        public bool IsActive { get; init; }

        private TariffCost[] _tariffCosts;

        //public TariffSetting? TariffSetting { get; set; }

        public IEnumerable<TariffCost> GetTariffCosts()
        {
            foreach (var item in _tariffCosts)
            {
                yield return item;
            }
        }

        protected override bool EqualsCore(TariffDefinition other)
        {
            throw new NotImplementedException();
        }

        protected override int GetHashCodeCore()
        {
            throw new NotImplementedException();
        }
    }
}