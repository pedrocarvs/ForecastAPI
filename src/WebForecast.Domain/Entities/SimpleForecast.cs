namespace WeatherForecast.Domain.Entities
{
    public class SimpleForecast
    {
        public Guid Id;
        public string Description; 
        public SimpleForecast(Guid id, string description) 
        {
            Id = id;
            Description = description;
        } 
    }
}