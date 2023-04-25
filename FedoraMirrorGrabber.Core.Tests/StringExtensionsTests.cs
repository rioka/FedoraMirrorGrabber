namespace FedoraMirrorGrabber.Core.Tests;

[TestFixture]
public class StringExtensionsTests
{
  [Test]
  public void TrimAt_removes_trailing_part()
  {
    // arrange
    var pattern = "/x86_64";
    var sut = "http://creeperhost.mm.fcix.net/fedora/linux/releases/37/Everything/x86_64/os/repodata/repomd.xml";
    
    // act
    var result = sut.TrimAt(pattern);

    // assert
    Assert.That(result, Is.EqualTo("http://creeperhost.mm.fcix.net/fedora/linux/releases/37/Everything"));
  }

  [Test]
  public void EscapeForRegex_escapes_characters_with_special_meaning()
  {
    // arrange
    var sut = "http://creeperhost.mm.fcix.net/fedora/linux/releases/37/Everything";
    
    // act
    var result = sut.EscapeForRegex();
    
    // assert
    Assert.That(result, Is.EqualTo(@"http:\/\/creeperhost\.mm\.fcix\.net\/fedora\/linux\/releases\/37\/Everything"));
  }
}