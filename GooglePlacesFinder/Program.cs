using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Threading;
using GooglePlacesFinder.Model;
using Microsoft.Extensions.Configuration;

namespace GooglePlacesFinder
{
    class Program
    {
        const string nc = "\t";
        static Config config;
        static Config Config
        {
            get
            {
                if (config == null)
                {
                    config = ReadFromAppSettings().Get<Config>();
                }
                return config;
            }
            set { config = value; }
        }
        const string FilePath = "";
        static IConfigurationRoot ReadFromAppSettings()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsetting.json", false)
                .Build();
        }
        static void Main(string[] args)
        {
            Run();
            Console.WriteLine($"Version:{System.Reflection.Assembly.GetEntryAssembly().GetName().Version}");
            Console.WriteLine("Press Enter to leave.");
            Console.ReadLine();
        }

        static void Run()
        {
            var configCheck = Config.CheckContent();
            if (!configCheck.checkSuccess) { Console.WriteLine("config empty part: " + string.Join("|", configCheck.emptyPart)); return; }

            var fileName = DateTime.Now.ToString("yyyyMMdd HHmmss") + ".csv";
            var result = $"PlaceId{nc}Name{nc}Compound Code{nc}Address{nc}Phone Number{nc}Website{nc}Latitude{nc}Longitude{nc}Rating{nc}User Ratings Total{nc}Opeing WeekDay{nc}Photos\n";
            var pageToken = "";
            var placeList = new List<GoogleMapPlace>();

            do
            {
                var json = Apis.GetPlaces(Config, pageToken);
                Console.WriteLine(json);
                var data = JsonConvert.DeserializeObject<GoogleMapPlaceList>(json);
                placeList.AddRange(data.Results);

                pageToken = data.NextPageToken;
                SpinWait.SpinUntil(() => false, 2000);
            } while (!string.IsNullOrEmpty(pageToken));

            for (int i = 0; i < placeList.Count; i++)
            {
                var placeInfo = placeList[i];
                var json = Apis.GetPlaceDetail(Config, placeInfo.PlaceId);
                placeList[i] = JsonConvert.DeserializeObject<GoogleMapPlace>(json);
                SpinWait.SpinUntil(() => false, 50);
            }

            result += string.Join("\n", placeList);
            File.AppendAllText(FilePath + fileName, result);

            Console.WriteLine(result);
            Console.WriteLine("Jobs Done.");
        }
    }
}
