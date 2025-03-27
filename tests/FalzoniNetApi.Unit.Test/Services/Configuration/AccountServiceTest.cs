using FalzoniNetApi.Domain.Structs.Configuration;
using FalzoniNetApi.Infra.Data.Identity;
using FalzoniNetApi.Service.Configuration;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using Microsoft.Extensions.Configuration;
using FalzoniNetApi.Data.Seed.Configuration;
using FalzoniNetApi.Utils.Helpers;
using NUnit.Framework.Legacy;

namespace FalzoniNetApi.Unit.Test;

[TestFixture]
public class AccountServiceTest
{
    private IConfiguration _configuration;
    private AccountService _service;

    [SetUp]
    public void Setup()
    {
        _configuration = TestEnvironment.LoadEnvironmentTest(@"appsettings.Unit.Test.json");

        ConfigurationHelper.LoadConfiguration(_configuration);

        _service = GetService();
    }

    [TestCase("usertestone", "Test12345", TestName = "Should be success when login is submited")]
    [TestCase("usertesttwo", "Test54321", TestName = "Should be success when login is submited")]
    [TestCase("usertestthree", "Test123123", TestName = "Should be success when login is submited")]
    public async Task Test_Login_Success(string userName, string password)
    {
        LoginData data = new LoginData(userName, password);

        BearerToken token = await _service.GenerateTokenAsync(data);

        ClassicAssert.IsNotNull(token);
        ClassicAssert.IsNotNull(token.Token);
    }

    #region Private Methods
    private AccountService GetService()
    {
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

        Mock<SignInManager<ApplicationUser>> mockSignInManager =
            new Mock<SignInManager<ApplicationUser>>(
                mockUserManager.Object,
                new Mock<IHttpContextAccessor>().Object,
                new Mock<IUserClaimsPrincipalFactory<ApplicationUser>>().Object,
                new Mock<IOptions<IdentityOptions>>().Object,
                new Mock<ILogger<SignInManager<ApplicationUser>>>().Object,
                new Mock<IAuthenticationSchemeProvider>().Object,
                new Mock<IUserConfirmation<ApplicationUser>>().Object);

        mockSignInManager.Setup(x => x.PasswordSignInAsync("usertestone", "Test12345", false, false)).ReturnsAsync(SignInResult.Success);
        mockSignInManager.Setup(x => x.PasswordSignInAsync("usertesttwo", "Test54321", false, false)).ReturnsAsync(SignInResult.Success);
        mockSignInManager.Setup(x => x.PasswordSignInAsync("usertestthree", "Test123123", false, false)).ReturnsAsync(SignInResult.Success);

        return new AccountService(mockSignInManager.Object);
    }
    #endregion
}
