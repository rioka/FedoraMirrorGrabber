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

  public string Process(string url)
  {
    url = url
      .TrimAt(_pattern)
      .EscapeForRegex();

    var regex = BuildRegex(url, _baseArch);
    return BuildStoreIdEntry(regex, _releaseVersion);
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
      .Append('\n')
      .ToString();
  }    

  #endregion
}