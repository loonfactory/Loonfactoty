using Microsoft.AspNetCore.DataProtection.KeyManagement;
using System;
using System.Globalization;
using System.Reflection;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Loonfactory.DataGoKr.AirKorea;

public class AirKoeraJsonConverter : JsonConverter<AirInfoByProvince>
{
    public override AirInfoByProvince? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartObject)
        {
            throw new JsonException();
        }

        var data = new AirInfoByProvince();
        var type = typeof(AirInfoByProvince);

        while (reader.Read())
        {
            if (reader.TokenType == JsonTokenType.EndObject)
            {
                return data;
            }

            // Get the key.
            if (reader.TokenType != JsonTokenType.PropertyName)
            {
                throw new JsonException();
            }

            string? propertyName = reader.GetString() ?? throw new JsonException();
            PropertyInfo? property;
            try
            {
                property = type.GetProperty(propertyName);
                if (options.PropertyNamingPolicy == JsonNamingPolicy.CamelCase)
                {
                    var builder = new StringBuilder(propertyName);
                    builder[0] = char.ToUpper(builder[0]);

                    var name = builder.ToString();
                    property = type.GetProperty(name);
                    if (property != null)
                    {
                        propertyName = name;
                    }
                }

                if (property == null)
                {
                    throw new JsonException($"Unable to convert \"{propertyName}\" to {nameof(AirInfoByProvince)}.");
                }
            }
            catch (AmbiguousMatchException)
            {
                throw new JsonException($"Unable to convert \"{propertyName}\" to {nameof(AirInfoByProvince)}.");
            }

            // Get the value.
            reader.Read();

            var propertyType = property.PropertyType;
            object? value;

            if (propertyType == typeof(DateTime))
            {
                if (!DateTime.TryParseExact(reader.GetString(), "yyyy-MM-dd HH:mm", CultureInfo.CurrentCulture, DateTimeStyles.None, out var time))
                {
                    throw new JsonException();
                }

                value = time;
            }
            else if (propertyType == typeof(int?) || propertyType == typeof(int))
            {
                var v = reader.GetString();
                if (v == "-" || v == null) value = null;
                else value = int.Parse(v);
            }
            else if (propertyType == typeof(double?) || propertyType == typeof(double))
            {
                var v = reader.GetString();
                if (v == "-" || v == null) value = null;
                else value = double.Parse(v);
            }
            else if (propertyType == typeof(string))
            {
                value = reader.GetString();
            }
            else
            {
                if (options.GetConverter(propertyType) is JsonConverter<dynamic?> converter) value = converter.Read(ref reader, propertyType, options);
                else value = null;
            }
            property.SetValue(data, value);

        }

        throw new JsonException();
    }

    public override void Write(Utf8JsonWriter writer, AirInfoByProvince value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}
