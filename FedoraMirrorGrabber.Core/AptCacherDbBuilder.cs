using System.IO.Abstractions;

namespace FedoraMirrorGrabber.Core;

public class AptCacherDbBuilder : IDbBuilder
{
  private readonly IFileSystem _fileSystem;

  public AptCacherDbBuilder(IFileSystem fileSystem)
  {
    _fileSystem = fileSystem;
  }

  public Task Save(string saveTo, string baseArch, int releaseVersion, IEnumerable<Mirror> mirrors, Func<Mirror, bool>? selector = null)
  {
    throw new NotImplementedException();
  }
}