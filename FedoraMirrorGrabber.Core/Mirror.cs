namespace FedoraMirrorGrabber.Core;

public class Mirror
{
  public string Url { get; }

  public RepositoryType Type { get; }

  public Mirror(string url, RepositoryType type)
  {
    Url = url;
    Type = type;
  }
}