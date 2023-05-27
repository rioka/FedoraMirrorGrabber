namespace FedoraMirrorGrabber.Core.Uris;

public class Release : FedoraUriTemplate
{
  public readonly static string PathTemplate = $"metalink?repo=fedora-{ReleasePlaceholder}&arch={BaseArchPlaceholder}";
  
  public Release() : base(PathTemplate) 
  { }

  public Release(string host) : base(host, PathTemplate)
  { }
}