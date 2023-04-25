using FedoraMirrorGrabber.Core.Tests.Internals;
using System.Reflection;

namespace FedoraMirrorGrabber.Core.Tests;

[TestFixture]
public class ResponseProcessorTests
{
  [Test]
  public void Run_returns_a_list_of_mirrors()
  {
    // arrange
    var sut = new ResponseProcessor();
    var content = Helpers.GetResource($"{Assembly.GetExecutingAssembly().GetName().Name}.Assets.Response.xml");

    // act
    var result = sut.Run(content);

    // assert
    var mirrors = result.ToList();
    Assert.That(mirrors.Count, Is.EqualTo(109));
    Assert.That(mirrors.Count(m => m.Type == RepositoryType.Http), Is.EqualTo(43));
    Assert.That(mirrors.Count(m => m.Type == RepositoryType.Https), Is.EqualTo(31));
    Assert.That(mirrors.Count(m => m.Type == RepositoryType.RSync), Is.EqualTo(35));
  }    
}