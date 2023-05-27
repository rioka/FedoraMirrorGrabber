namespace FedoraMirrorGrabber.Core.Uris;

public class Release : FedoraUriTemplate
{
  public static readonly Release Default = new Release();
  
  public static readonly string PathTemplate = $"metalink?repo=fedora-{ReleasePlaceholder}&arch={BaseArchPlaceholder}";

  private Release() : base(PathTemplate) 
  { }

  public Release(string host) : base(host, PathTemplate)
  { }
}