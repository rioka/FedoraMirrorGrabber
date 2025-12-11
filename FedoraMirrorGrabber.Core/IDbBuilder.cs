namespace FedoraMirrorGrabber.Core
{
  public interface IDbBuilder
  {
    Task Save(string saveTo, string baseArch, int releaseVersion, IEnumerable<Mirror> mirrors, Func<Mirror, bool>? selector = null);
  }
}