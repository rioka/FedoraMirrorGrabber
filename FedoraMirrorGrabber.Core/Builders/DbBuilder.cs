using System.IO.Abstractions;

namespace FedoraMirrorGrabber.Core.Builders;

public class DbBuilder
{
  private readonly IFileSystem _fileSystem;
  private readonly IUrlProcessor _urlProcessor;

  public DbBuilder(IFileSystem fileSystem, IUrlProcessor urlProcessor)
  {
    _fileSystem = fileSystem;
    _urlProcessor = urlProcessor;
  }

  public async Task Save(string saveTo, IEnumerable<Mirror> mirrors, Func<Mirror, bool>? selector = null)
  {
    await using (var stream = _fileSystem.File.CreateText(saveTo))
    {
      selector ??= _ => true;

      foreach (var mirror in mirrors
                 .Where(m => selector(m)))
      {
        await stream.WriteLineAsync(_urlProcessor.Process(mirror.Url));
      }

      await stream.FlushAsync();
    }
  }

}