using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SportClub.Application.Common.Logging;
using SportClub.Application.Features.Authentication.Interfaces;
using SportClub.Application.Features.UserProfile.Interfaces;
using SportClub.Infrastructure.Identity;
using SportClub.Infrastructure.Persistence;

namespace SportClub.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            // MediatR
            services.AddMediatR(cfg => { cfg.RegisterServicesFromAssembly(typeof(SportClub.Application.Ping).Assembly); });
#if DEBUG
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
#endif

            services.AddIdentityCore<AuthenticationUser>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedAccount = false;
            })
            .AddEntityFrameworkStores<ApplicationDbContext>() // Ensure the correct namespace is included
            .AddUserManager<UserManager<AuthenticationUser>>();

            // Services
            services.AddScoped<IAuthenticationService, AuthenticationService>();
            return services;
        }

        public static IServiceCollection AddPersistence(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(connectionString));

            // Register the repository
            services.AddScoped<IProfileRepository, ProfileRepository>();

            return services;
        }
    }
}
