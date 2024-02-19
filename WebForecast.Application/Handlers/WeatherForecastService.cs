

using WeatherForecast.Domain.Entities;
using WeatherForecast.Domain.Repositories;

namespace WeatherForecast.Application.Handlers
{
    public class WeatherForecastService
    {
        private readonly IWeatherForecastRepository _forecastRepository;
        public WeatherForecastService(IWeatherForecastRepository forecastRepository) 
        {
           _forecastRepository = forecastRepository ?? throw new ArgumentNullException(nameof(forecastRepository));
        }

        public async Task<CreateWeatherForecastResponse> CreateForecast(DateTime date, double temperature, CancellationToken cancellationToken) 
        {
            var forecastAggregate = new ForecastAggregate(date, temperature);

            var response = await _forecastRepository.AddForecastAsync(forecastAggregate.GetData(), cancellationToken);

            return new(response.Id, response.Description);
        }

        public async Task<IEnumerable<ForecastData>> GetWeeklyForecastAsync(DateTime date, CancellationToken cancellationToken)
        {
            return  await _forecastRepository.GetWeeklyForecastAsync(date, cancellationToken);
        }
    }
}
