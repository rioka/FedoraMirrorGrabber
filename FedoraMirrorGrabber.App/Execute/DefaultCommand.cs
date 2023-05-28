using FedoraMirrorGrabber.Core;
using FedoraMirrorGrabber.Core.Uris;
using Microsoft.Extensions.Logging;
using Spectre.Console.Cli;

namespace FedoraMirrorGrabber.App.Execute;

internal class DefaultCommand : AsyncCommand<Settings>
{
  private readonly MirrorListRetriever _retriever;
  private readonly DbBuilder _builder;
  private readonly ILogger<DefaultCommand> _logger;

  #region Constructors

  public DefaultCommand(MirrorListRetriever retriever, DbBuilder builder, ILogger<DefaultCommand> logger)
  {
    _retriever = retriever;
    _builder = builder;
    _logger = logger;
  }

  #endregion

  #region Overrides

  public override async Task<int> ExecuteAsync(CommandContext context, Settings settings)
  {
    var allMirrors = new List<Mirror>();
    await foreach (var mirrors in _retriever.GetMirrors(MirrorUriTemplate.All, settings.Architecture, settings.ReleaseVersion))
    {
      allMirrors.AddRange(mirrors);
    }

    Func<Mirror, bool>? filter = default;
    if (settings.Protocols is not null && settings.Protocols.Any())
    {
      filter = m => settings.Protocols.Contains(m.Type);
    }

    await _builder.Save(settings.SaveTo, settings.Architecture, settings.ReleaseVersion, allMirrors, filter);

    return 0;
  }

  #endregion
}