namespace Loonfactory.DataGoKr.AirKorea;

public interface IAirQalityInquiryService
{
    public ValueTask<AirQalityByProvinceResponse> GetAirQalityByProvinceAsync(AirQalityByProvinceProperties properties);

    public ValueTask<AirQalityByProvinceResponse> GetAirQalityByProvinceAsync(AirQalityByProvinceProperties properties, CancellationToken token);

    public ValueTask<AirQalityStatisticsResponse> GetAirQalityStatisticsByStateAsync(AirQalityStatisticsByStateProperty properties);

    public ValueTask<AirQalityStatisticsResponse> GetAirQalityStatisticsByStateAsync(AirQalityStatisticsByStateProperty properties, CancellationToken token);
}
