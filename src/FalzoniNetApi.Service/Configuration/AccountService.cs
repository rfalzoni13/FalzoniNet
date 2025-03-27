using FalzoniNetApi.Domain.Structs.Configuration;
using FalzoniNetApi.Infra.Data.Identity;
using FalzoniNetApi.Utils.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace FalzoniNetApi.Service.Configuration
{
    public class AccountService
    {
        #region Attributs
        private readonly SignInManager<ApplicationUser> _signManager;
        #endregion

        #region Constructor
        public AccountService(SignInManager<ApplicationUser> signManager)
        {
            _signManager = signManager;
        }
        #endregion

        public async Task<BearerToken> GenerateTokenAsync(LoginData data)
        {
            string? issuer = ConfigurationHelper.TokenConfiguration.Issuer;
            string? audience = ConfigurationHelper.TokenConfiguration.Audience;
            byte[] key = Encoding.UTF8.GetBytes(ConfigurationHelper.TokenConfiguration.SecretKey!);

            try
            {
                SignInResult result = await _signManager.PasswordSignInAsync(data.UserName, data.Password, false, false);

                if (!result.Succeeded) throw new Exception("Dados de login inválidos");

                SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new[]
                    {
                    new Claim("Id", Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Sub, data.UserName),
                            new Claim(JwtRegisteredClaimNames.Email, data.UserName),
                            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                        }),
                    Expires = DateTime.UtcNow.AddMinutes(30),
                    Issuer = issuer,
                    Audience = audience,
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha512Signature)
                };

                JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
                SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
                return new BearerToken
                {
                    Token = tokenHandler.WriteToken(token),
                    ExpiresIn = tokenDescriptor.Expires,
                };
            }
            catch (Exception ex) 
            {
                Console.WriteLine(ex);
                throw;
            }
        }
    }
}
