using System;

namespace AmbeeWeatherAPIFetcher
{
    class Program
    {
        static void Main(string[] args)
        {
            APIManager api = new APIManager();

            Console.Write("Enter Latitude :");
            var lat = Console.ReadLine();

            Console.Write("Enter Longitude :");
            var lng = Console.ReadLine();

            api.weatherByLatLong(lat, lng);
        }
    }
}
