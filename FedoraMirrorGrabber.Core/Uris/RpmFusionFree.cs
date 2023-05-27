namespace FedoraMirrorGrabber.Core.Uris;

public class RpmFusionFree : RpmFusionUriTemplate
{
  public static readonly RpmFusionFree Default = new RpmFusionFree();
  
  public static readonly string PathTemplate = $"metalink?repo=free-fedora-{ReleasePlaceholder}&arch={BaseArchPlaceholder}";

  private RpmFusionFree() : base(PathTemplate)
  { }

  public RpmFusionFree(string host) : base(host, PathTemplate)
  { }
}