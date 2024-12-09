using StoreyChallenge.DTO.responseDTO;
using StoreyChallenge.Models;

namespace StoreyChallenge.Interface
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
        Task SaveAsync();

        Task <List<Category>> GetAllWithItems();
    }
}
