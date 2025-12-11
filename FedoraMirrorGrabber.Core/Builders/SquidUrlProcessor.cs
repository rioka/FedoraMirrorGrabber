using System.Text;

namespace FedoraMirrorGrabber.Core.Builders;

public class SquidUrlProcessor : IUrlProcessor
{
  private readonly string _baseArch;
  private readonly int _releaseVersion;
  private readonly string _pattern;

  public SquidUrlProcessor(string baseArch, int releaseVersion)
  {
    _baseArch = baseArch;
    _releaseVersion = releaseVersion;
    _pattern = $"/{baseArch}";
  }

  #region IUrlProcessor

  public bool TryProcess(string url, out string? result)
  {
    var (trimmedUrl, patternFound) = url.TrimAt(_pattern);
    if (patternFound)
    {
      trimmedUrl = trimmedUrl.EscapeForRegex();

      var regex = BuildRegex(trimmedUrl, _baseArch);
      result = BuildStoreIdEntry(regex, _releaseVersion);
      return true;
    }

    result = default;
    return false;
  }

  #endregion

  #region Internals

  private StringBuilder BuildRegex(string url, string baseArch)
  {
    return new StringBuilder()
      .Append('^') // beginning of pattern
      .Append(url) // url with escaped characters and trailing part removed
      .Append($@"\/({baseArch}\/[a-zA-Z0-9\-\_\.\/]+\.d?rpm)"); // regex for packages
    // There may be other data after the URL, so we do not append "$" to the regex 
  }

  private string BuildStoreIdEntry(StringBuilder regex, int releaseVer)
  {
    return regex
      .Append('\t')  // separate pattern from replacement 
      .Append($"http://repo.mirrors.squid.internal/fedora/{releaseVer}/$1") // store ID replacement pattern
      .ToString();
  }    

  #endregion
}