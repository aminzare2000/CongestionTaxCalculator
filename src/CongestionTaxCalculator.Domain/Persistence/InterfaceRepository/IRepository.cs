using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CongestionTaxCalculator.Domain.Persistence.InterfaceRepository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        Task<T?> Get(int id);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T?> Delete(int id);
    }
}
