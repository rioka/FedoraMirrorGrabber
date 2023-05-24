namespace FedoraMirrorGrabber.Core.Uris;

public class UpdatesUri : MirrorUri
{
  public UpdatesUri(int releaseVer, string baseArch) 
    : base($"https://mirrors.fedoraproject.org/metalink?repo=updates-released-f{releaseVer}&arch={baseArch}")
  { }
}