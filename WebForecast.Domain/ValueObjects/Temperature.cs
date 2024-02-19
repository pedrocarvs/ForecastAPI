using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecast.Domain.Entities;

namespace WeatherForecast.Domain.ValueObjects
{
    public class Temperature 
    {
        public Temperature() { }
        public Guid Id { get; set; }
        public int Value { get; private set; }

        public Temperature(int value, DateTime date)
        {
            if (value < -60 || value > 60)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Temperature must be between -60 and 60 degrees.");
            }

            if (date < DateTime.Now)
            {
                throw new ArgumentException("ForecastData date cannot be the past.");
            }

            Value = value;
        }
    }
}
