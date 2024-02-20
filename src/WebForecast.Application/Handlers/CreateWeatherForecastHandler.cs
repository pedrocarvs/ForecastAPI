using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using MediatR;
using WeatherForecast.Domain.Entities;
using WeatherForecast.Domain.Repositories;

namespace WeatherForecast.Application.Handlers
{
    public class CreateWeatherForecastHandler : IRequestHandler<CreateWeatherForecastRequest, CreateWeatherForecastResponse>
    {
        private readonly WeatherForecastService _service;

        public CreateWeatherForecastHandler(WeatherForecastService service)
        {
            _service = service;
        }

        public async Task<CreateWeatherForecastResponse> Handle(CreateWeatherForecastRequest request, CancellationToken cancellationToken)
        {
           return await _service.Create(request.Date, request.Temperature, f => f.Create(), cancellationToken);
        }
    }
}
