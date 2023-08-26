namespace Loonfactory.DataGoKr.AirKorea;

public class AirKoreaResponse<T>
{
    public AirKoreaResponseInner<T> Response { get; set; } = default!;

}

public class AirKoreaResponseInner<T>
{
    public AirKoreaResponseHeader Header { get; set; } = default!;
    public T Body { get; set; } = default!;
}
