namespace FedoraMirrorGrabber.Core.Uris;

public class RpmFusionNonFree : RpmFusionUriTemplate
{
  public static readonly RpmFusionNonFree Default = new RpmFusionNonFree();
  
  public static readonly string PathTemplate = $"metalink?repo=nonfree-fedora-{ReleasePlaceholder}&arch={BaseArchPlaceholder}";

  private RpmFusionNonFree() : base(PathTemplate)
  { }
  
  public RpmFusionNonFree(string host) : base(host, PathTemplate)
  { }
}