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
        const string Token = "AIzaSyDk1J6Z3djT6xcgswKTG-_QnRtodQWadWM";
        const string KeyWord = "yoga";
        const double Radius = 20000;        //meter
        const string FilePath = "";
        const string Location = "25,120";
        static void Main(string[] args)
        {
            var fileName = DateTime.Now.ToString("yyyyMMdd HHmmss") + ".csv";
            var result = $"ID,Name,Vicinity,Photos\n";
            var pageToken = "";

            do
            {
                var json = GetPlacesByJson(pageToken);
                var data = JsonConvert.DeserializeObject<GoogleMapPlaceList>(json);
                result += data.ToString() + "\n";
                pageToken = data.next_page_token;
                Console.WriteLine(data);
                SpinWait.SpinUntil(() => false, 2000);
            } while (!string.IsNullOrEmpty(pageToken));
            File.AppendAllText(FilePath + fileName, result);

            Console.WriteLine(result);

            Console.WriteLine("Jobs done.");

            Console.WriteLine("Press any key to leave.");
            Console.ReadLine();
        }

        static string GetPlacesByJson(string pageToken = "")
        {
            string rspString = "";
            if (!string.IsNullOrEmpty(pageToken)) { pageToken = $"&pagetoken={pageToken}"; }
            using (HttpClient client = new HttpClient())
            {
                rspString = client.GetAsync(new Uri($"https://maps.googleapis.com/maps/api/place/nearbysearch/json?location=25.069963,121.573246&radius={Radius}&keyword={KeyWord}&key={Token}{pageToken}"))
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
                return client.GetAsync(new Uri($"https://maps.googleapis.com/maps/api/place/photo?maxwidth={maxWidth}&photoreference={photoReference}&keyword={KeyWord}&key={Token}"))
                    .Result
                    .Content
                    .ReadAsStreamAsync()
                    .Result;
            }
        }
    }
}
