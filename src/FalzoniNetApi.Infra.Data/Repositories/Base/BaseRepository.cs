using FalzoniNetApi.Domain.Entities.Base;
using FalzoniNetApi.Domain.Interfaces.Repositories.Base;
using FalzoniNetApi.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace FalzoniNetApi.Infra.Data.Repositories.Base
{
    public class BaseRepository<T> : IBaseRepository<T>, IDisposable where T : BaseEntity, new()
    {
        protected FalzoniNetApiContext? context { get; private set; }

        public BaseRepository(FalzoniNetApiContext context)
        {
            this.context = context;
        }

        #region Synchronous Methods
        public virtual ICollection<T> GetAll()
            => this.context!.Set<T>().ToList();

        public virtual T? Get(Guid id)
            => this.context!.Set<T>().Find(id);

        public virtual void Create(T obj)
        {
            if (obj == null) return;

            this.context!.Set<T>().Add(obj);
            this.context!.SaveChanges();
        }

        public virtual void Update(T obj)
        {
            if (obj == null) return;

            this.context!.Set<T>().Update(obj);
            this.context!.SaveChanges();
        }

        public virtual void Delete(Guid id)
        {
            T? obj = this.context!.Set<T>().Find(id);
            if (obj == null) return;

            this.context!.Set<T>().Remove(obj);
            this.context!.SaveChanges();
        }
        #endregion

        #region Asynchronous Methods
        public virtual async Task<ICollection<T>> GetAllAsync()
            => await this.context!.Set<T>().ToListAsync();

        public virtual async Task<T?> GetAsync(Guid id)
            => await this.context!.Set<T>().FindAsync(id);

        public virtual async Task CreateAsync(T obj)
        {
            if (obj == null) return;

            await this.context!.Set<T>().AddAsync(obj);
            await this.context!.SaveChangesAsync();
        }

        public virtual async Task UpdateAsync(T obj)
        {
            if (obj == null) return;

            this.context!.Set<T>().Update(obj);
            await this.context!.SaveChangesAsync();
        }

        public virtual async Task DeleteAsync(Guid id)
        {
            T? obj = await this.context!.Set<T>().FindAsync(id);
            if(obj == null) return;
            
            this.context!.Set<T>().Remove(obj);
            await this.context!.SaveChangesAsync();
        }
        #endregion

        public void Dispose()
        {
            this.context!.Dispose();
        }
    }
}
