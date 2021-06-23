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

            Console.Write("Enter Address : ");
            var address = Console.ReadLine();

            var geoData = geocodingApiManager.AddressToLatLong(address);

            Console.WriteLine(geoData.ToString());

            var weatherData = weatherApiManager.WeatherByLatLong(geoData.lat, geoData.lng);

            Console.WriteLine(weatherData.ToString());
        }
    }
}
