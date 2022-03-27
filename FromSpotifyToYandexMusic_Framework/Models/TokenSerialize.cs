using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace FromSpotifyToYandexMusic_Framework.Models
{
    public partial class WelcomToken
    {
        public static WelcomToken FromJson(string json) => JsonConvert.DeserializeObject<WelcomToken>(json, ConverterToken.Settings);
    }

    internal static class ConverterToken
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }
}