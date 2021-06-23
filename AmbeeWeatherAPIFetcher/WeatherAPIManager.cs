using AmbeeWeatherAPIFetcher.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;

namespace AmbeeWeatherAPIFetcher
{
    public class WeatherAPIManager
    {
        private APIManager _apiConfig;
        public WeatherAPIManager(APIManager apiConfig)
        {
            _apiConfig = apiConfig;
            TestConnection();
        }
        private void TestConnection()
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(_apiConfig._weatherApiAddress);
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
                    Console.WriteLine("Connection To Weather API Successful");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public void WeatherByLatLong(string lat, string lng)
        {
            WeatherData data;
            string json;

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest
                .Create($"{_apiConfig._weatherApiAddress}weather/latest/by-lat-lng?lat={lat}&lng={lng}");
            request.AllowAutoRedirect = false;
            request.Headers["x-api-key"] = _apiConfig._weatherApiKey;
            request.Method = "GET";
            try
            {
                var response = request.GetResponse();
                StreamReader streamReader = new StreamReader(response.GetResponseStream(), true);
                try
                {
                    json = streamReader.ReadToEnd();
                    var parsedObject = JObject.Parse(json);

                    if (parsedObject["message"].ToString() != "success")
                    {
                        throw new Exception("Message repsonse failed...");
                    }

                    data = JsonConvert.DeserializeObject<WeatherData>(parsedObject["data"].ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }
                finally
                {
                    streamReader.Close();
                    response.Close();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

            Console.WriteLine(data.ToString());
        }
    }
}
