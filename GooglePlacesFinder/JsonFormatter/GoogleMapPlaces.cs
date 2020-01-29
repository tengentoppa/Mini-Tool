using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GooglePlacesFinder.JsonFormatter
{
    class GoogleMapPlaceList
    {
        [JsonProperty("html_attributions")]
        public string[] HtmlAttributions { get; set; }
        [JsonProperty("next_page_token")]
        public string NextPageToken { get; set; }
        public GoogleMapPlace[] Results { get; set; }

        public override string ToString()
        {
            return $"{string.Join("\n", Results.Select(t => t.ToString()))}";
        }
    }
    class GoogleMapPlace
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Vicinity { get; set; }
        public Geometry Geometry { get; set; }
        public GoogleMapPhotos[] Photos { get; set; }
        public string Rating { get; set; }
        public override string ToString()
        {
            return
                $"{Id}," +
                $"{Name}," +
                $"{Vicinity.Replace(',', ' ')}," +
                $"{Geometry.Location.Latitude}," +
                $"{Geometry.Location.Longitude}," +
                $"{Rating}," +
                $"{string.Join("|", (Photos ?? new GoogleMapPhotos[] { new GoogleMapPhotos { Height = 0, Width = 0, PhotoReference = "" } }).Select(t => t.ToString()))}";
        }
    }
    class Geometry
    {
        public GoogleMapLocation Location { get; set; }
    }
    class GoogleMapLocation
    {
        [JsonProperty("lat")]
        public double Latitude { get; set; }
        [JsonProperty("lng")]
        public double Longitude { get; set; }
    }
    class GoogleMapPhotos
    {
        public int Height { get; set; }
        public int Width { get; set; }
        [JsonProperty("photo_reference")]
        public string PhotoReference { get; set; }
        public override string ToString()
        {
            return
                $"{Height}h" +
                $"{Width}w" +
                $"{PhotoReference}";
        }
    }
}
