namespace AmbeeWeatherAPIFetcher.Entities
{
    public class GeocodingData
    {
        public string lat { get; set; }
        public string lng { get; set; }

        public override string ToString()
        {
            return $"\n-----Geocoding Data-----\nLatitude : {lat}\nLongitude : {lng}";
        }
    }
}