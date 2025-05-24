using HouseHoldCart.DataAccess.Interfaces;

namespace HouseHoldCart.DataAccess
{
    public class CrudOperation<T>(AppDbContext _context) : ICrudOperation<T> where T : class
    {
        public async Task<T> CreateAsync(T item)
        {
            _context.Set<T>().Add(item);
            await _context.SaveChangesAsync();
            return item;
        }

        public Task<T> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<T>> SearchAsync(string query)
        {
            throw new NotImplementedException();
        }

        public async Task<T> UpdateAsync(T item)
        {
            _context.Set<T>().Update(item);
            await _context.SaveChangesAsync();
            return item;
        }
    }
}
