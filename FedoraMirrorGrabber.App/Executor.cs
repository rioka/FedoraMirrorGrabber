using FedoraMirrorGrabber.Core;
using FedoraMirrorGrabber.Core.Uris;
using Microsoft.Extensions.Logging;

namespace FedoraMirrorGrabber.App;

internal class Executor
{
  private readonly MirrorListRetriever _retriever;
  private readonly IDbBuilder _builder;
  private readonly ILogger<Executor> _logger;

  public Executor(MirrorListRetriever retriever, IDbBuilder builder, ILogger<Executor> logger)
  {
    _retriever = retriever;
    _builder = builder;
    _logger = logger;
  }

  public async Task<int> Run(Options options)
  {
    var allMirrors = new List<Mirror>();
    await foreach (var mirrors in _retriever.GetMirrors(MirrorUriTemplate.All, options.Architecture, options.ReleaseVersion))
    {
      allMirrors.AddRange(mirrors);
    }

    Func<Mirror, bool>? filter = default;
    if (options.Protocols is not null && options.Protocols.Any())
    {
      filter = m => options.Protocols.Contains(m.Type);
    }

    await _builder.Save(options.SaveTo, options.Architecture, options.ReleaseVersion, allMirrors, filter);

    return 0;
  }     
}