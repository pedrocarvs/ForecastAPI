using MediatR;

namespace WeatherForecast.Application.Handlers
{
    public record CreateWeatherForecastResponse : IRequest
    {
        public Guid _Id { get; set; }
        public string? _Description { get; set; }
        public CreateWeatherForecastResponse(Guid Id, string? Description)
        {
            _Id = Id;
            _Description = Description;
        }
    }
}