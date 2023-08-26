namespace Loonfactory.DataGoKr.AirKorea
{
    public class AirPollutionInfoByProvinceProperties
    {
        public string? ReturnType { get; set; } = "json";
        public int? NumOfRows { get; set; }
        public int? PageNo { get; set; }
        public string SidoName { get; set; } = default!;
        public string? Ver { get; set; }

    }
}
