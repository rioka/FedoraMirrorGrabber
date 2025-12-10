using System.IO.Abstractions;

namespace FedoraMirrorGrabber.Core.Builders;

public class AptCacherDbBuilder : IDbBuilder
{
  private readonly IFileSystem _fileSystem;

  public AptCacherDbBuilder(IFileSystem fileSystem)
  {
    _fileSystem = fileSystem;
  }

  #region IDbBuilder

  public async Task Save(string saveTo, string baseArch, int releaseVersion, IEnumerable<Mirror> mirrors, Func<Mirror, bool>? selector = null)
  {
    await using (var stream = _fileSystem.File.CreateText(saveTo))
    {
      selector ??= _ => true;
      // TODO check if this is the correct tag to look for
      var pattern = $"/{baseArch}";

      foreach (var mirror in mirrors
                 .Where(m => selector(m)))
      {
        // var regex = BuildRegex(url, baseArch);
        // var entry = BuildStoreIdEntry(regex, releaseVersion);
        await stream.WriteAsync(mirror.Url.TrimAt(pattern));
      }
      
      await stream.FlushAsync();
    }
  }

  #endregion
}