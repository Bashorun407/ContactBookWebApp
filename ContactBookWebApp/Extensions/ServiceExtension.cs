using ContactBookWebApp.Application.Services.Implementations;
using ContactBookWebApp.Application.Services.Interfaces;
using ContactBookWebApp.Domain.Entities;
using ContactBookWebApp.Infrastructure.Persistence;
using ContactBookWebApp.Infrastructure.UoW.Abstraction;
using ContactBookWebApp.Infrastructure.UoW.Implementation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;

namespace ContactBookWebApp.Extensions
{
    public static class ServiceExtension
    {
        public static void ConfigureDataBaseContext(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<ApplicationDbContext>(option => option.UseSqlServer(configuration.GetConnectionString("Default")));
        public static void ResolveDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IContactService, ContactService>();
            services.AddScoped<IAuthenticationService, AuthenticationService>();
        }


        public static void ConfigureIdentity(this IServiceCollection services)
        {
            var builder = services.AddIdentity<UserEntity, IdentityRole>(o =>
            {
                o.Password.RequireDigit = true;
                o.Password.RequireLowercase = false;
                o.Password.RequireUppercase = false;
                o.Password.RequireNonAlphanumeric = false;
                o.Password.RequiredLength = 10;
                o.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();
        }
    }
}
