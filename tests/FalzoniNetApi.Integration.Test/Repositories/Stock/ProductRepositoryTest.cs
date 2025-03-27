using FalzoniNetApi.Data.Seed.Stock;
using FalzoniNetApi.Domain.Entities.Stock;
using FalzoniNetApi.Domain.Interfaces.Repositories.Stock;
using FalzoniNetApi.Infra.IoC.Enum;
using FalzoniNetApi.Infra.IoC.Services;
using FalzoniNetApi.Integration.Test.Repositories.Base;

namespace FalzoniNetApi.Integration.Test.Repositories.Stock
{
    [Collection("IntegrationTest")]
    public class ProductRepositoryTest : BaseRepositoryTest<Product>
    {
        private List<Product>? _products;

        public ProductRepositoryTest()
            :base()
        {
            _repository = DependencyService<IProductRepository>.GetRequiredService(EServiceType.Repository)
                ?? throw new ArgumentNullException(nameof(IProductRepository));
        }

        [Fact(DisplayName = "Should be success when get all products")]
        public override void Test_GetAll_Success()
        {
            base.Test_GetAll_Success();
        }

        [Theory(DisplayName = "Should be success when get product by id", DisableDiscoveryEnumeration = true)]
        [InlineData("ebce33b1-8b7a-4d1b-bccf-e61c5d3a9086")]
        [InlineData("b2ec1e29-7c54-49d8-ad70-45e04cb3c90f")]
        [InlineData("4f4ba054-7867-4c1e-99dc-ea9dc01b3d68")]
        public override void Test_Get_Success(Guid id)
        {
            base.Test_Get_Success(id);
        }

        [Fact(DisplayName = "Should be success when create product")]
        public override void Test_Create_Success()
        {
            base.Test_Create_Success();
        }

        [Theory(DisplayName = "Should be success when update product", DisableDiscoveryEnumeration = true)]
        [InlineData("1899993e-6b5c-4272-b4d4-75a0ce3844a7")]
        [InlineData("5fe6f7f2-d957-43fb-8222-2da3424103b5")]
        [InlineData("0fda3264-bad3-460a-ace7-8a065405ce93")]
        public override void Test_Update_Success(Guid id)
        {
            base.Test_Update_Success(id);
        }

        [Theory(DisplayName = "Should be success when delete product", DisableDiscoveryEnumeration = true)]
        [InlineData("285403e0-1ee6-4ef2-b58d-9fffe5be9aa3")]
        [InlineData("0d43a853-cf03-425a-822b-3a76abe640ab")]
        [InlineData("ab9f476d-5311-4203-a134-33fea25ea055")]
        public override void Test_Delete_Success(Guid id)
        {
            base.Test_Delete_Success(id);
        }

        #region Overriding Methods
        protected override void LoadData()
        {
            _products = ProductDataSeed.GetData();

            this.context!.Set<Product>().AddRange(_products);

            this.context!.SaveChanges();
        }

        protected override Product CreateObject()
        {
            return new Product(Guid.NewGuid(), "Test for Product", 100.00M, 0, DateTime.Now);
        }

        protected override Product UpdateObject(ref Product obj)
        {
            obj!.Update("New Product", 599.99M, 10.00M, DateTime.Now);
            return obj;
        }
        #endregion
    }
}
