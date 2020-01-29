using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using Newtonsoft.Json;
using GooglePlacesFinder.JsonFormatter;
using System.Drawing;
using System.Threading;

namespace GooglePlacesFinder
{
    class Program
    {
        class Info
        {
            public string Token { get; set; } = "AIzaSyDk1J6Z3djT6xcgswKTG-_QnRtodQWadWM";
            public string KeyWord { get; set; } = "yoga";
            public string Location { get; set; } = "25.069963,121.573246";
            public double Radius { get; set; } = 20000;        //meter
        }
        static Info info = new Info();
        const string FilePath = "";
        static void Main(string[] args)
        {
            var fileName = DateTime.Now.ToString("yyyyMMdd HHmmss") + ".csv";
            var result = $"ID,Name,Vicinity,Latitude,Longitude,Rating,Photos\n";
            var pageToken = "";

            do
            {
                var uri = new Uri($"https://maps.googleapis.com/maps/api/place/nearbysearch/json?location={info.Location}&radius={info.Radius}&keyword={info.KeyWord}&key={info.Token}{pageToken}");
                var json = GetPlacesByJson(uri);
                Console.WriteLine(json);
                var data = JsonConvert.DeserializeObject<GoogleMapPlaceList>(json);

                result += data.ToString() + "\n";

                pageToken = data.NextPageToken;
                Console.WriteLine(data);
                SpinWait.SpinUntil(() => false, 2000);
            } while (!string.IsNullOrEmpty(pageToken));
            File.AppendAllText(FilePath + fileName, result);

            Console.WriteLine(result);

            Console.WriteLine($"Version:{System.Reflection.Assembly.GetEntryAssembly().GetName().Version}, Jobs done.");

            Console.WriteLine("Press any key to leave.");
            Console.ReadLine();
        }

        static string GetPlacesByJson(Uri uri, string pageToken = "")
        {
            string rspString = "";
            if (!string.IsNullOrEmpty(pageToken)) { pageToken = $"&pagetoken={pageToken}"; }
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
        static Stream GetPhoto(string photoReference, int maxWidth)
        {
            if (maxWidth > 1600) { maxWidth = 1600; }
            if (maxWidth < 1) { maxWidth = 1; }
            using (HttpClient client = new HttpClient())
            {
                return client.GetAsync(new Uri($"https://maps.googleapis.com/maps/api/place/photo?maxwidth={maxWidth}&photoreference={photoReference}&keyword={info.KeyWord}&key={info.Token}"))
                    .Result
                    .Content
                    .ReadAsStreamAsync()
                    .Result;
            }
        }
    }
}
