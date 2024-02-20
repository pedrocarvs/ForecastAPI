

namespace WeatherForecast.Tests
{
    public class ForecastAggregateTests
    {
        [Fact]
        public void Constructor_ValidData_ShouldCreateAggregate()
        {
            //Arrange
            var date = DateTime.Now.AddDays(2);
            var temperature = 22.5;
           
            //Act
            var aggregate = new ForecastAggregate(date, temperature);

            //Assert
            Assert.NotNull(aggregate);
            Assert.Equal(date, aggregate.GetData().Date);
            Assert.Equal(temperature, aggregate.GetData().Temperature);
            Assert.False(aggregate.IsDeleted);
        }
       
        [Theory]
        [InlineData(-75)]
        [InlineData(80)]
        public void Constructor_InvalidTemperature_ShouldThrowArgumentOutOfRangeException(double temperature)
        {
            //Arrage
            var date = DateTime.Now.AddDays(1);

            //Act
            Action action = () => new ForecastAggregate(date, temperature);

            //Assert
            Assert.Throws<ArgumentOutOfRangeException>(action);
        }
      
        [Fact]
        public void Constructor_PastDate_ShouldThrowArgumentException()
        {
            //Arrange
            var date = DateTime.Now.AddDays(-1);
            var temperature = 15;

            //Act
            Action action = () => new ForecastAggregate(date, temperature);

            //Assert
            Assert.Throws<ArgumentException>(action);
        }


        [Fact]
        public void Delete_ShouldMarkIsDeleted_As_True()
        {
            var aggregate = new ForecastAggregate(DateTime.Now.AddDays(1), 10);

            aggregate.Delete();

            Assert.True(aggregate.IsDeleted);
        }


        [Theory]
        [InlineData(-25, "Freezing")]
        [InlineData(-5, "Bracing")]
        public void GetTemperatureDescription_ShouldReturnCorrectDescription(double temperature, string expectedDescription)
        {
            var aggregate = new ForecastAggregate(DateTime.Now.AddDays(1), temperature);

            var description = aggregate.GetData().Description;

            Assert.Equal(expectedDescription, description);
        }
    }
}

