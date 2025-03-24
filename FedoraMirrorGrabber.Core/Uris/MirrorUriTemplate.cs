namespace FedoraMirrorGrabber.Core.Uris;

public abstract class MirrorUriTemplate
{
  protected static readonly string ReleasePlaceholder = "{releaseVer}";
  protected static readonly string BaseArchPlaceholder = "{baseArch}";
  
  public string Host { get; }
  
  public string Path { get; } 
  
  protected MirrorUriTemplate(string host, string path)
  {
    Host = host;
    Path = path;
  }

  public Uri Resolve(int releaseVer, string baseArch)
  {
    return new Uri(new Uri(Host), ResolvePath(releaseVer, baseArch));
  }

  private string ResolvePath(int releaseVer, string baseArch)
  {
    return Path
      .Replace(ReleasePlaceholder, $"{releaseVer}")
      .Replace(BaseArchPlaceholder, baseArch);
  }
}