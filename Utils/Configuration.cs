using Microsoft.AspNetCore.Hosting.Server;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Runtime.Remoting.Channels;

namespace IdentityGamaFramework.Utils
{
    public static class Configuration
    {

        public static string ValueAppSettings(string key)
        {
            string pathToJsonFile = $"{AppDomain.CurrentDomain.BaseDirectory}bin\\AppSettings.json";
            string jsonString = File.ReadAllText(pathToJsonFile);
            JObject jObject = JObject.Parse(jsonString);

            if (jObject.TryGetValue(key, out JToken valueToken))
            {
                string value = valueToken.Value<string>();
                return value;
            }
            else
            {
                return null; 
            }

        }
    }
}
