using FedoraMirrorGrabber.Core.Uris;

namespace FedoraMirrorGrabber.Core;

public class MirrorListRetriever
{
  #region Data

  private readonly HttpClient _client;
  private readonly ResponseProcessor _processor;

  #endregion

  #region Constructors
  
  public MirrorListRetriever(HttpClient client, ResponseProcessor processor)
  {
    _client = client;
    _processor = processor;
  }

  #endregion

  #region APIs

  /// <summary>
  ///   Process a list of <see cref="MirrorUriTemplateBase"/>, and returns a list of <see cref="Mirror"/> for each of them. 
  /// </summary>
  /// <param name="uris">A list of <see cref="MirrorUriTemplateBase"/></param>
  /// <param name="baseArch">The architecture to retrieve mirrors for, e.g. "x86_64"</param>
  /// <param name="releaseVersion">The version to retrieve mirrors for, e.g. "37"</param>
  /// <returns></returns>
  public async IAsyncEnumerable<IEnumerable<Mirror>> GetMirrors(IEnumerable<MirrorUriTemplateBase> uris, string baseArch, int releaseVersion)
  {
    foreach (var uriTemplate in uris)
    {
      var content = await _client.GetStringAsync(uriTemplate.Resolve(releaseVersion, baseArch));

      yield return _processor.Run(content);
    }
  }

  #endregion
}