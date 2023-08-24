namespace Loonfactory.DataGoKr.AirKorea
{
    public class AirInfoByProvinceResponse
    {
        public int ResultCode { get; set; }
        public string ResultMsg { get; set; } = default!;
        public int NumOfRows { get; set; }
        public int PageNo { get; set; }
        public int TotalCount { get; set; }
        public IEnumerable<object>? Items { get; set; }
        public string StationName { get; set; } = default!;
        public DateTime DataTime { get; set; }
        public int So2Value { get; set; }
        public int CoValue { get; set; }
        public int O3Value { get; set; }
        public int No2Value { get; set; }
        public int Pm10Value { get; set; }
        public int Pm10Value24 { get; set; }
        public int Pm25Value { get; set; }
        public int Pm25Value24 { get; set; }
        public int KhaiValue { get; set; }
        public int KhaiGrade { get; set; }
        public int So2Grade { get; set; }
        public int CoGrade { get; set; }
        public int O3Grade { get; set; }
        public int No2Grade { get; set; }
        public int Pm10Grade { get; set; }
        public int Pm10Grade1h { get; set; }
        public int Pm25Grade1h { get; set; }
        public int So2Flag { get; set; }
        public int CoFlag { get; set; }
        public int O3Flag { get; set; }
        public int No2Flag { get; set; }
        public int Pm10Flag { get; set; }
        public int Pm25Flag { get; set; }
    }
}
