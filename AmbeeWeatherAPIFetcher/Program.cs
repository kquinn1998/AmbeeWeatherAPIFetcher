using System;

namespace AmbeeWeatherAPIFetcher
{
    class Program
    {
        static void Main(string[] args)
        {
            APIManager apiManager = new APIManager();
            WeatherAPIManager weatherApiManager = new WeatherAPIManager(apiManager);
            GeocodingAPIManager geocodingApiManager = new GeocodingAPIManager(apiManager);

            Console.Write("Enter Latitude :");
            var lat = Console.ReadLine();

            Console.Write("Enter Longitude :");
            var lng = Console.ReadLine();

            weatherApiManager.WeatherByLatLong(lat, lng);
        }
    }
}
