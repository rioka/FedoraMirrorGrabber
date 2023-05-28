using FedoraMirrorGrabber.App;
using FedoraMirrorGrabber.Core;
using FedoraMirrorGrabber.Core.Uris;
using Microsoft.Extensions.Logging;
using System.IO.Abstractions;

internal partial class Program
{
  public static async Task Run(Options options)
  {
    _logger.LogInformation("Generating database for Squid StoreId for Fedora {ReleaseVersion} ({Architecture})", options.ReleaseVersion, options.Architecture);

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

    var fs = new FileSystem();
    var builder = new DbBuilder(fs);
    _logger.LogInformation("Saving database to {OutputFile}", options.SaveTo);
    await builder.Save(options.SaveTo, options.Architecture, options.ReleaseVersion, allMirrors, filter);
  }
}