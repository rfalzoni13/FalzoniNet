using FalzoniNetApi.Infra.Data.Identity;
using FalzoniNetApi.Utils.Helpers;

namespace FalzoniNetApi.Data.Seed.Identity
{
    public class IdentityDataSeed
    {
        public static List<ApplicationUser> GetUserData()
        {
            return new List<ApplicationUser>
            {
                new ApplicationUser
                {
                    Id = Guid.Parse("a6985269-1152-4738-ad4d-bc0f8aa51647").ToString(),
                    FullName = "User Test One",
                    UserName = "usertestone",
                    PasswordHash = PasswordHelper.GeneratePassword("UserTest123"),
                    Email = "usertestone@test.com",
                    PhoneNumber = "(11) 99999-8888",
                    PhoneNumberConfirmed = false,
                    EmailConfirmed = true
                },
                new ApplicationUser
                {
                    Id = Guid.Parse("9826df12-fd95-4b42-9785-f9239763ceae").ToString(),
                    FullName = "User Test Two",
                    UserName = "usertesttwo",
                    PasswordHash = PasswordHelper.GeneratePassword("UserTest321"),
                    Email = "usertesttwo@test.com",
                    PhoneNumber = "(21) 98888-7777",
                    PhoneNumberConfirmed = true,
                    EmailConfirmed = false
                },
                new ApplicationUser
                {
                    Id = Guid.Parse("57e074f3-5f90-4a89-b796-17079f4590a9").ToString(),
                    FullName = "User Test Three",
                    UserName = "usertestthree",
                    PasswordHash = PasswordHelper.GeneratePassword(),
                    Email = "usertestthree@test.com",
                    PhoneNumber = "(31) 97777-6666",
                    PhoneNumberConfirmed = false,
                    EmailConfirmed = true
                },
                new ApplicationUser
                {
                    Id = Guid.Parse("9906cbce-82b8-4450-acf0-dcda87e0d11e").ToString(),
                    FullName = "User Test Four",
                    UserName = "usertestfour",
                    Email = "usertestfour@test.com",
                    PhoneNumber = "(41) 96666-5555",
                    PhoneNumberConfirmed = true,
                    EmailConfirmed = false,
                },
                new ApplicationUser
                {
                    Id = Guid.Parse("d40b6992-c3ff-42d8-9623-ab00766062ce").ToString(),
                    FullName = "User Test Five",
                    UserName = "usertestfive",
                    Email = "usertestfive@test.com",
                    PhoneNumber = "(51) 97777-9999",
                    PhoneNumberConfirmed = false,
                    EmailConfirmed = true,
                }
            };
        }
    }
}
