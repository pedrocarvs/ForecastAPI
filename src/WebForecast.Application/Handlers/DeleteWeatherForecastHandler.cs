
using MediatR;

namespace WeatherForecast.Application.Handlers
{
    public class DeleteWeatherForecastHandler : IRequestHandler<DeleteWeatherForecastRequest>
    {
        private readonly WeatherForecastService _service;

        public DeleteWeatherForecastHandler(WeatherForecastService service)
        {
            _service = service;
        }
        public Task Handle(DeleteWeatherForecastRequest request, CancellationToken cancellationToken)
        {
            return _service.Update(request.Id, f=> f.Delete(), cancellationToken);
        }
    }
}
