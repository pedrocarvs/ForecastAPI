using Microsoft.EntityFrameworkCore;
using WeatherForecast.Domain.Entities;
using WeatherForecast.Domain.Repositories;
using WeatherForecast.Infra.Context;

namespace WeatherForecast.Infra.WeatherForecast
{
    public class WeatherForecastRepository : IWeatherForecastRepository
    {
        private readonly WeatherForecastDbContext _dbContext;

        private readonly DbSet<ForecastData> _forecasts;
        public WeatherForecastRepository(WeatherForecastDbContext dbContext)
        {
            _dbContext = dbContext;
            _forecasts = _dbContext.Set<ForecastData>();
        }

        public async Task<ForecastAggregate> GetForecastAsync(Guid id, CancellationToken cancellationToken)
        {
            var forecastData = await _forecasts.FirstOrDefaultAsync(d => d.Id.Equals(id), cancellationToken);

            return Inflate(forecastData!);
        }

        private ForecastAggregate Inflate(ForecastData forecastData)
        {
            return new ForecastAggregate(forecastData);
        }

        public async Task<List<ForecastData>> GetWeeklyForecastAsync(DateTime startDate, CancellationToken cancellationToken)
        {
            var endDate = DateTime.Today.AddDays(7);

            return await _forecasts.Where(f => f.Date.Date >= startDate && f.Date.Date <= endDate.Date).ToListAsync(cancellationToken);
        }

        public async Task SaveAsync(ForecastAggregate forecast, CancellationToken cancellationToken)
        {
            var forecastData = forecast.GetData();

            if (forecast.IsDeleted)
            {
                _forecasts.Remove(forecastData);
            }
            else {

            forecastData.Updated = DateTime.UtcNow;

                if (forecastData.State == ForecastState.Created) 
                { 
                    forecastData.Created = DateTime.UtcNow;
                   await _dbContext.AddAsync(forecastData, cancellationToken);
                }
            }
           await _dbContext.SaveChangesAsync();
        }
    }
}