using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SportClub.Application.Common.Logging;
using SportClub.Application.Features.User.Interfaces;
using SportClub.Infrastructure.Persistence;
using SportClub.Infrastructure.Persistence.Repositories;

namespace NewsAggregator.Infrastructure.Extensions
{
    public static class ServiceCollectionExtensions
    {

        public static IServiceCollection AddMediatR(this IServiceCollection services)
        {
            // Add services
            services.AddMediatR(cfg => { cfg.RegisterServicesFromAssembly(typeof(SportClub.Application.Ping).Assembly); });

#if DEBUG
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(LoggingBehavior<,>));
#endif

            return services;
        }

        public static IServiceCollection Persistence(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlite(connectionString));

            // Register the repository
            services.AddScoped<IUserRepository, ApplicationUserRepository>();

            return services;
        }
    }
}
