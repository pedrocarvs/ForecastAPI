using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Domain.Entities
{
    public interface IAggregate<T, Tkey> where T : IData<Tkey>
    {
        Tkey Id { get; }
        bool IsDeleted { get; }
        void Delete(DateTimeOffset? scheduledDeletionDate = null);
        T GetData();
    }
}
