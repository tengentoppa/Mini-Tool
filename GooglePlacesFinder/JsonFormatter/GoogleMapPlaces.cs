using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GooglePlacesFinder.JsonFormatter
{
    class GoogleMapPlaceList
    {
        public string[] html_attributions;
        public string next_page_token;
        public GoogleMapPlace[] results;

        public override string ToString()
        {
            return $"{string.Join("\n", results.Select(t => t.ToString()))}";
        }
    }
    class GoogleMapPlace
    {
        public string id;
        public string name;
        public string vicinity;
        public GoogleMapPhotos[] photos;
        public override string ToString()
        {
            return
                $"{id}," +
                $"{name}," +
                $"{vicinity.Replace(',', ' ')}," +
                $"{string.Join("|", (photos ?? new GoogleMapPhotos[] { new GoogleMapPhotos { height = 0, width = 0, photo_reference = "" } }).Select(t => t.ToString()))}";
        }
    }
    class GoogleMapPhotos
    {
        public int height;
        public int width;
        public string photo_reference;
        public override string ToString()
        {
            return
                $"{height}h" +
                $"{width}w" +
                $"{photo_reference}";
        }
    }
}
