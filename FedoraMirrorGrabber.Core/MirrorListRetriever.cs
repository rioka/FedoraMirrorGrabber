using FedoraMirrorGrabber.Core.Uris;
using Microsoft.Extensions.Logging;

namespace FedoraMirrorGrabber.Core;

public class MirrorListRetriever
{
  #region Data

  private readonly HttpClient _client;
  private readonly ResponseProcessor _processor;
  private readonly ILogger<MirrorListRetriever> _logger;

  #endregion

  #region Constructors

  public MirrorListRetriever(HttpClient client, ResponseProcessor processor, ILogger<MirrorListRetriever> logger)
  {
    _client = client;
    _processor = processor;
    _logger = logger;
  }

  #endregion

  #region APIs

  /// <summary>
  ///   Process a list of <see cref="MirrorUriTemplate"/>, and returns a list of <see cref="Mirror"/> for each of them. 
  /// </summary>
  /// <param name="uris">A list of <see cref="MirrorUriTemplate"/></param>
  /// <param name="baseArch">The architecture to retrieve mirrors for, e.g. "x86_64"</param>
  /// <param name="releaseVersion">The version to retrieve mirrors for, e.g. "37"</param>
  /// <returns></returns>
  public async IAsyncEnumerable<IEnumerable<Mirror>> GetMirrors(IEnumerable<MirrorUriTemplate> uris, string baseArch, int releaseVersion)
  {
    foreach (var uriTemplate in uris)
    {
      var url = uriTemplate.Resolve(releaseVersion, baseArch);
      
      _logger.LogInformation("Getting list or mirrors for '{Repository}'", uriTemplate.Name);
      _logger.LogTrace("Getting '{URL}'", url);
      var content = await _client.GetStringAsync(url);

      _logger.LogInformation("Processing response from '{Repository}'", uriTemplate.Name);
      yield return _processor.Run(content);
    }
  }

  #endregion
}