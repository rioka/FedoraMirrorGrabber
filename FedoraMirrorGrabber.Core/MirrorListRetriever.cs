namespace FedoraMirrorGrabber.Core;

public class MirrorListRetriever
{
  #region Data

  public static readonly string Host = "https://mirrors.fedoraproject.org/";
  private readonly HttpClient _client;
  private readonly ResponseProcessor _processor;

  #endregion

  public Uri BaseAddress { get; set; }

  #region Constructors
  
  public MirrorListRetriever(HttpClient client, ResponseProcessor processor)
  {
    _client = client;
    _processor = processor;
    BaseAddress = new Uri(Host);
  }

  #endregion

  #region APIs

  public async Task<IEnumerable<Mirror>> GetMirrors(string baseArch, int releaseVersion)
  {
    _client.BaseAddress = new Uri("https://mirrors.fedoraproject.org/");
    var content = await _client.GetStringAsync($"metalink?repo=fedora-{releaseVersion}&arch={baseArch}");

    return _processor.Run(content);
  }

  #endregion
}