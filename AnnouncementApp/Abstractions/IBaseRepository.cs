using AnnouncementApp.Models;

namespace AnnouncementApp.Abstractions
{
    public interface IBaseRepository<TEntity> where TEntity : BaseEntity
    {
        public Task<TEntity> CreateAsync(TEntity entity);

        public Task UpdateAsync(TEntity entity);

        public Task DeleteAsync(TEntity entity);

        public Task<List<TEntity>> GetAllAsync();

        public Task<TEntity> GetByIdAsync(int id);

    }
}