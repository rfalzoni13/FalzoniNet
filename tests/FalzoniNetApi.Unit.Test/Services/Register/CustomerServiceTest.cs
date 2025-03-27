using FalzoniNetApi.Data.Seed.Register;
using FalzoniNetApi.Domain.Dtos.Register;
using FalzoniNetApi.Domain.Entities.Register;
using FalzoniNetApi.Domain.Interfaces.Repositories.Base;
using FalzoniNetApi.Domain.Interfaces.Repositories.Register;
using FalzoniNetApi.Domain.Interfaces.Services.Register;
using FalzoniNetApi.Service.Register;
using Moq;

namespace FalzoniNetApi.Unit.Test;

public class CustomerServiceTest : BaseServiceTest<Customer, CustomerDTO>
{
    private Guid _idExampleOne;
    private Guid _idExampleTwo;
    private Guid _idExampleThree;

    public CustomerServiceTest()
    {
        _idExampleOne = Guid.Parse("d19223f3-ad4b-4c03-8bf7-fe660013631d");
        _idExampleTwo = Guid.Parse("82715ff4-89e3-48ac-a10c-d09c2aae4a97");
        _idExampleThree = Guid.Parse("8d949c46-a7b4-4ddc-9bae-f7331c441948");
    }

    [TestCase(TestName = "Should be success when service get all customers")]
    public override void Test_GetAll_Success()
    {
        base.Test_GetAll_Success();
    }

    [TestCase("d19223f3-ad4b-4c03-8bf7-fe660013631d", TestName = "Should be success when service get customer by id")]
    [TestCase("82715ff4-89e3-48ac-a10c-d09c2aae4a97", TestName = "Should be success when service get customer by id")]
    [TestCase("8d949c46-a7b4-4ddc-9bae-f7331c441948", TestName = "Should be success when service get customer by id")]
    public override void Test_Get_Success(Guid id)
    {
        base.Test_Get_Success(id);
    }

    [TestCase(TestName = "Should be success when service create customer")]
    public override void Test_Create_Success()
    {
        base.Test_Create_Success();
    }

    [TestCase(TestName = "Should be success when service update customer")]
    public override void Test_Update_Success()
    {
        base.Test_Update_Success();
    }

    [TestCase(TestName = "Should be success when service delete customer")]
    public override void Test_Delete_Success()
    {
        base.Test_Delete_Success();
    }

    #region Overriding Methods
    protected override ICustomerService GetService()
    {
        IUnitOfWork unitOfWork = GetUnitOfWork();
        ICustomerRepository repository = GetRepository();

        return new CustomerService(repository, unitOfWork);
    }

    protected override ICustomerRepository GetRepository()
    {
        var mockRepository = new Mock<ICustomerRepository>();
        var data = GetData();

        mockRepository.Setup(x => x.GetAll()).Returns(data);
        mockRepository.Setup(x => x.Get(_idExampleOne)).Returns(data.FirstOrDefault(x => x.Id == _idExampleOne));
        mockRepository.Setup(x => x.Get(_idExampleTwo)).Returns(data.FirstOrDefault(x => x.Id == _idExampleTwo));
        mockRepository.Setup(x => x.Get(_idExampleThree)).Returns(data.FirstOrDefault(x => x.Id == _idExampleThree));
        return mockRepository.Object;
    }

    protected override List<Customer> GetData()
    {
        return CustomerDataSeed.GetData();
    }

    protected override CustomerDTO SetObject()
    {
        return new CustomerDTO
        {
            Id = Guid.NewGuid(),
            Name = "Customer Test",
            Document = "789.654.122-01",
            Created = DateTime.Now,
            Modified = DateTime.Now
        };
    }
    #endregion
}
