using FalzoniNetApi.Data.Seed.Register;
using FalzoniNetApi.Domain.Entities.Register;
using FalzoniNetApi.Domain.Interfaces.Repositories.Register;
using FalzoniNetApi.Infra.IoC.Enum;
using FalzoniNetApi.Infra.IoC.Services;
using FalzoniNetApi.Integration.Test.Repositories.Base;

namespace FalzoniNetApi.Integration.Test.Repositories.Register
{
    [Collection("IntegrationTest")]
    public class CustomerRepositoryTest : BaseRepositoryTest<Customer>
    {
        private List<Customer>? _customers;

        public CustomerRepositoryTest()
            :base()
        {
            _repository = DependencyService<ICustomerRepository>.GetRequiredService(EServiceType.Repository) 
                ?? throw new ArgumentNullException(nameof(ICustomerRepository));
        }

        [Fact(DisplayName = "Should be success when get all customers")]
        public override void Test_GetAll_Success()
        {
            base.Test_GetAll_Success();
        }

        [Theory(DisplayName = "Should be success when get customer by id", DisableDiscoveryEnumeration = true)]
        [InlineData("ccad702d-f0dc-46e7-9327-b35a9097fd75")]
        [InlineData("aa07c32c-e651-486f-b61b-00075c294eb4")]
        [InlineData("82715ff4-89e3-48ac-a10c-d09c2aae4a97")]
        public override void Test_Get_Success(Guid id)
        {
            base.Test_Get_Success(id);
        }

        [Fact(DisplayName = "Should be success when create customer")]
        public override void Test_Create_Success()
        {
            base.Test_Create_Success();
        }

        [Theory(DisplayName = "Should be success when update customer", DisableDiscoveryEnumeration = true)]
        [InlineData("ac883bff-8895-4e78-bf0d-dd068f028cf7", TestDisplayName = "Test update 1")]
        [InlineData("ad018eff-dc47-4295-9f87-be35e5f7580c", TestDisplayName = "Test update 2")]
        [InlineData("2c3c536c-7ad4-4677-a5dd-f8dbb875f435", TestDisplayName = "Test update 3")]
        public override void Test_Update_Success(Guid id)
        {
            base.Test_Update_Success(id);
        }

        [Theory(DisplayName = "Should be success when delete customer", DisableDiscoveryEnumeration = true)]
        [InlineData("d19223f3-ad4b-4c03-8bf7-fe660013631d", TestDisplayName = "Test delete 1")]
        [InlineData("49b403c3-d0e5-47cc-a794-bf3ba6337e00", TestDisplayName = "Test delete 2")]
        [InlineData("8d949c46-a7b4-4ddc-9bae-f7331c441948", TestDisplayName = "Test delete 3")]
        public override void Test_Delete_Success(Guid id)
        {
            base.Test_Delete_Success(id);
        }

        #region Overriding Methods
        protected override void LoadData()
        {
            _customers = CustomerDataSeed.GetData();

            this.context!.Set<Customer>().AddRange(_customers);

            this.context!.SaveChanges();
        }

        protected override Customer CreateObject()
        {
            return new Customer(Guid.NewGuid(), "Test for Customer", "123.456.789-00", DateTime.Now);
        }

        protected override Customer UpdateObject(ref Customer obj)
        {
            obj!.Update("New Name", "123.456.789-00", DateTime.Now);
            return obj;
        }
        #endregion
    }
}
