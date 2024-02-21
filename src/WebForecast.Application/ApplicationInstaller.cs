
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using WeatherForecast.Application.Handlers;
using WeatherForecast.Domain.Entities;


namespace WeatherForecast.Application
{
    public static class ApplicationInstaller
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<WeatherForecastService>();
            services.AddScoped<IRequestHandler<CreateWeatherForecastRequest, CreateWeatherForecastResponse>, CreateWeatherForecastHandler>();
            services.AddScoped<IRequestHandler<GetWeeklyWeatherForecastRequest, IEnumerable<ForecastData>>, GetWeeklyWeatherForecastHandler>();
            services.AddScoped<IRequestHandler<DeleteWeatherForecastRequest>, DeleteWeatherForecastHandler>();


        }
    }
}