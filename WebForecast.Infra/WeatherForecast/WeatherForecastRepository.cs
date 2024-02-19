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
            _forecasts = _dbContext.Set<ForecastData>();
        }

        public async Task<ForecastData> AddForecastAsync(ForecastData forecast, CancellationToken cancellationToken)
        {
            dynamic response = await _forecasts.AddAsync(forecast, cancellationToken);
            _dbContext.SaveChanges();
            return response;
        }

        public async Task<List<ForecastData>> GetWeeklyForecastAsync(DateTime startDate, CancellationToken cancellationToken)
        {
            var endDate = DateTime.Today.AddDays(7);

            return await _forecasts.Where(f => f.Date.Date >= startDate && f.Date.Date <= endDate.Date).ToListAsync(cancellationToken);
        }
    }
}