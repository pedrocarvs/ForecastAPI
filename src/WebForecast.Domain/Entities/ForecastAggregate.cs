using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Domain.Entities
{
    public class ForecastAggregate : IAggregate<ForecastData, Guid>
    {
        public Guid Id => _forecasData.Id;

        public bool IsDeleted { get; private set; }

        private readonly ForecastData _forecasData;

        public ForecastAggregate(ForecastData forecastData) 
        { 
            if (forecastData.Temperature < -60 || forecastData.Temperature > 60)
            {
                throw new ArgumentOutOfRangeException(nameof(forecastData.Temperature), "Temperature must be between -60 and 60 degrees.");
            }

            if (forecastData.Date < DateTime.Now)
            {
                throw new ArgumentException("ForecastData date cannot be the past.");
            }

            _forecasData = forecastData ?? throw new ArgumentNullException(nameof(forecastData));
        }

        public ForecastAggregate(DateTime date, double temperature)
        {
            if (temperature < -60 || temperature > 60)
            {
                throw new ArgumentOutOfRangeException(nameof(temperature), "Temperature must be between -60 and 60 degrees.");
            }

            if (date < DateTime.Now)
            {
                throw new ArgumentException("ForecastData date cannot be the past.");
            }

            var forecastData = new ForecastData
            {
                Id = Guid.NewGuid(),
                Created = DateTimeOffset.UtcNow,
                Updated = DateTimeOffset.UtcNow,
                State = ForecastState.Created,
                Date = date,
                Temperature = temperature,
                Description = GetTemperatureDescription(temperature)
            };

            _forecasData = forecastData;
        }

        public void Delete()
        {
            IsDeleted = true;
        }
        public void Create()
        {
            _forecasData.State = ForecastState.Created;
        }

        public ForecastData GetData()
        {
            return _forecasData;
        }

        public SimpleForecast getSimpleForecast() 
        {
            return new SimpleForecast(_forecasData.Id, _forecasData.Description!);
        }

        private string GetTemperatureDescription(double temperature)
        {
            if (temperature <= -20) return "Freezing";

            else if (temperature < 0) return "Bracing";

            else if (temperature < 10) return "Chilly";

            else if (temperature < 20) return "Cool";

            else if (temperature < 25) return "Mild";

            else if (temperature < 30) return "Warm";

            else if (temperature < 35) return "Balmy";

            else if (temperature < 40) return "Hot";

            else if (temperature < 45) return "Sweltering";

            else return "Scorching";
        }
    }
}
