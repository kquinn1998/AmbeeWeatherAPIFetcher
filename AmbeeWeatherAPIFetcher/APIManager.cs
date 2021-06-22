using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;
using AmbeeWeatherAPIFetcher.Entities;
using Newtonsoft.Json;

namespace AmbeeWeatherAPIFetcher
{
    public class APIManager
    {
        private string _apiKey;
        public APIManager()
        {
            setApiKey();
        }

        private void setApiKey()
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
                    }
                    else
                    {
                        _apiKey = input.api_key;
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
