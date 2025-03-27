using FalzoniNetApi.Domain.Entities.Base;

namespace FalzoniNetApi.Domain.Interfaces.Repositories.Base
{
    public interface IBaseRepository<T> where T : BaseEntity, new()
    {
        ICollection<T> GetAll();
        Task<ICollection<T>> GetAllAsync();

        T? Get(Guid id);
        Task<T?> GetAsync(Guid id);

        void Create(T obj);
        Task CreateAsync(T obj);

        void Update(T obj);
        Task UpdateAsync(T obj);

        void Delete(Guid id);
        Task DeleteAsync(Guid id);
    }
}
