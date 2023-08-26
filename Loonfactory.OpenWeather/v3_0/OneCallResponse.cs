namespace Loonfactory.OpenWeather.v3_0;

public class OneCallResponse
{
    public double Lat { get; set; }
    
    public double Lon { get; set; }
    
    public string Timezone { get; set; } = default!;
    
    public string TimezoneOffset { get; set; } = default!;

    public OneCallResponseCurrent Current { get; set; } = default!;
}
