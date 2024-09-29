using Loonfactory.OpenWeather.v3_0;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Loonfactory.OpenWeather.Test;

public class OpenWeatherTests
{
    private readonly IOpenWeatherService _openWeatherService;

    public OpenWeatherTests()
    {
        HostApplicationBuilder builder = Host.CreateApplicationBuilder();

        builder.Configuration.AddUserSecrets<OpenWeatherTests>();

        builder.Services.AddOpenWeather(options =>
        {
            options.ApiKey = builder.Configuration["OpenWeather:ApiKey"];
        });

        var host = builder.Build();
        _openWeatherService = host.Services.GetRequiredService<IOpenWeatherService>();
    }

    [Fact]
    public async Task GetOneCallAsync_ReturnsValidResponse_FromAPI()
    {
          // Arrange
        var properties = new OneCallProperties
        {
            Lat = 37.7749,
            Lon = -122.4194,
            Exclude = "minutely",
            Units = "metric",
            Lang = "en"
        };

        // Act
        var response = await _openWeatherService.GetOneCallAsync(properties);

        // Assert
        Assert.NotNull(response);
        Assert.NotNull(response.Current);
        Assert.True(response.Current.Temp > -50 && response.Current.Temp < 50); // 온도 범위 검증
        Assert.NotEmpty(response.Current.Weather);
        Assert.False(string.IsNullOrWhiteSpace(response.Current.Weather.First().Description)); // 날씨 설명 검증

    }
}