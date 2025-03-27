using FalzoniNetApi.Data.Seed.Stock;
using FalzoniNetApi.Domain.Dtos.Stock;
using FalzoniNetApi.Domain.Entities.Stock;
using FalzoniNetApi.Domain.Interfaces.Repositories.Base;
using FalzoniNetApi.Domain.Interfaces.Repositories.Stock;
using FalzoniNetApi.Domain.Interfaces.Services.Stock;
using FalzoniNetApi.Service.Stock;
using Moq;

namespace FalzoniNetApi.Unit.Test;

public class ProductServiceTest : BaseServiceTest<Product, ProductDTO>
{
    private Guid _idExampleOne;
    private Guid _idExampleTwo;
    private Guid _idExampleThree;

    public ProductServiceTest()
    {
        _idExampleOne = Guid.Parse("4f4ba054-7867-4c1e-99dc-ea9dc01b3d68");
        _idExampleTwo = Guid.Parse("b2ec1e29-7c54-49d8-ad70-45e04cb3c90f");
        _idExampleThree = Guid.Parse("ab9f476d-5311-4203-a134-33fea25ea055");
    }

    [TestCase(TestName = "Should be success when service get all products")]
    public override void Test_GetAll_Success()
    {
        base.Test_GetAll_Success();
    }

    [TestCase("4f4ba054-7867-4c1e-99dc-ea9dc01b3d68", TestName = "Should be success when service get product by id")]
    [TestCase("b2ec1e29-7c54-49d8-ad70-45e04cb3c90f", TestName = "Should be success when service get product by id")]
    [TestCase("ab9f476d-5311-4203-a134-33fea25ea055", TestName = "Should be success when service get product by id")]
    public override void Test_Get_Success(Guid id)
    {
        base.Test_Get_Success(id);
    }

    [TestCase(TestName = "Should be success when service create product")]
    public override void Test_Create_Success()
    {
        base.Test_Create_Success();
    }

    [TestCase(TestName = "Should be success when service update product")]
    public override void Test_Update_Success()
    {
        base.Test_Update_Success();
    }

    [TestCase(TestName = "Should be success when service delete product")]
    public override void Test_Delete_Success()
    {
        base.Test_Delete_Success();
    }
    #region Overriding Methods
    protected override IProductService GetService()
    {
        IUnitOfWork unitOfWork = GetUnitOfWork();
        IProductRepository repository = GetRepository();

        return new ProductService(repository, unitOfWork);
    }

    protected override IProductRepository GetRepository()
    {
        var mockRepository = new Mock<IProductRepository>();
        var data = GetData();

        mockRepository.Setup(x => x.GetAll()).Returns(data);
        mockRepository.Setup(x => x.Get(_idExampleOne)).Returns(data.FirstOrDefault(x => x.Id == _idExampleOne));
        mockRepository.Setup(x => x.Get(_idExampleTwo)).Returns(data.FirstOrDefault(x => x.Id == _idExampleTwo));
        mockRepository.Setup(x => x.Get(_idExampleThree)).Returns(data.FirstOrDefault(x => x.Id == _idExampleThree));
        return mockRepository.Object;
    }

    protected override List<Product> GetData()
    {
        return ProductDataSeed.GetData();
    }

    protected override ProductDTO SetObject()
    {
        return new ProductDTO
        {
            Id = Guid.NewGuid(),
            Name = "Product Test",
            Price = 199.99M,
            Discount = 5,
            Created = DateTime.Now,
            Modified = DateTime.Now
        };
    }
    #endregion
}
