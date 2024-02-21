
using MediatR;
using WeatherForecast.Domain.Entities;

namespace WeatherForecast.Application.Handlers
{
    internal class GetWeeklyWeatherForecastHandler : IRequestHandler<GetWeeklyWeatherForecastRequest, IEnumerable<ForecastData>>
    {

        private readonly WeatherForecastService _service;

        public GetWeeklyWeatherForecastHandler(WeatherForecastService service)
        {
            _service = service;
        }

        public async Task<IEnumerable<ForecastData>> Handle(GetWeeklyWeatherForecastRequest request, CancellationToken cancellationToken)
        {
            var forecasts = await _service.GetWeeklyForecastAsync(request.startDate, cancellationToken);

            return forecasts;
        }

    }
}
