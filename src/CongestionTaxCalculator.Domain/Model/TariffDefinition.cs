using CongestionTaxCalculator.Domain.Common;

namespace CongestionTaxCalculator.Domain.Model
{
    public sealed class TariffDefinition : ValueObject<TariffDefinition>
    {

        //Tariff Number
        public int TariffNO { get; init; } 
        public int StartTariffYear { get; init; }

        public bool IsActive { get; init; }

        public TariffSetting TariffSetting { get; init; }

        private TariffCost[] _tariffCosts;

        private TariffDefinition() { }

        public TariffDefinition(int tariffNO, int startTariffYear, bool isActive, TariffCost[] tariffCosts , TariffSetting tariffSetting)
        {
            this.TariffNO = tariffNO;
            this.StartTariffYear = startTariffYear;
            this.IsActive = isActive;

            this.TariffSetting = new TariffSetting(tariffSetting);

            this._tariffCosts = new TariffCost[tariffCosts.Length];
            for (int i = 0; i < tariffCosts.Length; i++)
            {
                this._tariffCosts[i] = new TariffCost(tariffCosts[i].FromTime, tariffCosts[i].ToTime, tariffCosts[i].Amount);
            }

        }

        public TariffDefinition(TariffDefinition tariffDefinition) : this(tariffDefinition.TariffNO, 
            tariffDefinition.StartTariffYear, tariffDefinition.IsActive, tariffDefinition.GetTariffCosts().ToArray(), tariffDefinition.TariffSetting)  { }


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