using MediatR;
using Microsoft.AspNetCore.Mvc;
using WeatherForecast.Application.Handlers;


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
        public ActionResult<Guid> AddWeatherForecast(CreateWeatherForecastRequest forecast)
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

        [HttpPost]
        [Route("DeleteWeatherForecast")]
        public ActionResult<Guid> DeleteWeatherForecast(DeleteWeatherForecastRequest forecast)
        {
            try
            {
                var weatherForecastId = _mediator.Send(forecast);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("GetWeeklyWeatherForecast")]
        public IActionResult GetWeeklyWeatherForecast([FromHeader] GetWeeklyWeatherForecastRequest request)
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