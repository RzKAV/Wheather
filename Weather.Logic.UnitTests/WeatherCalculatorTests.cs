using NSubstitute;
using NUnit.Framework;

namespace Weather.Logic.UnitTests;

[TestFixture]
public class WeatherCalculatorTests
{
    private WeatherCalculator _calculator;
    private IWeatherService _weatherService;
    
    [SetUp]
    public void SetUp()
    {
        _weatherService = Substitute.For<IWeatherService>();
        _calculator = new WeatherCalculator(_weatherService);
    }
    
    [Test]
    public void GetTemperatureInCelsiusTest()
    {
        //arrange
        _weatherService.GetTemperature("").ReturnsForAnyArgs(25.3);
        var expectedTomskResult = 50.6000002;

        //act
        var result = _calculator.GetTemperatureInCelsius("Tomsk");

        //assert
        Assert.AreEqual(expectedTomskResult, result, 0.0001);
    }

    [TestCase(null)]
    [TestCase("")]
    [TestCase("    ")]
    public void GetTemperatureInCelsiusTest_Negative_ThrowsException(string city)
    {
        Assert.Throws<ArgumentException>(() =>
        {
            _calculator.GetTemperatureInCelsius(city);
        });
    }
}