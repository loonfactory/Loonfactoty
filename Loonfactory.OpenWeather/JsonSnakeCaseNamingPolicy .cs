using System.Text;
using System.Text.Json;

namespace Loonfactory.OpenWeather;

internal sealed class JsonSnakeCaseNamingPolicy : JsonNamingPolicy
{
    public override string ConvertName(string name)
    {
        if (string.IsNullOrEmpty(name))
        {
            return name;
        }

        var builder = new StringBuilder();

        if (char.IsUpper(name[0])) builder.Append(char.ToLowerInvariant(name[0]));
        else builder.Append(name[0]);

        for (int i = 0; i < name.Length; i++)
        {
            if (char.IsUpper(name[i]) || char.IsWhiteSpace(name[i]))
            {
                builder.Append('_');
                if (char.IsUpper(name[i])) builder.Append(char.ToLowerInvariant(name[i]));
            }
            else builder.Append(name[i]);
        }

        return builder.ToString();
    }
}
