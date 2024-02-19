using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WeatherForecast.Application.Handlers;
using WeatherForecast.Domain.Entities;
using WeatherForecast.Domain.Repositories;

namespace WeatherForecast.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly ISender _mediator; 
        public WeatherForecastController(ISender mediator)
        {
            _mediator = mediator;     
        }

        [HttpPost]
        [Route("AddWeatherForecast")]
        public async Task<ActionResult<Guid>> AddWeatherForecast(CreateWeatherForecastRequest forecast)
        {
            try
            {
                var weatherForecastId = _mediator.Send(forecast);
                return Ok(weatherForecastId);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetWeeklyWeatherForecast")]
        public IActionResult GetWeeklyWeatherForecast(GetWeeklyWeatherForecastRequest request)
        {
            try
            {
                var forecastList = _mediator.Send(request);

                return Ok(forecastList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }
}