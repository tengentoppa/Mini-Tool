using GooglePlacesFinder.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;

namespace GooglePlacesFinder
{
    static class Apis
    {
        public static string GetPlaces(Config info, string pageToken = "")
        {
            if (!string.IsNullOrEmpty(pageToken)) { pageToken = $"&pagetoken={pageToken}"; }
            var uri = new Uri($"https://maps.googleapis.com/maps/api/place/nearbysearch/json?" +
                $"location={info.Location}&" +
                $"radius={info.Radius}&" +
                $"keyword={info.KeyWord}&" +
                $"language={info.Language}&" +
                $"key={info.Token}" +
                $"{pageToken}");
            string rspString = "";
            using (HttpClient client = new HttpClient())
            {
                rspString = client.GetAsync(uri)
                    .Result
                    .Content
                    .ReadAsStringAsync()
                    .Result;
            }

            return rspString;
        }
        public static string GetPlaceDetail(Config info, string placeId)
        {
            var uri = new Uri($"https://maps.googleapis.com/maps/api/place/details/json?" +
                $"place_id={placeId}&" +
                $"language={info.Language}&" +
                $"key={info.Token}");
            string rspString = "";
            using (HttpClient client = new HttpClient())
            {
                rspString = client.GetAsync(uri)
                    .Result
                    .Content
                    .ReadAsStringAsync()
                    .Result;
            }

            return rspString;
        }
        public static Stream GetPhoto(Config info, string photoReference, int maxWidth)
        {
            if (maxWidth > 1600) { maxWidth = 1600; }
            if (maxWidth < 1) { maxWidth = 1; }
            var uri = new Uri($"https://maps.googleapis.com/maps/api/place/photo?" +
                $"maxwidth={maxWidth}&" +
                $"photoreference={photoReference}&" +
                $"key={info.Token}");
            using (HttpClient client = new HttpClient())
            {
                return client.GetAsync(uri)
                    .Result
                    .Content
                    .ReadAsStreamAsync()
                    .Result;
            }
        }
    }
}
