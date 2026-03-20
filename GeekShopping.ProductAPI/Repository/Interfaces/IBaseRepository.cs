using GeekShopping.ProductAPI.Data.ValueObjects;

namespace GeekShopping.ProductAPI.Repository.Interfaces
{
    public interface IBaseRepository<T>
    {
        Task<IEnumerable<T>> FindAll();
        Task<T> FindById(long id);
        Task<T> Create(T product);
        Task<T> Update(T product);
        Task<bool> Delete(long id);
    }
}
