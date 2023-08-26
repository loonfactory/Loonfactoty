namespace Loonfactory.DataGoKr.AirKorea;

public class AirQalityStatisticsByStateProperty
{
    public string? ReturnType { get; set; } = "json";
    public int? NumOfRows { get; set; }
    public int? PageNo { get; set; }
    public string SidoName { get; set; } = default!;
    public string SearchCondition { get; set; } = "DAILY";
}
