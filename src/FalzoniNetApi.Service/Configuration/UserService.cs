using FalzoniNetApi.Domain.Dtos.Identity;
using FalzoniNetApi.Infra.Data.Identity;
using Microsoft.AspNetCore.Identity;
using System.Transactions;

namespace FalzoniNetApi.Service.Configuration
{
    public class UserService
    {
        #region Attributes
        private readonly UserManager<ApplicationUser> _userManager;
        #endregion

        #region Constructor
        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        #endregion

        public List<ApplicationUserDTO> GetAll()
        {
            List<ApplicationUser> list = _userManager.Users.ToList();

            return list.ToList().ConvertAll(x => new ApplicationUserDTO
            {
                Id = Guid.Parse(x.Id),
                FullName = x.FullName,
                UserName = x.UserName,
                Email = x.Email,
                PhoneNumber = x.PhoneNumber,
            });
        }

        public async Task<ApplicationUserDTO?> GetByIdAsync(Guid id)
        {
            ApplicationUser? user = await _userManager.FindByIdAsync(id.ToString());

            if (user == null) return null;

            return new ApplicationUserDTO
            {
                Id = Guid.Parse(user.Id),
                FullName = user.FullName,
                UserName = user.UserName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
            };
        }

        public async Task CreateAsync(ApplicationUserDTO userDto) 
        {
            using(var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    var user = new ApplicationUser
                    {
                        FullName = userDto.FullName,
                        UserName = userDto.UserName,
                        Email = userDto.Email,
                        PhoneNumber = userDto.PhoneNumber
                    };

                    IdentityResult result = await _userManager.CreateAsync(user);
                    
                    // Create User
                    if (result.Errors.Any()) 
                        throw new Exception(result.Errors.FirstOrDefault()!.Description);

                    // Add Password
                    result = await _userManager.AddPasswordAsync(user, userDto.Password!);
                    if (result.Errors.Any())
                        throw new Exception(result.Errors.FirstOrDefault()!.Description);

                    scope.Complete();
                }
                catch (Exception ex) 
                {
                    Console.WriteLine(ex);
                    scope.Dispose();
                    throw;
                }
            }
        }

        public async Task UpdateAsync(ApplicationUserDTO userDto)
        {
            var user = await _userManager.FindByIdAsync(userDto.Id.ToString());

            if (user == null) throw new Exception("Usuário não encontrado");

            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    user.FullName = userDto.FullName;
                    user.UserName = userDto.UserName;
                    user.Email = userDto.Email;
                    user.PhoneNumber = userDto.PhoneNumber;

                    // Update Password
                    IdentityResult result = await _userManager.UpdateAsync(user);
                    if (result.Errors.Any())
                        throw new Exception(result.Errors.FirstOrDefault()!.Description);

                    scope.Complete();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    scope.Dispose();
                    throw;
                }
            }
        }

        public async Task DeleteAsync(Guid id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());

            if (user == null) throw new Exception("Usuário não encontrado");

            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                try
                {
                    IdentityResult result = await _userManager.DeleteAsync(user);

                    if (result.Errors.Any())
                        throw new Exception(result.Errors.FirstOrDefault()!.Description);

                    scope.Complete();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    scope.Dispose();
                    throw;
                }
            }
        }
    }
}
