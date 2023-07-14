using CongestionTaxCalculator.Application.Contracts;
using CongestionTaxCalculator.EFCore.Repository;
using CongestionTaxCalculator.Domain.Persistence.InterfaceRepository;
using AutoMapper;
using CongestionTaxCalculator.EFCore.Data;
using Persistence = CongestionTaxCalculator.Domain.Persistence;
using Model = CongestionTaxCalculator.Domain.Model;
using CongestionTaxCalculator.Domain.Model;

namespace CongestionTaxCalculator.Application
{
    public class CongestionTaxAppService : ICongestionTaxAppService
    {
        private readonly ITariffDefinitionRepository _tariffDefinitionRepository;
        private readonly ICityRepository _cityRepository;

        public CongestionTaxAppService(CongestionTaxContext context)
        {
            _tariffDefinitionRepository = new TariffDefinitionRepository(context);
            _cityRepository = new CityRepository(context);
        }
        public Model.City GetACity(string name) => MyMapper.Map(_cityRepository.GetByName(name)!);

        /// <summary>
        /// This function generate TariffDefination value object based on request
        /// </summary>
        public TariffDefinition GenrateTariffDefination(CongestionTaxRequestDto request)
        {

            Persistence.TariffDefinition pTariffDefinition = _tariffDefinitionRepository.GetActiveTariff(request.CityName);
            return (new TariffDefinition(MyMapper.Map(pTariffDefinition) ) );
        }

    }
}   