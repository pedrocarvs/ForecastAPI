

namespace WeatherForecast.Domain.Entities
{
    public interface IData<TKey>
    {
        TKey Id { get; set; }

        DateTimeOffset Created { get; set; }

        DateTimeOffset Updated { get; set; }
    }
}
