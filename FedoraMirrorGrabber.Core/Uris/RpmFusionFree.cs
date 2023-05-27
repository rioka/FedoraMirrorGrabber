namespace FedoraMirrorGrabber.Core.Uris;

public class RpmFusionFree : RpmFusionUriTemplate
{
  public readonly static string PathTemplate = $"metalink?repo=free-fedora-{ReleasePlaceholder}&arch={BaseArchPlaceholder}"; 
  
  public RpmFusionFree() : base(PathTemplate)
  { }

  public RpmFusionFree(string host) : base(host, PathTemplate)
  { }
}