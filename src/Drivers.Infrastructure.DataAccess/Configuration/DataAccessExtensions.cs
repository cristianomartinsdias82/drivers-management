using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Drivers.Infrastructure.DataAccess.Configuration;

public static class DataAccessExtensions
{
    public static IServiceCollection AddDataAccess(this IServiceCollection serviceCollection, IConfiguration configuration)
        => serviceCollection.AddDbContext<DriversDbContext>(options =>
        {
            options.UseSqlServer(configuration["ConnectionStrings:DriversManagement"]);
            options.EnableSensitiveDataLogging();
        });
}