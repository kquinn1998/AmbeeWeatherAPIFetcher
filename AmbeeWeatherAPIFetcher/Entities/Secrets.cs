namespace AmbeeWeatherAPIFetcher.Entities
{
    public class Secrets
    {
        public string weather_api_key { set; get; }
        public string weather_api_address { set; get; }
        public string geocoding_api_key { get; set; }
        public string geocoding_api_address { get; set; }
    }
}
