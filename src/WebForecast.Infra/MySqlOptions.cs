

namespace WeatherForecast.Infra
{
    public class MySqlOptions
    {
        public const string Section = "Repository:MySql";

        public string UserName { get; set; }

        public string Password { get; set; }

        public string ConnectionString { get; set; }
    }
}
