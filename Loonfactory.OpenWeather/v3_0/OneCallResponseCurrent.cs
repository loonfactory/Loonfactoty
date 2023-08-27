using System.Text.Json.Serialization;

namespace Loonfactory.OpenWeather.v3_0;

public class OneCallResponseCurrent
{
    public long Dt { get; set; }

    [JsonIgnore]
    public DateTime CurrentTime => DateTime.UnixEpoch.AddSeconds(Dt);

    public long Sunrise { get; set; }

    [JsonIgnore]
    public DateTime SunriseTime => DateTime.UnixEpoch.AddSeconds(Sunrise);

    public long Sunset { get; set; }

    [JsonIgnore]
    public DateTime SunsetTime => DateTime.UnixEpoch.AddSeconds(Sunset);

    public double Temp { get; set; }

    [JsonIgnore]
    public double Celsius => Temp - 273.15;

    [JsonIgnore]
    public double Fahrenheit => Temp * 1.8 - 459.67;

    public double FeelsLike { get; set; }
    public double Pressure { get; set; }
    public double Humidity { get; set; }
    public double DewPoint { get; set; }
    public double Clouds { get; set; }
    public double Uvi { get; set; }
    public double Visibility { get; set; }
    public double WindSpeed { get; set; }
    public double WindGust { get; set; }
    public double WindDeg { get; set; }
    public double Rain { get; set; }
    public double Snow { get; set; }
    public IEnumerable<OneCallResponseWeather> Weather { get; set; } = default!;
}
