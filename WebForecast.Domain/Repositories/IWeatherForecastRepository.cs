using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Domain.Entities;

namespace WeatherForecast.Domain.Repositories
{
    public interface IWeatherForecastRepository
    {
        Task<ForecastData> AddForecastAsync(ForecastData forecast, CancellationToken cancellationToken);
        Task<List<ForecastData>> GetWeeklyForecastAsync(DateTime date, CancellationToken cancellationToken);
    }
}
