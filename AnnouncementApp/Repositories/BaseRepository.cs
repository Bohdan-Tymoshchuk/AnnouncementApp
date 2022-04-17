using AnnouncementApp.Abstractions;
using AnnouncementApp.Data;
using AnnouncementApp.Models;
using Microsoft.EntityFrameworkCore;

namespace AnnouncementApp.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        protected readonly DataContext _context;
        public BaseRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            var createdEntity = _context.Set<TEntity>().Add(entity);

            await SaveChanges();

            return createdEntity.Entity;
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);

            await SaveChanges();
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task UpdateAsync(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);

            await SaveChanges();
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(x => x.Id == id);
        }

        private async Task SaveChanges()
        {
            var result = await _context.SaveChangesAsync();

            if (result <= 0)
            {
                throw new InvalidOperationException();
            }
        }
    }
}
