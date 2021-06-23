using AmbeeWeatherAPIFetcher.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;

namespace AmbeeWeatherAPIFetcher
{
    public class APIManager
    {
        public string _weatherApiKey;
        public string _weatherApiAddress;
        public string _geocodingApiKey;
        public string _geocodingApiAddress;
        public APIManager()
        {
            setApiConfig();
        }

        private void setApiConfig()
        {

            using (StreamReader r = new StreamReader("secrets.json"))
            {
                try
                {
                    string json = r.ReadToEnd();
                    Secrets input = JsonConvert.DeserializeObject<Secrets>(json.ToString());
                    if(string.IsNullOrEmpty(input.weather_api_key))
                    {
                        throw new NullReferenceException("Error... could not retrieve API key.");
                    }else if (string.IsNullOrEmpty(input.weather_api_address))
                    {
                        throw new NullReferenceException("Error... could not retrieve API Address.");
                    }
                    else if (string.IsNullOrEmpty(input.geocoding_api_address))
                    {
                        throw new NullReferenceException("Error... could not retrieve API Address.");
                    }
                    else if (string.IsNullOrEmpty(input.geocoding_api_address))
                    {
                        throw new NullReferenceException("Error... could not retrieve API Address.");
                    }
                    else
                    {
                        _weatherApiKey = input.weather_api_key;
                        _weatherApiAddress = input.weather_api_address;
                        _geocodingApiKey = input.geocoding_api_key;
                        _geocodingApiAddress = input.geocoding_api_address;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }

            }
        }
    }
}
