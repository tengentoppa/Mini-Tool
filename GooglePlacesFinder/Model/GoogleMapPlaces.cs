using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GooglePlacesFinder.Model
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
        [JsonProperty("place_id")]
        public string PlaceId { get; set; }
        [JsonProperty("result")]
        public GoogleMapPlaceDetail Detail { get; set; }
        public override string ToString()
        {
            if (Detail == null) { return $"{nameof(Detail)} is null, place id is {PlaceId}"; }
            return Detail.ToString();
        }
    }
    class GoogleMapPlaceDetail
    {
        public string Id { get; set; }
        [JsonProperty("address_components")]
        public AddressComponent[] AddressComponents { get; set; }
        [JsonProperty("formatted_address")]
        public string FormattedAddress { get; set; }
        [JsonProperty("formatted_phone_number")]
        public string FormattedPhoneNumber { get; set; }
        public Geometry Geometry { get; set; }
        [JsonProperty("plus_code")]
        public PlusCode PlusCode { get; set; }
        public float Rating { get; set; }
        [JsonProperty("user_ratings_total")]
        public int UserRatingsTotal { get; set; }
        [JsonProperty("opening_hours")]
        public OpeningHours OpeningHours { get; set; }
        public string Reference { get; set; }
        public string[] Types { get; set; }

        public string Website { get; set; }

        [JsonProperty("place_id")]
        public string PlaceId { get; set; }
        public string Name { get; set; }
        public string Vicinity { get; set; }
        public GoogleMapPhotos[] Photos { get; set; }
        public override string ToString()
        {
            const string nc = "\t";
            return
                $"{PlaceId}{nc}" +
                $"{Name}{nc}" +
                $"{PlusCode.CompoundCode}{nc}" +
                $"{FormattedAddress}{nc}" +
                $"{FormattedPhoneNumber}{nc}" +
                $"{Website}{nc}" +
                $"{Geometry.Location.Latitude}{nc}" +
                $"{Geometry.Location.Longitude}{nc}" +
                $"{Rating}{nc}" +
                $"{UserRatingsTotal}{nc}" +
                $"{string.Join("|", (OpeningHours ?? new OpeningHours()).WeekDay)}{nc}" +
                $"{string.Join("|", (Photos ?? new GoogleMapPhotos[] { new GoogleMapPhotos { Height = 0, Width = 0, PhotoReference = "" } }).Select(t => t.ToString()))}";
        }
    }
    class OpeningHours
    {
        public class Period
        {
            public class DayAndTime
            {
                public int Day;
                public int Time;
            }
            public DayAndTime Close;
            public DayAndTime Open;
        }

        [JsonProperty("open_now")]
        public bool OpenNow { get; set; }
        public Period[] Periods { get; set; } = new Period[0];
        [JsonProperty("weekday_text")]
        public string[] WeekDay { get; set; } = new string[0];
    }
    class AddressComponent
    {
        [JsonProperty("long_name")]
        public string LongName { get; set; }
        [JsonProperty("short_name")]
        public string ShortName { get; set; }
        public string[] Types { get; set; }
    }
    class PlusCode
    {
        [JsonProperty("compound_code")]
        public string CompoundCode { get; set; }
        [JsonProperty("global_code")]
        public string GlobalCode { get; set; }
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
