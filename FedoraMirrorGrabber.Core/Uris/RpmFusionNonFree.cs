namespace FedoraMirrorGrabber.Core.Uris;

public class RpmFusionNonFree : RpmFusionUriTemplate
{
  public static readonly string PathTemplate = $"metalink?repo=nonfree-fedora-{ReleasePlaceholder}&arch={BaseArchPlaceholder}";

  public static readonly RpmFusionNonFree Default = new RpmFusionNonFree();

  public override string Name => "RPM Fusion nonfree";

  #region Constructors

  private RpmFusionNonFree() : base(PathTemplate)
  { }

  public RpmFusionNonFree(string host) : base(host, PathTemplate)
  { }

  #endregion
}