using FedoraMirrorGrabber.Core.Builders;

namespace FedoraMirrorGrabber.Core.Tests;

[TestFixture]
public class SquidUrlProcessorTests
{
  private static IEnumerable<TestCaseData> ReleaseUrlsTestCases
  {
    get {
      yield return new TestCaseData(
        "http://creeperhost.mm.fcix.net/fedora/linux/releases/37/Everything/x86_64/os/repodata/repomd.xml",
        @"^http:\/\/creeperhost\.mm\.fcix\.net\/fedora\/linux\/releases\/37\/Everything\/(x86_64\/[a-zA-Z0-9\-\_\.\/]+\.d?rpm)	http://repo.mirrors.squid.internal/fedora/37/$1");

      yield return new TestCaseData(
        "https://mirror.vpsnet.com/fedora/linux/releases/37/Everything/x86_64/os/repodata/repomd.xml",
        @"^https:\/\/mirror\.vpsnet\.com\/fedora\/linux\/releases\/37\/Everything\/(x86_64\/[a-zA-Z0-9\-\_\.\/]+\.d?rpm)	http://repo.mirrors.squid.internal/fedora/37/$1");
    }
  }

  private SquidUrlProcessor _sut;

  [SetUp]
  public void BeforeEach()
  {
    _sut = new SquidUrlProcessor("x86_64", 37);
  }
  
  [Test]
  [TestCaseSource(nameof(ReleaseUrlsTestCases))]
  public void Url_is_replaced_by_regular_expression(string url, string regex)
  {
    // act
    var found = _sut.TryProcess(url, out var result);
    
    // assert
    Assert.That(result, Is.EqualTo(regex));
  }
}