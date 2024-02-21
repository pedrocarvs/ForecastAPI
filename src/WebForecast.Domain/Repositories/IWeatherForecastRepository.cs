
using WeatherForecast.Domain.Entities;

namespace WeatherForecast.Domain.Repositories
{
    public interface IWeatherForecastRepository
    {
        Task<ForecastAggregate> GetForecastAsync(Guid id, CancellationToken cancellationToken);
        Task<List<ForecastData>> GetWeeklyForecastAsync(DateTime date, CancellationToken cancellationToken);
        Task SaveAsync(ForecastAggregate forecast, CancellationToken cancellationToken);
    }
}
