namespace Loonfactory.OpenWeather.v3_0;

public class OneCallResponseWeather
{
    public int Id { get; set; }
    public string Main { get; set; } = default!;
    public string Description { get; set; } = default!;
    public string Icon { get; set; } = default!;

}