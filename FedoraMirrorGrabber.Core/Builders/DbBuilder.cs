using Microsoft.Extensions.Logging;
using System.IO.Abstractions;

namespace FedoraMirrorGrabber.Core.Builders;

public class DbBuilder
{
  private readonly IFileSystem _fileSystem;
  private readonly IUrlProcessor _urlProcessor;
  private readonly ILogger<DbBuilder> _logger;

  public DbBuilder(IFileSystem fileSystem, IUrlProcessor urlProcessor, ILogger<DbBuilder> logger)
  {
    _fileSystem = fileSystem;
    _urlProcessor = urlProcessor;
    _logger = logger;
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
          _logger.LogWarning("Skipping unrecognized url '{Url}' (using {Processor})", mirror.Url, _urlProcessor.GetType().Name);
        }
      }

      await stream.FlushAsync();
    }
  }

}