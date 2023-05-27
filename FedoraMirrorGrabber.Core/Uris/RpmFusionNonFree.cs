namespace FedoraMirrorGrabber.Core.Uris;

public class RpmFusionNonFree : RpmFusionUriTemplate
{
  public readonly static string PathTemplate = $"metalink?repo=nonfree-fedora-{ReleasePlaceholder}&arch={BaseArchPlaceholder}"; 
  
  public RpmFusionNonFree() : base(PathTemplate)
  { }
  
  public RpmFusionNonFree(string host) : base(host, PathTemplate)
  { }
}