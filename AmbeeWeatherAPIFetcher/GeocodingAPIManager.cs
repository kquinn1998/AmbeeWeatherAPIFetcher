using System;
using System.Net;

namespace AmbeeWeatherAPIFetcher
{
    public class GeocodingAPIManager
    {
        private APIManager _apiConfig;
        public GeocodingAPIManager(APIManager apiConfig)
        {
            _apiConfig = apiConfig;
            testConnection();
        }
        private void testConnection()
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create($"{_apiConfig._geocodingApiAddress}json?address=Ireland");
            request.AllowAutoRedirect = false; // find out if this site is up and don't follow a redirector
            request.Method = "HEAD";
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    throw new WebException($"Error with connecting to API.... {response.StatusCode} : {response.StatusDescription}");
                }
                else
                {
                    Console.WriteLine("Connection To Geocoding API Successful");
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
