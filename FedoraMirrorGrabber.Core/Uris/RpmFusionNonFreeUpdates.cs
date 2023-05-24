namespace FedoraMirrorGrabber.Core.Uris;

public class RpmFusionNonFreeUpdates : MirrorUri
{
  public RpmFusionNonFreeUpdates(int releaseVer, string baseArch) 
    : base($"https://mirrors.rpmfusion.org/metalink?repo=nonfree-fedora-updates-released-{releaseVer}&arch={baseArch}")
  { }
}