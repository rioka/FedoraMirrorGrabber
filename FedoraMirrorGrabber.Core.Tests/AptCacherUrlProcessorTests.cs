using FedoraMirrorGrabber.Core.Builders;

namespace FedoraMirrorGrabber.Core.Tests;

[TestFixture]
public class AptCacherUrlProcessorTests
{
  private static IEnumerable<TestCaseData> ReleaseUrlsTestCases
  {
    get {
      // releases
      yield return new TestCaseData(
        "http://creeperhost.mm.fcix.net/fedora/linux/releases/37/Everything/x86_64/os/repodata/repomd.xml",
        "http://creeperhost.mm.fcix.net/fedora/linux/");

      yield return new TestCaseData(
        "https://mirror.vpsnet.com/fedora/linux/releases/37/Everything/x86_64/os/repodata/repomd.xml",
        "https://mirror.vpsnet.com/fedora/linux/");

      // updates
      yield return new TestCaseData(
        "http://mirrors.xtom.ee/fedora/updates/37/Everything/x86_64/repodata/repomd.xml",
        "http://mirrors.xtom.ee/fedora/");

      yield return new TestCaseData(
        "https://creeperhost.mm.fcix.net/fedora/linux/updates/37/Everything/x86_64/repodata/repomd.xml",
        "https://creeperhost.mm.fcix.net/fedora/linux/");
    }
  }

  private AptCacherUrlProcessor _sut;

  [SetUp]
  public void BeforeEach()
  {
    _sut = new AptCacherUrlProcessor(37);
  }

  [Test]
  [TestCaseSource(nameof(ReleaseUrlsTestCases))]
  public void Url_is_replaced_by_regular_expression(string url, string regex)
  {
    // act
    var processed = _sut.TryProcess(url, out var result);

    // assert
    Assert.That(result, Is.EqualTo(regex));
  }
}