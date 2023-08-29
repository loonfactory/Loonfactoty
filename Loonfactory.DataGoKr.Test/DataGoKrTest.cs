using Loonfactory.DataGoKr.AirKorea;
using Microsoft.Extensions.Hosting;

namespace Loonfactory.DataGoKr.Test;

public class DataGoKrTest
{

    [Fact]
    public void Test1()
    {
        HostApplicationBuilder builder = Host.CreateApplicationBuilder();

        // Add services to the contain
        builder.Services.AddDataGoKr()
                        .AddAirPollution();

        builder.Build();
    }
}