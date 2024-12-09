using Microsoft.EntityFrameworkCore;
using StoreyChallenge.Interface;
using StoreyChallenge.Models;

namespace StoreyChallenge.Context
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task AddAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
           
            var entity = await _dbSet.FindAsync(id);

            
            if (entity != null)
            {
                
                var property = entity.GetType().GetProperty("IsDeleted");
                if (property != null)
                {
                    property.SetValue(entity, true);
                }

               
                await _context.SaveChangesAsync();
            }
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task<List<Category>> GetAllWithItems()
        {
            return await _context.Categories.Include(c=>c.Items).ToListAsync();
        }
    }
}
