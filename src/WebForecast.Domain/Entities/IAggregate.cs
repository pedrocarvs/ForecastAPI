

namespace WeatherForecast.Domain.Entities
{
    public interface IAggregate<T, Tkey> where T : IData<Tkey>
    {
        Tkey Id { get; }
        bool IsDeleted { get; }
        void Delete();
        T GetData();
    }
}
