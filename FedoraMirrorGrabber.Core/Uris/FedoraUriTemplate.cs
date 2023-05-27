namespace FedoraMirrorGrabber.Core.Uris;

public abstract class FedoraUriTemplate : MirrorUriTemplate
{
  private static readonly string HostName = "https://mirrors.fedoraproject.org";

  protected FedoraUriTemplate(string path) : this(HostName, path)
  { }

  protected FedoraUriTemplate(string host, string path) : base(host, path)
  { }
}