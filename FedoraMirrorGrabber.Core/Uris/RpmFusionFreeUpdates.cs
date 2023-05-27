namespace FedoraMirrorGrabber.Core.Uris;

public class RpmFusionFreeUpdates : RpmFusionUriTemplate
{
  public static readonly RpmFusionFreeUpdates Default = new RpmFusionFreeUpdates();
    
  public static readonly string PathTemplate = $"metalink?repo=free-fedora-updates-released-{ReleasePlaceholder}&arch={BaseArchPlaceholder}";

  private RpmFusionFreeUpdates() : base(PathTemplate)
  { }

  public RpmFusionFreeUpdates(string host) : base(host, PathTemplate)
  { }
}