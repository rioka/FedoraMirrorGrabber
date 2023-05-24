namespace FedoraMirrorGrabber.Core.Uris;

public class ReleaseUri : MirrorUri
{
  public ReleaseUri(int releaseVer, string baseArch) 
    : base($"https://mirrors.fedoraproject.org/metalink?repo=fedora-{releaseVer}&arch={baseArch}")
  { }
}