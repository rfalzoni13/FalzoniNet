using FalzoniNetApi.Data.Seed.Identity;
using FalzoniNetApi.Data.Seed.Register;
using FalzoniNetApi.Domain.Dtos.Identity;
using FalzoniNetApi.Domain.Entities.Register;
using FalzoniNetApi.Infra.Data.Identity;
using FalzoniNetApi.Service.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using NUnit.Framework.Legacy;

namespace FalzoniNetApi.Unit.Test;

[TestFixture]
public class UserServiceTest
{
    private UserService _service;

    [SetUp]
    public void Setup()
    {
        _service = GetService();
    }

    [TestCase(TestName = "Should be success when service get all users")]
    public void Test_GetAll_Success()
    {
        List<ApplicationUserDTO> list = _service.GetAll();

        ClassicAssert.NotNull(list);
        Assert.That(list.Count, Is.EqualTo(5));
    }

    [TestCase("a6985269-1152-4738-ad4d-bc0f8aa51647", TestName = "Should be success when service get user by id")]
    [TestCase("a6985269-1152-4738-ad4d-bc0f8aa51647", TestName = "Should be success when service get user by id")]
    [TestCase("a6985269-1152-4738-ad4d-bc0f8aa51647", TestName = "Should be success when service get user by id")]
    public async Task Test_Get_Success(Guid id)
    {
        ApplicationUserDTO? user = await _service.GetByIdAsync(id);

        ClassicAssert.NotNull(user);
    }

    [TestCase(TestName = "Should be success when service create user")]
    public async Task Test_Create_Success()
    {
        ApplicationUserDTO user = new ApplicationUserDTO
        {
            FullName = "Test User",
            UserName = "usertest",
            Email = "user@test.com",
            PhoneNumber = "(21) 98888-7777"
        };

        await _service.CreateAsync(user);
    }

    [TestCase(TestName = "Should be success when service update user")]
    public async Task Test_Update_Success()
    {
        ApplicationUserDTO user = new ApplicationUserDTO
        {
            Id = Guid.NewGuid(),
            FullName = "Update User",
            UserName = "userupdated",
            Email = "update@test.com",
            PhoneNumber = "(21) 98888-7777"
        };

        await _service.CreateAsync(user);
    }

    [TestCase("a6985269-1152-4738-ad4d-bc0f8aa51647", TestName = "Should be success when service delete user")]
    [TestCase("a6985269-1152-4738-ad4d-bc0f8aa51647", TestName = "Should be success when service delete user")]
    [TestCase("a6985269-1152-4738-ad4d-bc0f8aa51647", TestName = "Should be success when service delete user")]
    public async Task Test_Delete_Success(Guid id)
    {
        await _service.DeleteAsync(id);
    }

    #region Private Methods
    private UserService GetService()
    {
        List<ApplicationUser> data = GetData();

        Mock<UserManager<ApplicationUser>> mockUserManager = new Mock<UserManager<ApplicationUser>>(
            new Mock<IUserStore<ApplicationUser>>().Object,
            new Mock<IOptions<IdentityOptions>>().Object,
            new Mock<IPasswordHasher<ApplicationUser>>().Object,
            new IUserValidator<ApplicationUser>[0],
            new IPasswordValidator<ApplicationUser>[0],
            new Mock<ILookupNormalizer>().Object,
            new Mock<IdentityErrorDescriber>().Object,
            new Mock<IServiceProvider>().Object,
            new Mock<ILogger<UserManager<ApplicationUser>>>().Object);

        mockUserManager.Setup(x => x.Users).Returns(data.AsQueryable());
        
        mockUserManager.Setup(x => x.FindByIdAsync("a6985269-1152-4738-ad4d-bc0f8aa51647")).ReturnsAsync(data.FirstOrDefault(x => x.Id == "a6985269-1152-4738-ad4d-bc0f8aa51647"));
        mockUserManager.Setup(x => x.FindByIdAsync("9826df12-fd95-4b42-9785-f9239763ceae")).ReturnsAsync(data.FirstOrDefault(x => x.Id == "9826df12-fd95-4b42-9785-f9239763ceae"));
        mockUserManager.Setup(x => x.FindByIdAsync("57e074f3-5f90-4a89-b796-17079f4590a9")).ReturnsAsync(data.FirstOrDefault(x => x.Id == "57e074f3-5f90-4a89-b796-17079f4590a9"));

        mockUserManager.Setup(x => x.AddPasswordAsync(It.IsAny<ApplicationUser>(), It.IsAny<string>())).ReturnsAsync(IdentityResult.Success);
        mockUserManager.Setup(x => x.CreateAsync(It.IsAny<ApplicationUser>())).ReturnsAsync(IdentityResult.Success);
        mockUserManager.Setup(x => x.UpdateAsync(It.IsAny<ApplicationUser>())).ReturnsAsync(IdentityResult.Success);
        mockUserManager.Setup(x => x.DeleteAsync(It.IsAny<ApplicationUser>())).ReturnsAsync(IdentityResult.Success);


        return new UserService(mockUserManager.Object);
    }

    private List<ApplicationUser> GetData()
    {
        return IdentityDataSeed.GetUserData();;
    }
    #endregion
}
