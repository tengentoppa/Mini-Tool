using System;
using System.Collections.Generic;
using System.Text;

namespace GooglePlacesFinder.Model
{
    class Config
    {
        public string Token { get; set; } = "AIzaSyDk1J6Z3djT6xcgswKTG-_QnRtodQWadWM";
        public string KeyWord { get; set; } = "yoga";
        public string Location { get; set; } = "25.069963,121.573246";
        public double Radius { get; set; } = 20000;        //meter
        public string Language { get; set; } = "zh-TW";

        public (bool checkSuccess, List<string> emptyPart) CheckContent()
        {
            bool checkSuccess = true;
            var emptyPart = new List<string>();

            if (string.IsNullOrEmpty(Token)) { checkSuccess = false; emptyPart.Add(nameof(Token)); }
            if (string.IsNullOrEmpty(KeyWord)) { checkSuccess = false; emptyPart.Add(nameof(KeyWord)); }
            if (string.IsNullOrEmpty(Location)) { checkSuccess = false; emptyPart.Add(nameof(Location)); }
            if (string.IsNullOrEmpty(Language)) { checkSuccess = false; emptyPart.Add(nameof(Language)); }

            return (checkSuccess, emptyPart);
        }
    }
}
