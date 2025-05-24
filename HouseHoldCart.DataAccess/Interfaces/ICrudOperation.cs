namespace HouseHoldCart.DataAccess.Interfaces
{
    public interface ICrudOperation<T>
    {
        public Task<T> CreateAsync(T houseHoldItem);
        public Task<IEnumerable<T>> SearchAsync(string query);
        public Task<T> UpdateAsync(T houseHoldItem);
        public Task<T> DeleteAsync(int id);
        public Task<T> GetAsync(int id);
    }
}
