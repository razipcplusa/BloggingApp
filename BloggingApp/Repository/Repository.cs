using BloggingApp.Interfaces;
using BloggingApp.Model;
using Microsoft.EntityFrameworkCore;

namespace BloggingApp.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {

        protected readonly BlogContext _context;
        protected readonly DbSet<T> _entities;

        public Repository(BlogContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return await _entities.ToListAsync();
        }

        public async Task<T> GetById(int id)
        {
            return await _entities.FindAsync(id);
        }

        public async Task Add(T entity)
        {
            await _entities.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(T entity)
        {
            _entities.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var entity = await _entities.FindAsync(id);
            if (entity != null)
            {
                _entities.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
