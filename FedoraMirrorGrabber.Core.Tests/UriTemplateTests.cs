using FedoraMirrorGrabber.Core.Uris;

namespace FedoraMirrorGrabber.Core.Tests;

[TestFixture]
public class UriTemplateTests
{
  [Test]
  public void Release_resolves_to_expected_url()
  {
    // arrange
    var sut = new Release();

    // act
    var result = sut.Resolve(37, "arm");

    // assert
    Assert.That(result, Is.EqualTo(new Uri("https://mirrors.fedoraproject.org/metalink?repo=fedora-37&arch=arm")));
  }
  
  [Test]
  public void Release_resolves_to_expected_url_with_a_custom_host()
  {
    // arrange
    var sut = new Release("http://localhost/");

    // act
    var result = sut.Resolve(37, "arm");

    // assert
    Assert.That(result, Is.EqualTo(new Uri("http://localhost/metalink?repo=fedora-37&arch=arm")));
  }
  
  [Test]
  public void Updates_resolves_to_expected_url()
  {
    // arrange
    var sut = new Updates();

    // act
    var result = sut.Resolve(37, "arm");

    // assert
    Assert.That(result, Is.EqualTo(new Uri("https://mirrors.fedoraproject.org/metalink?repo=updates-released-f37&arch=arm")));
  }
  
  [Test]
  public void Updates_resolves_to_expected_url_with_a_custom_host()
  {
    // arrange
    var sut = new Updates("http://localhost/");

    // act
    var result = sut.Resolve(37, "arm");

    // assert
    Assert.That(result, Is.EqualTo(new Uri("http://localhost/metalink?repo=updates-released-f37&arch=arm")));
  }
  
  [Test]
  public void RpmFusionFree_resolves_to_expected_url()
  {
    // arrange
    var sut = new RpmFusionFree();

    // act
    var result = sut.Resolve(37, "arm");

    // assert
    Assert.That(result, Is.EqualTo(new Uri("https://mirrors.rpmfusion.org/metalink?repo=free-fedora-37&arch=arm")));
  }
  
  [Test]
  public void RpmFusionFree_resolves_to_expected_url_with_a_custom_host()
  {
    // arrange
    var sut = new RpmFusionFree("http://localhost/");

    // act
    var result = sut.Resolve(37, "arm");

    // assert
    Assert.That(result, Is.EqualTo(new Uri("http://localhost/metalink?repo=free-fedora-37&arch=arm")));
  }
  
  [Test]
  public void RpmFusionNonFree_resolves_to_expected_url()
  {
    // arrange
    var sut = new RpmFusionNonFree();

    // act
    var result = sut.Resolve(37, "arm");

    // assert
    Assert.That(result, Is.EqualTo(new Uri("https://mirrors.rpmfusion.org/metalink?repo=nonfree-fedora-37&arch=arm")));
  }
  
  [Test]
  public void RpmFusionNonFree_resolves_to_expected_url_with_a_custom_host()
  {
    // arrange
    var sut = new RpmFusionNonFree("http://localhost/");

    // act
    var result = sut.Resolve(37, "arm");

    // assert
    Assert.That(result, Is.EqualTo(new Uri("http://localhost/metalink?repo=nonfree-fedora-37&arch=arm")));
  }
  
  [Test]
  public void RpmFusionFreeUpdates_resolves_to_expected_url()
  {
    // arrange
    var sut = new RpmFusionFreeUpdates();

    // act
    var result = sut.Resolve(37, "arm");

    // assert
    Assert.That(result, Is.EqualTo(new Uri("https://mirrors.rpmfusion.org/metalink?repo=free-fedora-updates-released-37&arch=arm")));
  }
  
  [Test]
  public void RpmFusionFreeUpdates_resolves_to_expected_url_with_a_custom_host()
  {
    // arrange
    var sut = new RpmFusionFreeUpdates("http://localhost/");

    // act
    var result = sut.Resolve(37, "arm");

    // assert
    Assert.That(result, Is.EqualTo(new Uri("http://localhost/metalink?repo=free-fedora-updates-released-37&arch=arm")));
  }
  
  [Test]
  public void RpmFusionNonFreeUpdates_resolves_to_expected_url()
  {
    // arrange
    var sut = new RpmFusionNonFreeUpdates();

    // act
    var result = sut.Resolve(37, "arm");

    // assert
    Assert.That(result, Is.EqualTo(new Uri("https://mirrors.rpmfusion.org/metalink?repo=nonfree-fedora-updates-released-37&arch=arm")));
  }
  
  [Test]
  public void RpmFusionNonFreeUpdates_resolves_to_expected_url_with_a_custom_host()
  {
    // arrange
    var sut = new RpmFusionNonFreeUpdates("http://localhost/");

    // act
    var result = sut.Resolve(37, "arm");

    // assert
    Assert.That(result, Is.EqualTo(new Uri("http://localhost/metalink?repo=nonfree-fedora-updates-released-37&arch=arm")));
  }
}