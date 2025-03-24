namespace FedoraMirrorGrabber.Core.Uris;

public abstract class RpmFusionUriTemplate : MirrorUriTemplateBase
{
  private static readonly string HostName = "https://mirrors.rpmfusion.org";

  protected RpmFusionUriTemplate(string path) : this(HostName, path)
  { }

  protected RpmFusionUriTemplate(string host, string path): base(host, path)
  { }
}