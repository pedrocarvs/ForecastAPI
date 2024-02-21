using Microsoft.EntityFrameworkCore;

namespace WeatherForecast.Infra.Context
{
    public class WeatherForecastDbContext : DbContext
    {
        public WeatherForecastDbContext(DbContextOptions<WeatherForecastDbContext> options) : base(options)
        {

        }

        public DbSet<Domain.Entities.ForecastData> Forecasts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(GetType().Assembly);
        }
    }
}
