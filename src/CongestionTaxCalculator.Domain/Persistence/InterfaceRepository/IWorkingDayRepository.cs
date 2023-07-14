using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionTaxCalculator.Domain.Persistence.InterfaceRepository
{
    public interface IWorkingDayRepository : IRepository<WorkingDay>
    {
        public IEnumerable<WorkingDay>? GetWeekendDays();
    }
}
