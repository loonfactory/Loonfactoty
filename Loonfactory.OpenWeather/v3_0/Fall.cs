using System.Text.Json.Serialization;

namespace Loonfactory.OpenWeather.v3_0;

public class Fall
{
    [JsonPropertyName("1h")]
    public double PerHour { get; set; }
}
