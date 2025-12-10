using FedoraMirrorGrabber.App;
using FedoraMirrorGrabber.Core;
using FedoraMirrorGrabber.Core.Builders;
using FedoraMirrorGrabber.Core.Uris;
using Microsoft.Extensions.Logging;
using System.IO.Abstractions;
using System.Reflection;

internal partial class Program
{
  public static async Task Run(Options options)
  {
    _logger.LogInformation(
      "Generating database for {Proxy} for Fedora {ReleaseVersion} ({Architecture})", 
      GetProxy(options.ProxyType), 
      options.ReleaseVersion, 
      options.Architecture);

    var client = new HttpClient();
    var retriever = new MirrorListRetriever(client, new ResponseProcessor(), _loggerFactory.CreateLogger<MirrorListRetriever>());

    var allMirrors = new List<Mirror>();
    await foreach (var mirrors in retriever.GetMirrors(MirrorUriTemplate.All, options.Architecture,
                     options.ReleaseVersion))
    {
      allMirrors.AddRange(mirrors);
    }

    Func<Mirror, bool>? filter = default;
    if (options.Protocols is not null && options.Protocols.Any())
    {
      filter = m => options.Protocols.Contains(m.Type);
    }

    _logger.LogInformation("Saving database to {OutputFile}", options.SaveTo);

    var builder = GetBuilder(options.ProxyType);
    await builder.Save(options.SaveTo, options.Architecture, options.ReleaseVersion, allMirrors, filter);

    _logger.LogInformation("Data saved to {OutputFile}", options.SaveTo);
  }

  private static string GetProxy(ProxyType proxyType)
  {
    return typeof(ProxyType)
      .GetMember(proxyType.ToString())
      .FirstOrDefault(mi => mi.DeclaringType == typeof(ProxyType))
      ?.GetCustomAttribute<ProxyAttribute>()
      ?.Name ?? throw new NotSupportedException($"Unknown proxy type: {proxyType}");
  }

  private static IDbBuilder GetBuilder(ProxyType proxyType)
  {
    var fs = new FileSystem();

    return proxyType switch {
      ProxyType.Squid => new SquidDbBuilder(fs),
      ProxyType.AptCacher => new AptCacherDbBuilder(fs),
      _ => throw new NotSupportedException($"Unknown proxy type: {proxyType}")
    };
  }
}