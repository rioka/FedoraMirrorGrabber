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
        if (_urlProcessor.TryProcess(mirror.Url, out var result))
        {
          await stream.WriteLineAsync(result);
        }
        else
        {
          // TODO log warning
        }
        
      }

      await stream.FlushAsync();
    }
  }

}