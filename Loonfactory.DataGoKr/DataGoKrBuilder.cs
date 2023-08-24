using Microsoft.Extensions.Options;
using System.Diagnostics.CodeAnalysis;

namespace Loonfactory.DataGoKr;

public class DataGoKrBuilder
{

    /// <summary>
    /// Initializes a new instance of <see cref="DataGoKrBuilder"/>.
    /// </summary>
    /// <param name="services">The services being configured.</param>
    public DataGoKrBuilder(IServiceCollection services)
        => Services = services;

    /// <summary>
    /// The services being configured.
    /// </summary>
    public virtual IServiceCollection Services { get; }
}