﻿using CongestionTaxCalculator.Domain.Common;

namespace CongestionTaxCalculator.Domain.Model    
{
    public sealed class CongestionTaxRule : ValueObject<CongestionTaxRule>
    {
        private string _cityName { get; init; }
        private ExemptVehicle[] _exemptVehicles { get; init; }
        private TariffDefinition[] _tariffDefinitions { get; init; }

        private CongestionTaxRule()
        {

        }
        public CongestionTaxRule(string cityName , ExemptVehicle[] exemptVehicles, TariffDefinition[] tariffDefinitions)
        {
            this.City = new(city);

            this._tariffDefinitions = new TariffDefinition[tariffDefinitions.Length];
            for (int i = 0; i < tariffDefinitions.Length; i++)
            {
                this._tariffDefinitions[i] = new TariffDefinition(tariffDefinitions[i]);
            }


            this._tariffDefinitions = new TariffDefinition[tariffDefinitions.Length];
            for (int i = 0; i < tariffDefinitions.Length; i++)
            {
                this._tariffDefinitions[i] = new TariffDefinition(tariffDefinitions[i]);
            }

        }

        public IEnumerable<TariffDefinition> GetTariffDefinitions()
        {
            foreach (var item in _tariffDefinitions)
            {
                yield return item;
            }
        }

        protected override int GetHashCodeCore()
        {
            throw new NotImplementedException();
        }

        protected override bool EqualsCore(CongestionTaxRule other)
        {
            throw new NotImplementedException();
        }
    }
}