using System.Globalization;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;

namespace Loonfactory.DataGoKr.AirKorea;

public partial class AirKoeraJsonConverter<T> : JsonConverter<T> where T : class, new()
{
    Regex DateFomratRegex { get; init; } = GeneratedDateFomratRegex();

    public override T? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        if (reader.TokenType != JsonTokenType.StartObject)
        {
            throw new JsonException();
        }

        var data = new T();
        var type = typeof(T);

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
                    throw new JsonException($"Unable to convert \"{propertyName}\" to {type.Name}.");
                }
            }
            catch (AmbiguousMatchException)
            {
                throw new JsonException($"Unable to convert \"{propertyName}\" to {type.Name}.");
            }

            // Get the value.
            reader.Read();

            var propertyType = property.PropertyType;
            object? value;

            if (propertyType == typeof(DateTime) || propertyType == typeof(DateTime?))
            {
                var dateRow = reader.GetString();
                if (dateRow == null || !DateFomratRegex.IsMatch(dateRow))
                {
                    throw new JsonException(
                        $"Cannot parse '{dateRow}' in 'yyyy-MM-dd HH:mm' Datetime format. Property name: '{propertyName}'");
                }

                var match = DateFomratRegex.Match(dateRow);
                try
                {
                    var year = int.Parse(match.Groups[1].Value);
                    var month = int.Parse(match.Groups[2].Value);
                    var day = int.Parse(match.Groups[3].Value);
                    var hour = int.Parse(match.Groups[4].Value);
                    var minute = int.Parse(match.Groups[5].Value);

                    if (hour == 24)
                    {
                        day += hour / 24;
                        hour %= 24;
                    }                    


                    var date = new DateTime(year, month, day, hour, minute, 0, DateTimeKind.Utc);
                    // KST(Asia/Seoul) UTC+09:00
                    date.AddHours(-9);

                    value = date;
                }
                catch (Exception)
                {
                    throw new JsonException(
                        $"Cannot parse '{dateRow}' in 'yyyy-MM-dd HH:mm' Datetime format. Property name: '{propertyName}'");
                }
            }
            else if (propertyType == typeof(int?) || propertyType == typeof(int))
            {
                var v = reader.GetString();
                if (v == "-" || string.IsNullOrWhiteSpace(v)) value = null;
                else value = int.Parse(v);
            }
            else if (propertyType == typeof(double?) || propertyType == typeof(double))
            {
                var v = reader.GetString();
                if (v == "-" || string.IsNullOrWhiteSpace(v)) value = null;
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

    public override void Write(Utf8JsonWriter writer, T value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }

    [GeneratedRegex("([0-9]{4})-([0-9]{2})-([0-9]{2}) ([0-9]{2}):([0-9]{2})")]
    private static partial Regex GeneratedDateFomratRegex();
}
