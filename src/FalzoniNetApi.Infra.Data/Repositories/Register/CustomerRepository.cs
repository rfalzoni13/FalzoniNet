using FalzoniNetApi.Domain.Entities.Register;
using FalzoniNetApi.Domain.Interfaces.Repositories.Register;
using FalzoniNetApi.Infra.Data.Context;
using FalzoniNetApi.Infra.Data.Repositories.Base;

namespace FalzoniNetApi.Infra.Data.Repositories.Register
{
    public class CustomerRepository : BaseRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(FalzoniNetApiContext context) : base(context)
        {
        }
    }
}
