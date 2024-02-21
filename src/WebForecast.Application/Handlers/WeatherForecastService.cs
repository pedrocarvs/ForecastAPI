

using System.Threading;
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

        public async Task<CreateWeatherForecastResponse> Create(DateTime date, double temperature, CancellationToken cancellationToken) 
        {
            var forecastAggregate = new ForecastAggregate(date, temperature);

            await _forecastRepository.SaveAsync(forecastAggregate, cancellationToken);

           var forecastData = forecastAggregate.GetData();

            return new(forecastData.Id, forecastData.Description);
        }

        public async Task Update(Guid id, Action<ForecastAggregate> action, CancellationToken cancellationToken) 
        {
            var forecastAggregate = await _forecastRepository.GetForecastAsync(id, cancellationToken);

            await Update(forecastAggregate, action, cancellationToken);
        }

        public async Task Update(ForecastAggregate forecast, Action<ForecastAggregate> action, CancellationToken cancellationToken) 
        {
            try
            {
                action(forecast);
                await _forecastRepository.SaveAsync(forecast, cancellationToken);
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
