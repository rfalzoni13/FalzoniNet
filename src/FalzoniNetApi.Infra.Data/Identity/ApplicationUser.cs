using Microsoft.AspNetCore.Identity;

namespace FalzoniNetApi.Infra.Data.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string? FullName { get; set; }
    }
}
