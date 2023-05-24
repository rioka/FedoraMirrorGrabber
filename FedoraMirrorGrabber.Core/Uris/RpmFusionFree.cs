namespace FedoraMirrorGrabber.Core.Uris;

public class RpmFusionFree : MirrorUri
{
  public RpmFusionFree(int releaseVer, string baseArch) 
    : base($"https://mirrors.fedoraproject.org/metalink?repo=free-fedora-{releaseVer}&arch={baseArch}")
  { }
}