using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Control_Progreso {
    public class Clima {
        [JsonPropertyName("humidity")]
        public int Humidity { get; set; }

        [JsonPropertyName("pressure")]
        public double? Pressure { get; set; }

        [JsonPropertyName("st")]
        public double? St { get; set; }

        [JsonPropertyName("visibility")]
        public float Visibility { get; set; }

        [JsonPropertyName("wind_speed")]
        public object WindSpeed { get; set; }

        [JsonPropertyName("id")]
        public int Id { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("temp")]
        public float Temp { get; set; }

        [JsonPropertyName("wing_deg")]
        public string WingDeg { get; set; }

        [JsonPropertyName("tempDesc")]
        public string TempDesc { get; set; }
    }

    public class Provincias {
        [JsonPropertyName("_id")]
        public string Id { get; set; }

        [JsonPropertyName("dist")]
        public double Dist { get; set; }

        [JsonPropertyName("lid")]
        public int Lid { get; set; }

        [JsonPropertyName("fid")]
        public int Fid { get; set; }

        [JsonPropertyName("int_number")]
        public int IntNumber { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("province")]
        public string Province { get; set; }

        [JsonPropertyName("lat")]
        public string Lat { get; set; }

        [JsonPropertyName("lon")]
        public string Lon { get; set; }

        [JsonPropertyName("zoom")]
        public string Zoom { get; set; }

        [JsonPropertyName("updated")]
        public int Updated { get; set; }

        [JsonPropertyName("weather")]
        public Clima Weather { get; set; }

        [JsonPropertyName("forecast")]
        public object Forecast { get; set; }
    }
}
