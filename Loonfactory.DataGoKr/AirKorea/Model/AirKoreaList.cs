namespace Loonfactory.DataGoKr.AirKorea;

public class AirKoreaList<T>
{
    public int NumOfRows { get; set; }
    public int PageNo { get; set; }
    public int TotalCount { get; set; }
    public IEnumerable<T>? Items { get; set; }
}
