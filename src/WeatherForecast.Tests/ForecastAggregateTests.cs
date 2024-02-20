using WeatherForecast.Domain.Entities;
using Xunit;

namespace WeatherForecast.Tests
{
    public class ForecastAggregateTests
    {
            [Fact]
            public void Constructor_ValidData_ShouldCreateAggregate()
            {
                 
                var date = DateTime.Now.AddDays(2);
                var temperature = 22.5;

                var aggregate = new ForecastAggregate(date, temperature);

                Assert.NotNull(aggregate);
                Assert.Equal(date, aggregate.GetData().Date);
                Assert.Equal(temperature, aggregate.GetData().Temperature);
                Assert.False(aggregate.IsDeleted);
            }

            [Theory]
            [InlineData(-61)]
            [InlineData(61)]
            public void Constructor_InvalidTemperature_ShouldThrowException(double temperature)
            {
                var date = DateTime.Now.AddDays(1);

                Assert.Throws<ArgumentOutOfRangeException>(() => new ForecastAggregate(date, temperature));
            }

            [Fact]
            public void Constructor_PastDate_ShouldThrowException()
            {
                var date = DateTime.Now.AddDays(-1);
                var temperature = 15;

                Assert.Throws<ArgumentException>(() => new ForecastAggregate(date, temperature));
            }

          
            [Fact]
            public void Delete_ShouldMarkIsDeleted()
            {
                var aggregate = new ForecastAggregate(DateTime.Now.AddDays(1), 10);

                aggregate.Delete();

                Assert.True(aggregate.IsDeleted);
            }

     
            [Theory]
            [InlineData(-25, "Freezing")]
            [InlineData(-5, "Bracing")]
            public void GetTemperatureDescription_ShouldReturnCorrectDescription(double temperature, string expected)
            {
                var aggregate = new ForecastAggregate(DateTime.Now.AddDays(1), temperature);

                var description = aggregate.GetData().Description;

                Assert.Equal(expected, description);
            }
        }
    }

