using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WeatherForecast.Infra.WeatherForecast
{
    public class WeatherForecastConfiguration : IEntityTypeConfiguration<Domain.Entities.ForecastData>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.ForecastData> builder)
        {
            builder.ToTable("ForecastData");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedNever();

            builder.Property(x => x.Date).HasPrecision(6);

            builder.Property(x => x.Description).HasMaxLength(60);

            builder.Property(x =>x.Temperature).HasMaxLength(6);


        }
    }
}
