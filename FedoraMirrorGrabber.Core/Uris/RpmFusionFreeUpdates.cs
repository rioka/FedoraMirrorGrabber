namespace FedoraMirrorGrabber.Core.Uris;

public class RpmFusionFreeUpdates : MirrorUri
{
  public RpmFusionFreeUpdates(int releaseVer, string baseArch) 
    : base($"https://mirrors.rpmfusion.org/metalink?repo=free-fedora-updates-released-{releaseVer}&arch={baseArch}")
  { }
}