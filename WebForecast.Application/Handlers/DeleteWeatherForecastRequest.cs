using MediatR;

namespace WeatherForecast.Application.Handlers
{
    public record DeleteWeatherForecastRequest(Guid Id) : IRequest
    { 
    }
}