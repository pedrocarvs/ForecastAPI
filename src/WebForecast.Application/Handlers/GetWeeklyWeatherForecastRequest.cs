using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;
using WeatherForecast.Domain.Entities;

namespace WeatherForecast.Application.Handlers
{
    public record GetWeeklyWeatherForecastRequest(DateTime startDate) : IRequest<IEnumerable<ForecastData>>;
}
