
namespace WeatherForecast.Domain.Entities
{
    public class ForecastAggregate : IAggregate<ForecastData, Guid>
    {
        public Guid Id => _forecasData.Id;

        public bool IsDeleted { get; private set; }

        private readonly ForecastData _forecasData;

        public ForecastAggregate(ForecastData forecastData) 
        {
            validateLogic(forecastData.Date, forecastData.Temperature);

            _forecasData = forecastData ?? throw new ArgumentNullException(nameof(forecastData));
        }

        public ForecastAggregate(DateTime date, double temperature)
        {
            validateLogic(date, temperature);

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

        private void validateLogic(DateTime date, double temperature) 
        {
            if (temperature < -60 || temperature > 60)
            {
                throw new ArgumentOutOfRangeException(nameof(temperature), "Temperature must be between -60 and 60 degrees.");
            }

            if (date < DateTime.Now)
            {
                throw new ArgumentException("ForecastData date cannot be the past.");
            }
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

        private string GetTemperatureDescription(double temperature)
        {
            switch (temperature) 
            {
                case <= -20: return "Freezing";

                case < 0: return "Bracing";

                case < 10:  return "Chilly";

                case < 20: return "Cool";

                case  < 25:  return "Mild";

                case < 30:  return "Warm";

                case < 35: return "Balmy";

                case < 40: return "Hot";

                case < 45: return "Sweltering";

                default: return "Scorching";
            }
        }
    }
}
