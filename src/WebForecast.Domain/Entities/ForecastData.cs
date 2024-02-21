
namespace WeatherForecast.Domain.Entities
{
    public class ForecastData : IData<Guid>
    {
        public Guid Id { get; set ; }
        public DateTime Date { get; set; }
        public ForecastState State { get; set; }
        public double Temperature { get;  set; }
        public string? Description { get; set; }
        public DateTimeOffset Created {get; set; }
        public DateTimeOffset Updated { get ; set ; }
    }
}