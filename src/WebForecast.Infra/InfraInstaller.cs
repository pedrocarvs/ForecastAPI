
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WeatherForecast.Domain.Repositories;
using WeatherForecast.Infra.Context;
using WeatherForecast.Infra.WeatherForecast;

namespace WeatherForecast.Infra
{
    public static class InfraInstaller
    {
        public static IServiceCollection AddInfraServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IWeatherForecastRepository, WeatherForecastRepository>();

            var options = configuration.GetRequiredSection(MySqlOptions.Section).Get<MySqlOptions>();
            var connectionString = options.ConnectionString
                .Replace("{username}", options.UserName)
                .Replace("{password}", options.Password);

            services.AddDbContext<WeatherForecastDbContext>(options =>
                options.UseInMemoryDatabase(connectionString));
            
            return services;
        }
    }
}
