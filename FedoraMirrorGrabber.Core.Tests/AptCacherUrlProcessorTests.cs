using FedoraMirrorGrabber.Core.Builders;

namespace FedoraMirrorGrabber.Core.Tests;

[TestFixture]
public class AptCacherUrlProcessorTests
{
  private static IEnumerable<TestCaseData> ReleaseUrlsTestCases
  {
    get {
      yield return new TestCaseData(
        "http://creeperhost.mm.fcix.net/fedora/linux/releases/37/Everything/x86_64/os/repodata/repomd.xml",
        "http://creeperhost.mm.fcix.net/fedora/linux/");

      yield return new TestCaseData(
        "https://mirror.vpsnet.com/fedora/linux/releases/37/Everything/x86_64/os/repodata/repomd.xml",
        "https://mirror.vpsnet.com/fedora/linux/");
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
    var result = _sut.Process(url);
    
    // assert
    Assert.That(result, Is.EqualTo(regex));
  }
}