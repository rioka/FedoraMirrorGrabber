namespace FedoraMirrorGrabber.Core.Uris;

public class RpmFusionNonFreeUpdates : RpmFusionUriTemplate
{
  public readonly static string PathTemplate = $"metalink?repo=nonfree-fedora-updates-released-{ReleasePlaceholder}&arch={BaseArchPlaceholder}"; 
  
  public RpmFusionNonFreeUpdates() : base(PathTemplate)
  { }

  public RpmFusionNonFreeUpdates(string host) : base(host, PathTemplate)
  { }
}