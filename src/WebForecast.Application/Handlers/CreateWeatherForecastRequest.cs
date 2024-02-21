
using MediatR;

namespace WeatherForecast.Application.Handlers
{
    public record CreateWeatherForecastRequest(DateTime Date, int Temperature) : IRequest<CreateWeatherForecastResponse>;
}
