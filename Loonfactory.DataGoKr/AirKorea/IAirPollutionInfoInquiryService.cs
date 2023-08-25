namespace Loonfactory.DataGoKr.AirKorea;

public interface IAirPollutionInfoInquiryService
{
    public ValueTask<AirInfoByProvinceResponse> GetAirInfoByProvinceAsync(AirPollutionInfoByProvinceProperties properties);
}
