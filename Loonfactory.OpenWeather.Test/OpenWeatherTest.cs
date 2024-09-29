using Loonfactory.OpenWeather.v3_0;
using Microsoft.Extensions.Hosting;

namespace Loonfactory.OpenWeather.Test;

public class UnitTest1
{
    [Fact]
    public void BuildTest()
    {
        HostApplicationBuilder builder = Host.CreateApplicationBuilder();

        // Add services to the contain
        builder.Services.AddOpenWeather(options => {
            options.ApiKey = builder.Configuration["API_KEY"];
        });                        

        builder.Build();
    }
}