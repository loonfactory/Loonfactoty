namespace Loonfactory.DataGoKr.AirKorea;

public class AirPollutionStatistics
{
    public DateTime? DataTime { get; set; } = default!;
    public string? SidoName { get; set; }
    public string? CityName { get; set; }
    public string? CityNameEng { get; set; }
    public double? O2Value { get; set; }
    public double? CoValue { get; set; }
    public double? O3Value { get; set; }
    public double? No2Value { get; set; }
    public double? Pm10Value { get; set; }
    public double? Pm25Value { get; set; }
}
