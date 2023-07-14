using CongestionTaxCalculator.Domain.Persistence.InterfaceRepository;
using CongestionTaxCalculator.EFCore.Data;
using Microsoft.EntityFrameworkCore;

namespace CongestionTaxCalculator.EFCore.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        protected readonly CongestionTaxContext _context;
        public Repository(CongestionTaxContext _context)
        {
            this._context = _context;
        }

        public IEnumerable<T> GetAll() => _context.Set<T>().ToList<T>();
        public async Task<T?> Get(int id) => await _context.Set<T>().FindAsync(id);


        public async Task<T> Add(T entity)
        {
            _context.Set<T>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task AddRange(List<T> entitylist)
        {
            _context.Set<T>().AddRange(entitylist);
            await _context.SaveChangesAsync();
        }

        public async Task<T> Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<T?> Delete(int id)
        {
            var entity = await _context.Set<T>().FindAsync(id);
            if (entity == null)
            {
                return entity;
            }

            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();

            return entity;
        }

    }
}
