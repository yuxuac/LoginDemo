using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LoginDemo.Base
{
    public class Utility
    {
        public static string Serialize<T>(T o)
        {
            return JsonConvert.SerializeObject(o, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
        }

        public static T Deserialize<T>(string c)
        {
            return JsonConvert.DeserializeObject<T>(c, new JsonSerializerSettings() { NullValueHandling = NullValueHandling.Ignore });
        }
    }
}