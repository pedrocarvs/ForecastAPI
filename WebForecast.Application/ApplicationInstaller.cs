using System.Reflection;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using WeatherForecast.Application.Handlers;
using WeatherForecast.Domain.Entities;
using WeatherForecast.Domain.Repositories;
using WeatherForecast.Infra.WeatherForecast;

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