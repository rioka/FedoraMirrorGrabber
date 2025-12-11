namespace FedoraMirrorGrabber.Core.Builders;

public class AptCacherUrlProcessor : IUrlProcessor
{
  private readonly string[] _patterns;

  public AptCacherUrlProcessor(int releaseVersion)
  {
    _patterns = new [] {
      $"/releases/{releaseVersion}/",
      $"/updates/{releaseVersion}/"
    };
  }

  #region IUrlProcessor

  public string Process(string url)
  {
    foreach (var pattern in _patterns)
    {
      var (result, found) = url.TrimAt(pattern, 1);
      if (found)
      {
        return result;
      }
    }
    
    return url;
  }

  #endregion
}