using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace WeatherForecast.Application.Handlers
{
    public record CreateWeatherForecastRequest(DateTime Date, int Temperature) : IRequest<CreateWeatherForecastResponse>;
}
