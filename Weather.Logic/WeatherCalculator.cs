namespace Weather.Logic;

public class WeatherCalculator
{
    private readonly IWeatherService _weatherService;

    public WeatherCalculator(IWeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    public double GetTemperatureInCelsius(string city)
    {
        if (string.IsNullOrWhiteSpace(city))
        {
            throw new ArgumentException(nameof(city));
        }
        var farenheit = _weatherService.GetTemperature(city);

        return farenheit * 2;
    }
}