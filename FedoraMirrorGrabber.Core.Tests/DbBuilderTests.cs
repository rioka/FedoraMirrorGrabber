using System.IO.Abstractions;
using System.IO.Abstractions.TestingHelpers;

namespace FedoraMirrorGrabber.Core.Tests;

[TestFixture]
public class DbBuilderTests
{
  private IFileSystem _fileSystem; 
  private DbBuilder _sut;

  [SetUp]
  public void BeforeEach()
  {
    _fileSystem = new MockFileSystem();
    _sut = new DbBuilder(_fileSystem);
  }
  
  [Test]
  public async Task Save_creates_a_file()
  {
    // arrange
    var mirrors = new List<Mirror>() {
      new Mirror("http://creeperhost.mm.fcix.net/fedora/linux/releases/37/Everything/x86_64/os/repodata/repomd.xml", RepositoryType.Http), 
      new Mirror("https://mirror.vpsnet.com/fedora/linux/releases/37/Everything/x86_64/os/repodata/repomd.xml", RepositoryType.Https) 
    };
    
    // act
    await _sut.Save("fedora.db", "x86_64", 37, mirrors); 
    
    // assert
    var lines = await _fileSystem.File.ReadAllLinesAsync("fedora.db");
    Assert.That(lines.Count(), Is.EqualTo(2));
    Assert.That(lines[0], Is.EqualTo(@"^http:\/\/creeperhost\.mm\.fcix\.net\/fedora\/linux\/releases\/37\/Everything\/(x86_64\/[a-zA-Z0-9\-\_\.\/]+\.d?rpm)$	http://repo.mirrors.squid.internal/fedora/37/$1"));
    Assert.That(lines[1], Is.EqualTo(@"^https:\/\/mirror\.vpsnet\.com\/fedora\/linux\/releases\/37\/Everything\/(x86_64\/[a-zA-Z0-9\-\_\.\/]+\.d?rpm)$	http://repo.mirrors.squid.internal/fedora/37/$1"));
  }  
}