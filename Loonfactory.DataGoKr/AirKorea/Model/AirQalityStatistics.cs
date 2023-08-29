namespace Loonfactory.DataGoKr.AirKorea;

public class AirQalityStatistics
{
    public string? CityName { get; set; }

    public string? CityNameEng { get; set; }

    public double? CoValue { get; set; }

    public string? DataGubun { get; set; }

    public DateTime? DataTime { get; set; } = default!;
    
    public string? DistrictCode { get; set; }
    
    public string? DistrictNumSeq { get; set; }
    
    public string? ItemCode { get; set; }
    
    public int? KhaiValue { get; set; }
    
    public double? No2Value { get; set; }
    
    public int? NumOfRows { get; set; }
    
    public double? O3Value { get; set; }
    
    public int? PageNo { get; set; }
    
    public double? Pm10Value { get; set; }
    
    public double? Pm25Value { get; set; }
    public string? ResultCode { get; set; }
    
    public string? ResultMsg { get; set; }
    
    public string? ReturnType { get; set; }
    
    public string? SearchCondition { get; set; }
    
    public string? ServiceKey { get; set; }
    
    public string? SidoName { get; set; }
        
    public double? So2Value { get; set; }
    
    public string? TotalCount { get; set; }
}
