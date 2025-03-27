using FalzoniNetApi.Domain.Dtos.Register;
using FalzoniNetApi.Domain.Entities.Register;
using FalzoniNetApi.Domain.Interfaces.Repositories.Base;
using FalzoniNetApi.Domain.Interfaces.Repositories.Register;
using FalzoniNetApi.Domain.Interfaces.Services.Register;
using FalzoniNetApi.Service.Base;

namespace FalzoniNetApi.Service.Register
{
    public class CustomerService : BaseService<Customer, CustomerDTO>, ICustomerService
    {
        public CustomerService(ICustomerRepository repository, IUnitOfWork unitOfWork)
            :base(repository, unitOfWork)
        {
        }

        #region Overriding Methods
        protected override void Validate(CustomerDTO dto)
        {
            if (dto == null) throw new ApplicationException("Objeto nulo ou inválido");

            if (string.IsNullOrEmpty(dto.Name)) throw new ApplicationException("Nome do cliente é obrigatório");

            if (string.IsNullOrEmpty(dto.Document)) throw new ApplicationException("Documento do cliente é obrigatório");
        }

        protected override CustomerDTO ConvertToDTO(Customer entity)
        {
            return new CustomerDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                Document = entity.Document,
                Created = entity.Created,
                Modified = entity.Modified
            };
        }

        protected override Customer CreateEntity(CustomerDTO dto, out Customer entity)
        {
            entity = new Customer(Guid.NewGuid(), dto.Name!, dto.Document!, DateTime.Now);
            return entity;
        }

        protected override Customer UpdateEntity(ref Customer entity, CustomerDTO dto)
        {
            entity.Update(dto.Name!, dto.Document!, DateTime.Now);
            return entity;
        }
        #endregion
    }
}
