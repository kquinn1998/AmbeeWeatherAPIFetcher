"# AmbeeWeatherAPIFetcher" 
"# AmbeeWeatherAPIFetcher" 

<h1>Weather Data Fetcher & Formatter</h1>
<a>This application is a side project of mine in which I hope to improve my C#
skills in the ares of RESTful requests, data formatting and general application
structure and architecture.</a>

<h2>Features / Ideas</h2>
<ul>
<li>Data Retrieval from API</li>
<li>Data formatting</li>
<li>Implementation of Google maps Geosearch API with converting addresses to lat/long</li>
<li>GUI Application to showcase the data and features</li>
</ul>

<h2>Running The Project Yourself</h2>
<a>So far the project is a simple Console Application made using .NETCore 5.0.
This may change in the future. The program requires you to make a JSON file in
the root directory called "secrets.json". This file assumes the structure of :

{
  "weather_api_key": "",
  "weather_api_address": "https://api.ambeedata.com/",
  "geocoding_api_key": "",
  "geocoding_api_address": "https://maps.googleapis.com/maps/api/geocode/"
}

Where you must supply your own API Key for both Ambree Weather API and
Googles Geocoding API. After supplying the keys the program can easily be run
in debug mode or built for release using Visual Studio 2019.
