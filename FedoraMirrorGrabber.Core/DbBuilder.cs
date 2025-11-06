using System.IO.Abstractions;
using System.Text;

namespace FedoraMirrorGrabber.Core;

public class DbBuilder
{
  private readonly IFileSystem _fileSystem;

  #region Constructors

  public DbBuilder(IFileSystem fileSystem)
  {
    _fileSystem = fileSystem;
  }

  #endregion

  #region APIs

  public async Task Save(string saveTo, string baseArch, int releaseVersion, IEnumerable<Mirror> mirrors, Func<Mirror, bool>? selector = null)
  {
    await using (var stream = _fileSystem.File.CreateText(saveTo))
    {
      selector ??= _ => true;
      var pattern = $"/{baseArch}";

      foreach (var mirror in mirrors
                 .Where(m => selector(m)))
      {
        var url = mirror.Url;
        url = url
          .TrimAt(pattern)
          .EscapeForRegex();

        var regex = BuildRegex(url, baseArch);
        var entry = BuildStoreIdEntry(regex, releaseVersion);
        await stream.WriteAsync(entry);
      }

      await stream.FlushAsync();
    }
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