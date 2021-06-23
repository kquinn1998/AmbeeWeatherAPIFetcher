namespace AmbeeWeatherAPIFetcher.Entities
{
    public class WeatherData
    {
        public float time { get; set; }
        public float temperature { get; set; }
        public float apparentTemperature { get; set; }
        public float dewPoint { get; set; }
        public float humidity { get; set; }
        public float pressure { get; set; }
        public float windSpeed { get; set; }
        public float windGust { get; set; }
        public float windBearing { get; set; }
        public float cloudCover { get; set; }
        public float visability { get; set; }
        public float ozone { get; set; }
        public float lat { get; set; }
        public float lng { get; set; }

        public override string ToString()
        {
            return $"\n-----Weather Data-----\nTime : {time}\nTemp : {temperature}\nApparent Temp : {apparentTemperature}\nDew Point : {dewPoint}" +
                $"\nHumidity : {humidity}\nAir Pressure : {pressure}\nWind Speed : {windSpeed}\nWind Gust Speed : {windGust}" +
                $"\nWind Bearing : {windBearing}\nCloud Cover : {cloudCover}\nVisability : {visability}\nO-Zone : {ozone}";
        }
    }
}