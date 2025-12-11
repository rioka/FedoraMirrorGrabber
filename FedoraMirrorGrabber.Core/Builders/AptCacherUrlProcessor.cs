namespace FedoraMirrorGrabber.Core.Builders;

public class AptCacherUrlProcessor : IUrlProcessor
{
  private readonly string _pattern;

  public AptCacherUrlProcessor(int releaseVersion)
  {
    _pattern = $"/releases/{releaseVersion}/";
  }

  #region IUrlProcessor

  public string Process(string url) => url.TrimAt(_pattern, 1);

  #endregion
}