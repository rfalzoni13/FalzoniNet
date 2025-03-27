using FalzoniNetApi.Domain.Dtos.Stock;
using FalzoniNetApi.Domain.Entities.Stock;
using FalzoniNetApi.Domain.Interfaces.Repositories.Base;
using FalzoniNetApi.Domain.Interfaces.Repositories.Stock;
using FalzoniNetApi.Domain.Interfaces.Services.Stock;
using FalzoniNetApi.Service.Base;

namespace FalzoniNetApi.Service.Stock
{
    public class ProductService : BaseService<Product, ProductDTO>, IProductService
    {
        public ProductService(IProductRepository repository, IUnitOfWork unitOfWork) 
            : base(repository, unitOfWork)
        {
        }

        #region Overriding Methods
        protected override void Validate(ProductDTO dto)
        {
            if (dto == null) throw new ApplicationException("Objeto nulo ou inválido");

            if (string.IsNullOrEmpty(dto.Name)) throw new ApplicationException("Nome do produto é obrigatório");

            if (dto.Price <= 0) throw new ApplicationException("O preço do produto precisa ser maior que zero");
        }

        protected override ProductDTO ConvertToDTO(Product entity)
        {
            return new ProductDTO
            {
                Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price,
                Discount = entity.Discount,
                Created = entity.Created,
                Modified = entity.Modified
            };
        }

        protected override Product CreateEntity(ProductDTO dto, out Product entity)
        {
            entity = new Product(Guid.NewGuid(), dto.Name!, dto.Price, dto.Discount, DateTime.Now);
            return entity;
        }

        protected override Product UpdateEntity(ref Product entity, ProductDTO dto)
        {
            entity.Update(dto.Name!, dto.Price, dto.Discount, DateTime.Now);
            return entity;
        }
        #endregion
    }
}