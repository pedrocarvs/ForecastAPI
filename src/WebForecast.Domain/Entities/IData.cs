using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Domain.Entities
{
    public interface IData<TKey>
    {
        TKey Id { get; set; }

        DateTimeOffset Created { get; set; }

        DateTimeOffset Updated { get; set; }
    }
}
