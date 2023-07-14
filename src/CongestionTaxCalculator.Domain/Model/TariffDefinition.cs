using CongestionTaxCalculator.Domain.Common;

namespace CongestionTaxCalculator.Domain.Model
{
    public sealed class TariffDefinition : ValueObject<TariffDefinition>
    {

        //Tariff Number
        public int TariffNO { get; set; } 
        public int StartTariffYear { get; init; }

        public bool IsActive { get; init; }

        public City City { get; init; }

        public TariffSetting TariffSetting { get; init; }

        private TariffCost[] _tariffCosts;
        private ExemptVehicle[] _exemptVehicles;

        private TariffDefinition() { }

        //TariffDefinition can be without ExemptVehicle
        public TariffDefinition(int tariffNO, int startTariffYear, bool isActive, City city, ExemptVehicle[]? exemptVehicles, TariffCost[] tariffCosts , TariffSetting tariffSetting)
        {
            this.TariffNO = tariffNO;
            this.StartTariffYear = startTariffYear;
            this.IsActive = isActive;

            this.City = new City(city);

            this.TariffSetting = new TariffSetting(tariffSetting);

            this._tariffCosts = new TariffCost[tariffCosts.Length];
            for (int i = 0; i < tariffCosts.Length; i++)
            {
                this._tariffCosts[i] = new TariffCost(tariffCosts[i].FromTime, tariffCosts[i].ToTime, tariffCosts[i].Amount);
            }

            //TariffDefinition can be without ExemptVehicle
            if (exemptVehicles is not null)
            {
                this._exemptVehicles = new ExemptVehicle[exemptVehicles.Length];
                for (int i = 0; i < exemptVehicles.Length; i++)
                {
                    this._exemptVehicles[i] = new ExemptVehicle(exemptVehicles[i].VehicleType);
                }
            }
            else
            {
                this._exemptVehicles = new ExemptVehicle[] { new ExemptVehicle("None") };
            }
        }




        public TariffDefinition(TariffDefinition tariffDefinition) : 
            this(tariffDefinition.TariffNO, 
            tariffDefinition.StartTariffYear,
            tariffDefinition.IsActive, 
            tariffDefinition.City,
            tariffDefinition.GetExemptVehicles().ToArray(), 
            tariffDefinition.GetTariffCosts().ToArray(),
            tariffDefinition.TariffSetting)  { }


        public IEnumerable<TariffCost> GetTariffCosts()
        {
            foreach (var item in _tariffCosts)
            {
                yield return item;
            }
        }

        public IEnumerable<ExemptVehicle> GetExemptVehicles()
        {
            foreach (var item in _exemptVehicles)
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