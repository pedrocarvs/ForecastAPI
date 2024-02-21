using MediatR;
using WeatherForecast.Domain.Entities;

namespace WeatherForecast.Application.Handlers
{
    public record GetWeeklyWeatherForecastRequest(DateTime startDate) : IRequest<IEnumerable<ForecastData>>;
}
