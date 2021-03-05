using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json;

namespace WeatherForcast.Models
{
    public class WeatherViewModel
    {
        [JsonProperty("consolidated_weather")]

        public IList<consolidated_weather> consolidated_weather { get; set; }
    }

    public class consolidated_weather
    {
        [JsonProperty("id")]
        public Int64 id { get; set; }

        [JsonProperty("weather_state_name")]
        public string weather_state_name;

        [JsonProperty("weather_state_abbr")]
        public string weather_state_abbr;

        [JsonProperty("wind_direction_compass")]
        public string wind_direction_compass;

        [JsonProperty("created")]
        public string created;

        [JsonProperty("applicable_date")]
        public string applicable_date;

        [JsonProperty("min_temp")]
        public double min_temp;

        [JsonProperty("max_temp")]
        public double max_temp;

        [JsonProperty("the_temp")]
        public double the_temp;

        [JsonProperty("wind_speed")]
        public double wind_speed;

        [JsonProperty("wind_direction")]
        public double wind_direction;

        [JsonProperty("air_pressure")]
        public double air_pressure;

        [JsonProperty("humidity")]
        public double humidity;

    }
}