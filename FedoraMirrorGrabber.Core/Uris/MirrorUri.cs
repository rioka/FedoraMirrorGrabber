namespace FedoraMirrorGrabber.Core.Uris;

public abstract class MirrorUri
{
  public string Host { get; }

  protected MirrorUri(string host)
  {
    Host = host;
  }

  public static IList<MirrorUri> Parse(string file, int releaseVer, string baseArch)
  {
    throw new NotImplementedException();
  }
}