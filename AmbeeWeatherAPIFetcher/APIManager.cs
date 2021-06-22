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
        private string _apiKey;
        private string _apiAddress;
        public APIManager()
        {
            setApiConfig();
            testConnection();
        }

        private void setApiConfig()
        {

            using (StreamReader r = new StreamReader("secrets.json"))
            {
                try
                {
                    string json = r.ReadToEnd();
                    Secrets input = JsonConvert.DeserializeObject<Secrets>(json.ToString());
                    if(string.IsNullOrEmpty(input.api_key))
                    {
                        throw new NullReferenceException("Error... could not retrieve API key.");
                    }else if (string.IsNullOrEmpty(input.api_address))
                    {
                        throw new NullReferenceException("Error... could not retrieve API Address.");
                    }
                    else
                    {
                        _apiKey = input.api_key;
                        _apiAddress = input.api_address;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                    throw;
                }

            }
        }

        private void testConnection()
        {
            HttpWebRequest request = (HttpWebRequest)HttpWebRequest.Create(_apiAddress);
            request.AllowAutoRedirect = false; // find out if this site is up and don't follow a redirector
            request.Method = "HEAD";
            try
            {
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                if(response.StatusCode != HttpStatusCode.OK)
                {
                    throw new WebException($"Error with connecting to API.... {response.StatusCode} : {response.StatusDescription}");
                }
                else
                {
                    Console.WriteLine("Test Connection Successful");
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }

        public void weatherByLatLong(string lat, string lng)
        {
            WeatherData data;
            string json;

            HttpWebRequest request = (HttpWebRequest)HttpWebRequest
                .Create($"{_apiAddress}weather/latest/by-lat-lng?lat={lat}&lng={lng}");
            request.AllowAutoRedirect = false;
            request.Headers["x-api-key"] = _apiKey;
            request.Method = "GET";
            try
            {
                var response = request.GetResponse();
                StreamReader streamReader = new StreamReader(response.GetResponseStream(), true);
                try
                {
                    json = streamReader.ReadToEnd();
                    var parsedObject = JObject.Parse(json);

                    if(parsedObject["message"].ToString() != "success")
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
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }

            Console.WriteLine(data.ToString());
        }
    }
}
