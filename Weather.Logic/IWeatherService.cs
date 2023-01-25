namespace Weather.Logic;

public interface IWeatherService
{
    public double GetTemperature(string city);
}