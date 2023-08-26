namespace Loonfactory.DataGoKr.AirKorea
{
    public class AirInfoByProvince
    {
        public string? StationName { get; set; }
        public string? SidoName { get; set; } 
        public DateTime DataTime { get; set; }
        public double? So2Value { get; set; }
        public double? CoValue { get; set; }
        public double? O3Value { get; set; }
        public double? No2Value { get; set; }
        public double? Pm10Value { get; set; }
        public double? Pm10Value24 { get; set; }
        public double? Pm25Value { get; set; }
        public double? Pm25Value24 { get; set; }
        public double? KhaiValue { get; set; }
        public int? KhaiGrade { get; set; }
        public int? So2Grade { get; set; }
        public int CoGrade { get; set; }
        public int O3Grade { get; set; }
        public int No2Grade { get; set; }
        public int Pm10Grade { get; set; }
        public int Pm10Grade1h { get; set; }
        public int Pm25Grade1h { get; set; }
        public string? So2Flag { get; set; }
        public string? CoFlag { get; set; }
        public string? O3Flag { get; set; }
        public string? No2Flag { get; set; }
        public string? Pm10Flag { get; set; }
        public string? Pm25Flag { get; set; }
    }
}
