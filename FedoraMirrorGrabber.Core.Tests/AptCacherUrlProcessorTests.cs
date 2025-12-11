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

      // rpmfusion
      yield return new TestCaseData(
        "https://mirror.netsite.dk/rpmfusion/free/fedora/releases/43/Everything/x86_64/os/repodata/repomd.xml",
        "https://mirror.netsite.dk/rpmfusion/free/fedora/");
      yield return new TestCaseData(
        "http://mirror.netsite.dk/rpmfusion/nonfree/fedora/releases/43/Everything/x86_64/os/repodata/repomd.xml",
        "http://mirror.netsite.dk/rpmfusion/nonfree/fedora/");
      yield return new TestCaseData(
        "http://fr2.rpmfind.net/linux/rpmfusion/free/fedora/updates/43/x86_64/repodata/repomd.xml",
        "http://fr2.rpmfind.net/linux/rpmfusion/free/fedora/");
      yield return new TestCaseData(
        "http://rpmfusion.ip-connect.info/nonfree/fedora/updates/43/x86_64/repodata/repomd.xml",
        "http://rpmfusion.ip-connect.info/nonfree/fedora/");
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