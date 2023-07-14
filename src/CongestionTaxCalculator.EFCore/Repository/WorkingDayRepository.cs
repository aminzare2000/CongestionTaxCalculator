using CongestionTaxCalculator.Domain.Persistence;
using CongestionTaxCalculator.Domain.Persistence.InterfaceRepository;
using CongestionTaxCalculator.EFCore.Data;
using Microsoft.EntityFrameworkCore;

namespace CongestionTaxCalculator.EFCore.Repository
{
    public class WorkingDayRepository : Repository<WorkingDay>, IWorkingDayRepository
    {
        public WorkingDayRepository(CongestionTaxContext context) : base(context)
        {
        }

        public IEnumerable<WorkingDay>? GetWeekendDays(TariffSetting tariffSetting)
        { }

    }
}
