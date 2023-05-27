namespace FedoraMirrorGrabber.Core.Uris;

public class RpmFusionFreeUpdates : RpmFusionUriTemplate
{
  public readonly static string PathTemplate = $"metalink?repo=free-fedora-updates-released-{ReleasePlaceholder}&arch={BaseArchPlaceholder}"; 
  
  public RpmFusionFreeUpdates() : base(PathTemplate)
  { }

  public RpmFusionFreeUpdates(string host) : base(host, PathTemplate)
  { }
}