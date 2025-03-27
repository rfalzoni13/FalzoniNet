using FalzoniNetApi.Domain.Dtos.Base;
using FalzoniNetApi.Domain.Entities.Base;
using FalzoniNetApi.Domain.Interfaces.Repositories.Base;
using FalzoniNetApi.Domain.Interfaces.Services.Base;

namespace FalzoniNetApi.Service.Base
{
    public abstract class BaseService<TEntity, TDTO> : IBaseService<TDTO>
        where TEntity : BaseEntity, new()
        where TDTO : BaseDTO, new()
    {
        private readonly IBaseRepository<TEntity> _repository;
        private readonly IUnitOfWork _unitOfWork;

        public BaseService(IBaseRepository<TEntity> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public virtual ICollection<TDTO> GetAll() 
        {
            ICollection<TEntity> list = _repository.GetAll();
            return list.ToList().ConvertAll(l => ConvertToDTO(l));
        } 

        public virtual TDTO? Get(Guid id)
        {
            TEntity? obj = _repository.Get(id);
            return ConvertToDTO(obj!);
        }
            

        public virtual void Create(TDTO obj)
        {
            using(var transaction = _unitOfWork.GetTransaction())
            {
                try
                {
                    Validate(obj);

                    TEntity entity = CreateEntity(obj, out entity);

                    _repository.Create(entity);

                    transaction.Commit();
                }
                catch (ApplicationException ex)
                {
                    transaction.Rollback();
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
        }

        public virtual void Update(TDTO obj)
        {
            using(var transaction = _unitOfWork.GetTransaction())
            {
                try
                {
                    Validate(obj);

                    TEntity? entity = _repository.Get(obj.Id);

                    if (entity == null) throw new ApplicationException("Registro não encontrado");

                    UpdateEntity(ref entity, obj);

                    _repository.Update(entity);

                    transaction.Commit();
                }
                catch (ApplicationException ex)
                {
                    transaction.Rollback();
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
        }

        public virtual void Delete(Guid id)
        {
            using(var transaction = _unitOfWork.GetTransaction())
            {
                try
                {
                    _repository.Delete(id);
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine(ex.Message);
                    throw;
                }
            }
        }

        #region protected METHODS
        protected abstract void Validate(TDTO dto);
        protected abstract TDTO ConvertToDTO(TEntity entity);
        protected abstract TEntity CreateEntity(TDTO dto, out TEntity entity);
        protected abstract TEntity UpdateEntity(ref TEntity entity, TDTO dto);
        #endregion
    }
}
