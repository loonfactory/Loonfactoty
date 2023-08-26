namespace Loonfactory.OpenWeather.v3_0;

public class OpenWeatherBuilder
{

    /// <summary>
    /// Initializes a new instance of <see cref="OpenWeatherBuilder"/>.
    /// </summary>
    /// <param name="services">The services being configured.</param>
    public OpenWeatherBuilder(IServiceCollection services)
        => Services = services;

    /// <summary>
    /// The services being configured.
    /// </summary>
    public virtual IServiceCollection Services { get; }
}