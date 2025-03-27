using FalzoniNetApi.Domain.Entities.Stock;
using FalzoniNetApi.Domain.Interfaces.Repositories.Stock;
using FalzoniNetApi.Infra.Data.Context;
using FalzoniNetApi.Infra.Data.Repositories.Base;

namespace FalzoniNetApi.Infra.Data.Repositories.Stock
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(FalzoniNetApiContext context) : base(context)
        {
        }
    }
}
