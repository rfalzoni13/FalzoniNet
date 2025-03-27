using FalzoniNetApi.Data.Seed.Configuration;
using FalzoniNetApi.Data.Seed.Identity;
using FalzoniNetApi.Domain.Structs.Configuration;
using FalzoniNetApi.Infra.Data.Identity;
using FalzoniNetApi.Infra.IoC.Services;
using FalzoniNetApi.Utils.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace FalzoniNetApi.Integration.Test.Identity
{
    [Collection("IntegrationTest")]
    public class IdentityTest : IDisposable
    {
        #region Attributes
        private List<ApplicationUser>? _users;
        private readonly IConfiguration _configuration;
        private readonly UserManager<ApplicationUser> _userManager;
        #endregion

        #region Constructor
        public IdentityTest()
        {
            _configuration = TestEnvironment.LoadEnvironmentTest(@"appsettings.Integration.Test.json");

            ConfigurationHelper.LoadConfiguration(_configuration);

            _userManager = DependencyService<UserManager<ApplicationUser>>.GetRequiredService(Infra.IoC.Enum.EServiceType.Identity);

            LoadData();

            new LoginData("usertestone", "Test54321");
        }
        #endregion

        #region UserManager
        [Fact(DisplayName = "Should be success when get all users")]
        public void Test_Get_All_Users()
        {
            List<ApplicationUser> users = _userManager.Users.ToList();
            
            Assert.True(users.Any());
        }

        [Theory(DisplayName = "Should be success when get user by id", DisableDiscoveryEnumeration = true)]
        [InlineData("a6985269-1152-4738-ad4d-bc0f8aa51647")]
        [InlineData("9826df12-fd95-4b42-9785-f9239763ceae")]
        public async Task Test_Get_Success(string id)
        {
            ApplicationUser? user = await _userManager.FindByIdAsync(id);

            Assert.NotNull(user);
        }

        [Fact(DisplayName = "Should be success when create user")]
        public async Task Test_Create_Success()
        {
            ApplicationUser? user = new ApplicationUser
            {
                FullName = "Test User",
                UserName = "testuser",
                Email = "username@test.com",
                PhoneNumber = "(11) 91199-9911"
            };

            IdentityResult result = await _userManager.CreateAsync(user);

            Assert.Equal(IdentityResult.Success, result);
        }

        [Theory(DisplayName = "Should be success when update user", DisableDiscoveryEnumeration = true)]
        [InlineData("d40b6992-c3ff-42d8-9623-ab00766062ce")]
        [InlineData("9906cbce-82b8-4450-acf0-dcda87e0d11e")]
        public async Task Test_Update_Success(string id)
        {
            ApplicationUser? user = await _userManager.FindByIdAsync(id);

            user!.FullName = "Updated User";
            user!.Email = "update@test.com";
            user!.PhoneNumber = "(11) 92277-9955";

            IdentityResult result = await _userManager.UpdateAsync(user);

            Assert.Equal(IdentityResult.Success, result);
        }

        [Theory(DisplayName = "Should be success when delete user", DisableDiscoveryEnumeration = true)]
        [InlineData("57e074f3-5f90-4a89-b796-17079f4590a9")]
        public async Task Test_Delete_Success(string id)
        {
            ApplicationUser? user = await _userManager.FindByIdAsync(id);

            IdentityResult result = await _userManager.DeleteAsync(user!);

            Assert.Equal(IdentityResult.Success, result);
        }

        [Theory(DisplayName = "Should be success when create password", DisableDiscoveryEnumeration = true)]
        [InlineData("d40b6992-c3ff-42d8-9623-ab00766062ce")]
        [InlineData("9906cbce-82b8-4450-acf0-dcda87e0d11e")]
        public async Task Test_Create_Password_Success(string id)
        {
            ApplicationUser? user = await _userManager.FindByIdAsync(id);

            IdentityResult result = await _userManager.AddPasswordAsync(user!, "Test12345");

            Assert.Equal(IdentityResult.Success, result);
        }

        [Theory(DisplayName = "Should be success when update existing password", DisableDiscoveryEnumeration = true)]
        [InlineData("a6985269-1152-4738-ad4d-bc0f8aa51647", "UserTest123")]
        [InlineData("9826df12-fd95-4b42-9785-f9239763ceae", "UserTest321")]
        public async Task Test_Update_Password_Success(string id, string password)
        {
            ApplicationUser? user = await _userManager.FindByIdAsync(id);

            IdentityResult result = await _userManager.ChangePasswordAsync(user!, password, "Test54321");

            Assert.Equal(IdentityResult.Success, result);
        }

        [Theory(DisplayName = "Should be success when check if e-mail is confirmed", DisableDiscoveryEnumeration = true)]
        [InlineData("a6985269-1152-4738-ad4d-bc0f8aa51647")]
        [InlineData("d40b6992-c3ff-42d8-9623-ab00766062ce")]
        public async Task Test_IsConfirmedEmail_Success(string id)
        {
            ApplicationUser? user = await _userManager.FindByIdAsync(id);

            bool isConfirmed = await _userManager.IsEmailConfirmedAsync(user!);

            Assert.True(isConfirmed);
        }

        [Theory(DisplayName = "Should be success when check if phone number is confirmed", DisableDiscoveryEnumeration = true)]
        [InlineData("9826df12-fd95-4b42-9785-f9239763ceae")]
        [InlineData("9906cbce-82b8-4450-acf0-dcda87e0d11e")]
        public async Task Test_IsConfirmedPhoneNumber_Success(string id)
        {
            ApplicationUser? user = await _userManager.FindByIdAsync(id);

            bool isConfirmed = await _userManager.IsPhoneNumberConfirmedAsync(user!);

            Assert.True(isConfirmed);
        }
        #endregion

        public void Dispose()
        {
            _userManager.Dispose();
        }

        #region Private Methods
        private void LoadData()
        {
            if(!_userManager.Users.Any())
            {
                _users = IdentityDataSeed.GetUserData();

                foreach (var user in _users)
                {
                    IdentityResult result = _userManager.CreateAsync(user).Result;
                    if (!result.Succeeded)
                        throw new ApplicationException($"Erro ao gravar ususário {result.Errors.First()}");
                }
            }
        }
    #endregion
    }
}
