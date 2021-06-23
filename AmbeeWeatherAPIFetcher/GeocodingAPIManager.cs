using AmbeeWeatherAPIFetcher.Entities;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;

namespace AmbeeWeatherAPIFetcher
{
    public class GeocodingAPIManager
    {
        private APIManager _apiConfig;
        public GeocodingAPIManager(APIManager apiConfig)
        {
            _apiConfig = apiConfig;
            TestConnection();
        }
        private void TestConnection()
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

        public GeocodingData AddressToLatLong(string address)
        {
            GeocodingData data;
            string json;

            address = address.Replace(' ', '+');

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest
                .Create($"{_apiConfig._geocodingApiAddress}json?address={address}&key={_apiConfig._geocodingApiKey}");
            request.AllowAutoRedirect = false;
            request.Method = "GET";
            try
            {
                var response = request.GetResponse();
                StreamReader streamReader = new StreamReader(response.GetResponseStream(), true);
                try
                {
                    json = streamReader.ReadToEnd();
                    var parsedObject = JObject.Parse(json);

                    if (parsedObject["status"].ToString() != "OK")
                    {
                        throw new Exception("Message repsonse failed...");
                    }

                    data = JsonConvert.DeserializeObject<GeocodingData>(parsedObject["results"][0]["geometry"]["location"].ToString());
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
            return data;
        }
    }
}
