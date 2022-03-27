using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Newtonsoft.Json.Converters;
using System.Globalization;

namespace FromSpotifyToYandexMusic_Framework.Models
{
    public enum AlbumTypeEnum { Album, Compilation, Single };

    public enum ArtistType { Artist };

    public enum ReleaseDatePrecision { Day, Year, Month };

    public enum TrackType { Track };

    public partial struct ReleaseDate
    {
        public DateTimeOffset? DateTime;
        public long? Integer;

        public static implicit operator ReleaseDate(DateTimeOffset DateTime) => new ReleaseDate { DateTime = DateTime };
        public static implicit operator ReleaseDate(long Integer) => new ReleaseDate { Integer = Integer };
    }

    public partial class Welcome
    {
        public static Welcome FromJson(string json) => JsonConvert.DeserializeObject<Welcome>(json, Converter.Settings);
    }

    public static class Serialize
    {
        public static string ToJson(this Welcome self) => JsonConvert.SerializeObject(self, Converter.Settings);
    }

    internal static class Converter
    {
        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
        {
            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
            DateParseHandling = DateParseHandling.None,
            Converters =
            {
                AlbumTypeEnumConverter.Singleton,
                ArtistTypeConverter.Singleton,
                ReleaseDateConverter.Singleton,
                ReleaseDatePrecisionConverter.Singleton,
                TrackTypeConverter.Singleton,
                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
            },
        };
    }

    internal class AlbumTypeEnumConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(AlbumTypeEnum) || t == typeof(AlbumTypeEnum?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "album":
                    return AlbumTypeEnum.Album;
                case "compilation":
                    return AlbumTypeEnum.Compilation;
                case "single":
                    return AlbumTypeEnum.Single;
            }
            throw new Exception("Cannot unmarshal type AlbumTypeEnum");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (AlbumTypeEnum)untypedValue;
            switch (value)
            {
                case AlbumTypeEnum.Album:
                    serializer.Serialize(writer, "album");
                    return;
                case AlbumTypeEnum.Compilation:
                    serializer.Serialize(writer, "compilation");
                    return;
                case AlbumTypeEnum.Single:
                    serializer.Serialize(writer, "single");
                    return;
            }
            throw new Exception("Cannot marshal type AlbumTypeEnum");
        }

        public static readonly AlbumTypeEnumConverter Singleton = new AlbumTypeEnumConverter();
    }

    internal class ArtistTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(ArtistType) || t == typeof(ArtistType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "artist")
            {
                return ArtistType.Artist;
            }
            throw new Exception("Cannot unmarshal type ArtistType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (ArtistType)untypedValue;
            if (value == ArtistType.Artist)
            {
                serializer.Serialize(writer, "artist");
                return;
            }
            throw new Exception("Cannot marshal type ArtistType");
        }

        public static readonly ArtistTypeConverter Singleton = new ArtistTypeConverter();
    }

    internal class ReleaseDateConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(ReleaseDate) || t == typeof(ReleaseDate?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            switch (reader.TokenType)
            {
                case JsonToken.String:
                case JsonToken.Date:
                    var stringValue = serializer.Deserialize<string>(reader);
                    DateTimeOffset dt;
                    if (DateTimeOffset.TryParse(stringValue, out dt))
                    {
                        return new ReleaseDate { DateTime = dt };
                    }
                    long l;
                    if (Int64.TryParse(stringValue, out l))
                    {
                        return new ReleaseDate { Integer = l };
                    }
                    break;
            }
            throw new Exception("Cannot unmarshal type ReleaseDate");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            var value = (ReleaseDate)untypedValue;
            if (value.DateTime != null)
            {
                serializer.Serialize(writer, value.DateTime.Value.ToString("o", System.Globalization.CultureInfo.InvariantCulture));
                return;
            }
            if (value.Integer != null)
            {
                serializer.Serialize(writer, value.Integer.Value.ToString());
                return;
            }
            throw new Exception("Cannot marshal type ReleaseDate");
        }

        public static readonly ReleaseDateConverter Singleton = new ReleaseDateConverter();
    }

    internal class ReleaseDatePrecisionConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(ReleaseDatePrecision) || t == typeof(ReleaseDatePrecision?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            switch (value)
            {
                case "day":
                    return ReleaseDatePrecision.Day;
                case "year":
                    return ReleaseDatePrecision.Year;
                case "month":
                    return ReleaseDatePrecision.Month;
            }
            throw new Exception("Cannot unmarshal type ReleaseDatePrecision");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (ReleaseDatePrecision)untypedValue;
            switch (value)
            {
                case ReleaseDatePrecision.Day:
                    serializer.Serialize(writer, "day");
                    return;
                case ReleaseDatePrecision.Year:
                    serializer.Serialize(writer, "year");
                    return;
            }
            throw new Exception("Cannot marshal type ReleaseDatePrecision");
        }

        public static readonly ReleaseDatePrecisionConverter Singleton = new ReleaseDatePrecisionConverter();
    }

    internal class TrackTypeConverter : JsonConverter
    {
        public override bool CanConvert(Type t) => t == typeof(TrackType) || t == typeof(TrackType?);

        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null) return null;
            var value = serializer.Deserialize<string>(reader);
            if (value == "track")
            {
                return TrackType.Track;
            }
            throw new Exception("Cannot unmarshal type TrackType");
        }

        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
        {
            if (untypedValue == null)
            {
                serializer.Serialize(writer, null);
                return;
            }
            var value = (TrackType)untypedValue;
            if (value == TrackType.Track)
            {
                serializer.Serialize(writer, "track");
                return;
            }
            throw new Exception("Cannot marshal type TrackType");
        }
        public static readonly TrackTypeConverter Singleton = new TrackTypeConverter();
    }
}


