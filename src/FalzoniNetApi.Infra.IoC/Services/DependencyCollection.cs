using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using FalzoniNetApi.Infra.Data.Context;
using FalzoniNetApi.Utils.Helpers;
using FalzoniNetApi.Infra.Data.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using FalzoniNetApi.Domain.Interfaces.Services.Register;
using FalzoniNetApi.Domain.Interfaces.Services.Stock;
using FalzoniNetApi.Service.Configuration;
using FalzoniNetApi.Service.Register;
using FalzoniNetApi.Service.Stock;
using FalzoniNetApi.Domain.Interfaces.Repositories.Base;
using FalzoniNetApi.Infra.Data.Repositories.Base;
using FalzoniNetApi.Domain.Interfaces.Repositories.Register;
using FalzoniNetApi.Domain.Interfaces.Repositories.Stock;
using FalzoniNetApi.Infra.Data.Repositories.Register;
using FalzoniNetApi.Infra.Data.Repositories.Stock;

namespace FalzoniNetApi.Infra.IoC.Services
{
    public static class DependencyCollection
    {
        public static IServiceCollection AddDatabaseConfiguration(this IServiceCollection services, ServiceLifetime lifetime)
        {
            services.AddDbContext<FalzoniNetApiContext>(options =>
            {
                switch(ConfigurationHelper.Provider)
                {
                    case "InMemory":
                        options.UseInMemoryDatabase("FalzoniNet");
                        break;
                    case "SqlServer":
                    default:
                        options.UseSqlServer(ConfigurationHelper.ConnectionString!);
                        break;
                }
            }, lifetime);

            services.AddDatabaseDeveloperPageExceptionFilter();

            return services;
        }

        public static IServiceCollection AddIdentityConfiguration(this IServiceCollection services)
        {
            services.AddDefaultIdentity<ApplicationUser>(options =>
            {
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
            })
            .AddRoles<ApplicationRole>()
            .AddRoleManager<RoleManager<ApplicationRole>>()
            .AddSignInManager<SignInManager<ApplicationUser>>()
            .AddEntityFrameworkStores<FalzoniNetApiContext>();

            return services;
        }

        public static IServiceCollection AddAuthenticationConfiguration(this IServiceCollection services)
        {
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })// Optional: Add Social Login
            //
            //.AddGoogle(options =>
            //{
            //    options.ClientId = ConfigurationHelper.GoogleAuthConfiguration.ClientId;
            //    options.ClientSecret = ConfigurationHelper.GoogleAuthConfiguration.ClientSecret;
            //})
            //.AddFacebook(options =>
            //{
            //    options.ClientId = ConfigurationHelper.FacebookAuthConfiguration.ClientId;
            //    options.ClientSecret = ConfigurationHelper.FacebookAuthConfiguration.ClientSecret;
            //})
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = ConfigurationHelper.TokenConfiguration.Audience,
                    ValidIssuer = ConfigurationHelper.TokenConfiguration.Issuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigurationHelper.TokenConfiguration.SecretKey!))
                };
            });

            return services;
        }

        public static IServiceCollection AddUnitOfWork(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<UserService>();
            services.AddScoped<AccountService>();

            return services;
        }
    }
}
