using System;

namespace AmbeeWeatherAPIFetcher.Entities
{
    public class WeatherData
    {
        public long time { get; set; }
        public double temperature { get; set; }
        public double apparentTemperature { get; set; }
        public double dewPoint { get; set; }
        public double humidity { get; set; }
        public double pressure { get; set; }
        public double windSpeed { get; set; }
        public double windGust { get; set; }
        public double windBearing { get; set; }
        public double cloudCover { get; set; }
        public float visibility { get; set; }
        public double ozone { get; set; }
        public double lat { get; set; }
        public double lng { get; set; }


        public override string ToString()
        {
            FormatWeatherData();
            return $"\n-----Weather Data-----\nTime : {DateTimeOffset.FromUnixTimeSeconds(time).LocalDateTime.TimeOfDay}" +
                $"\nTemp : {temperature}C\nApparent Temp : {apparentTemperature}C\nDew Point : {dewPoint}C" +
                $"\nHumidity : {humidity}%\nAir Pressure : {pressure}Pa\nWind Speed : {windSpeed}m/s\nWind Gust Speed : {windGust}m/s" +
                $"\nWind Direction : {WindDirectionBearingToCompass()}\nCloud Cover : {cloudCover}%\nVisability : {visibility} miles\nO-Zone : {ozone}DU";
        }

        public void FormatWeatherData()
        {
            this.temperature = TempConversion(this.temperature);
            this.apparentTemperature = TempConversion(this.apparentTemperature);
            this.dewPoint = TempConversion(this.dewPoint);
            this.humidity = PercentageConversion(this.humidity);
            this.cloudCover = PercentageConversion(this.cloudCover);
        }

        private double TempConversion(double temp)
        {
            return Math.Round(((temp - 32) * 0.5556),2);
        }

        private double PercentageConversion(double value)
        {
            return Math.Round(value * 100,2);
        }

        private string WindDirectionBearingToCompass()
        {
            if(this.windBearing > 337.5 && this.windBearing <= 359 || this.windBearing <= 22.5 && this.windBearing >= 0)
            {
                return "N";
            }
            else if(this.windBearing > 22.5 && this.windBearing <= 67.5)
            {
                return "NE";
            }
            else if(this.windBearing > 67.5 && this.windBearing <= 112.5)
            {
                return "E";
            }
            else if (this.windBearing > 112.5 && this.windBearing <= 157.5)
            {
                return "SE";
            }
            else if (this.windBearing > 157.5 && this.windBearing <= 202.5)
            {
                return "S";
            }
            else if (this.windBearing > 202.5 && this.windBearing <= 247.5)
            {
                return "SW";
            }
            else if (this.windBearing > 247.5 && this.windBearing <= 292.5)
            {
                return "W";
            }
            else if (this.windBearing > 292.5 && this.windBearing <= 337.5)
            {
                return "NW";
            }
            return this.windBearing.ToString();
        }
    }
}