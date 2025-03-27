using FalzoniNetApi.Domain.Dtos.Base;

namespace FalzoniNetApi.Domain.Interfaces.Services.Base
{
    public interface IBaseService<TDTO>
        where TDTO : BaseDTO, new()
    {
        ICollection<TDTO> GetAll();

        TDTO? Get(Guid id);

        void Create(TDTO obj);

        void Update(TDTO obj);

        void Delete(Guid id);
    }
}
