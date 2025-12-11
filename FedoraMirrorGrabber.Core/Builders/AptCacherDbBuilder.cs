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
      var pattern = $"/releases/{releaseVersion}/";

      foreach (var mirror in mirrors
                 .Where(m => selector(m)))
      {
        await stream.WriteLineAsync(mirror.Url.TrimAt(pattern, 1).Result);
      }

      await stream.FlushAsync();
    }
  }

  #endregion
}