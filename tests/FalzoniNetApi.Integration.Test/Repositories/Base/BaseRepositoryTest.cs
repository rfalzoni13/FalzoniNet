using FalzoniNetApi.Data.Seed.Configuration;
using FalzoniNetApi.Domain.Entities.Base;
using FalzoniNetApi.Domain.Interfaces.Repositories.Base;
using FalzoniNetApi.Infra.Data.Context;
using FalzoniNetApi.Infra.IoC.Enum;
using FalzoniNetApi.Infra.IoC.Services;
using FalzoniNetApi.Utils.Helpers;
using Microsoft.Extensions.Configuration;

namespace FalzoniNetApi.Integration.Test.Repositories.Base
{   
    public abstract class BaseRepositoryTest<T> : IDisposable where T : BaseEntity, new()
    {
        private readonly IConfiguration _configuration;
        protected IBaseRepository<T>? _repository;
        protected readonly FalzoniNetApiContext? context;

        public BaseRepositoryTest()
        {
            _configuration = TestEnvironment.LoadEnvironmentTest(@"appsettings.Integration.Test.json");

            ConfigurationHelper.LoadConfiguration(_configuration);

            this.context = DependencyService<FalzoniNetApiContext>.GetRequiredService(EServiceType.OnlyContext);
            LoadData();
        }

        public virtual void Test_GetAll_Success()
        {
            ICollection<T> list = _repository!.GetAll();

            Assert.Equal(9, list.Count);
        }

        public virtual void Test_Get_Success(Guid id)
        {
            var obj = _repository!.Get(id);

            Assert.NotNull(obj);
        }

        public virtual void Test_Create_Success()
        {
            T obj = CreateObject();

            _repository!.Create(obj);
        }

        public virtual void Test_Update_Success(Guid id)
        {
            T? obj = _repository!.Get(id);

            obj = UpdateObject(ref obj!);

            _repository!.Update(obj);
        }

        public virtual void Test_Delete_Success(Guid id)
        {
            _repository!.Delete(id);
        }

        public virtual void Dispose()
        {
            this.context!.Database.EnsureDeleted();
            this.context!.Dispose();
        }

        #region Abstract Methods
        protected abstract void LoadData();
        protected abstract T CreateObject();
        protected abstract T UpdateObject(ref T obj);
        #endregion
    }
}
