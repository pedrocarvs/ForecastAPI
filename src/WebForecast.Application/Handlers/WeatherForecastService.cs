

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

        public async Task<CreateWeatherForecastResponse> Create(DateTime date, double temperature, Action<ForecastAggregate> action, CancellationToken cancellationToken) 
        {
            var forecastAggregate = new ForecastAggregate(date, temperature);

            await Update(forecastAggregate, action);

            var simpleForecast = forecastAggregate.getSimpleForecast();

            return new(simpleForecast.Id, simpleForecast.Description);
        }

        public async Task Update(Guid id, Action<ForecastAggregate> action, CancellationToken cancellationToken) 
        {
            var forecastAggregate = await _forecastRepository.GetForecastAsync(id);

            await Update(forecastAggregate, action);
        }

        public async Task Update(ForecastAggregate forecast, Action<ForecastAggregate> action) 
        {
            try
            {
                action(forecast);
                await _forecastRepository.SaveAsync(forecast);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.StackTrace);
            }
        } 

        public async Task<IEnumerable<ForecastData>> GetWeeklyForecastAsync(DateTime date, CancellationToken cancellationToken)
        {
            return  await _forecastRepository.GetWeeklyForecastAsync(date, cancellationToken);
        }
    }
}
