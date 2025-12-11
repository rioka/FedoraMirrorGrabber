using System.Diagnostics.CodeAnalysis;

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

  public bool TryProcess(string url, [NotNullWhen(true)] out string? processedUrl)
  {
    if (url is null)
    {
      throw new ArgumentNullException(nameof(url));
    }

    foreach (var pattern in _patterns)
    {
      var (result, found) = url.TrimAt(pattern, 1);
      if (found)
      {
        processedUrl = result;
        return true;
      }
    }

    processedUrl = default;
    return false;
  }

  #endregion
}