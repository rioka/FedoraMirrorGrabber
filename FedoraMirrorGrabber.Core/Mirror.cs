using System.Diagnostics.CodeAnalysis;

namespace FedoraMirrorGrabber.Core;

public class Mirror
{
  [SuppressMessage("NDepend", "ND2209:UriFieldsShouldBeOfTypeSystemUri", Justification="This is a string representation of a URI.")]
  public string Url { get; }

  public RepositoryType Type { get; }

  public Mirror(string url, RepositoryType type)
  {
    Url = url;
    Type = type;
  }
}