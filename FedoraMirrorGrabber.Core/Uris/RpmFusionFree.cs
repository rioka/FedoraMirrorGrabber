namespace FedoraMirrorGrabber.Core.Uris;

public class RpmFusionFree : RpmFusionUriTemplate
{
  public static readonly string PathTemplate = $"metalink?repo=free-fedora-{ReleasePlaceholder}&arch={BaseArchPlaceholder}";

  public static readonly RpmFusionFree Default = new RpmFusionFree();

  public override string Name => "RPM Fusion free";

  #region Constructors

  #region Constructors

  private RpmFusionFree() : base(PathTemplate)
  { }

  public RpmFusionFree(string host) : base(host, PathTemplate)
  { }

  #endregion

  #endregion
}