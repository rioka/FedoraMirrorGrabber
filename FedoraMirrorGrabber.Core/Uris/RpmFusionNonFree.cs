namespace FedoraMirrorGrabber.Core.Uris;

public class RpmFusionNonFree : MirrorUri
{
  public RpmFusionNonFree(int releaseVer, string baseArch) 
    : base($"https://mirrors.rpmfusion.org/metalink?repo=nonfree-fedora-{releaseVer}&arch={baseArch}")
  { }
}