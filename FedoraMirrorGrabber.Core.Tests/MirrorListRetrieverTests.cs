using FedoraMirrorGrabber.Core.Tests.Internals;
using System.Reflection;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;

namespace FedoraMirrorGrabber.Core.Tests;

[TestFixture]
public class MirrorListRetrieverTests
{
  #region Data

  private HttpClient _client;
  private ResponseProcessor _processor;
  private WireMockServer _server;
  private MirrorListRetriever _sut;

  #endregion
  
  [SetUp]
  public void BeforeEach()
  {
    _server = WireMockServer.Start();
    
    _client = new HttpClient();
    _processor = new ResponseProcessor();

    _sut = new MirrorListRetriever(_client, _processor);
  }

  [TearDown]
  public void AfterEach()
  {
    _client.Dispose();
    _server.Dispose();
  }
  
  [Test]
  public async Task GetMirrors_returns_a_list_of_mirrors()
  {
    // arrange
    _server.Given(Request
        .Create()
        .WithPath("/metalink/*")
        .UsingGet())
      .RespondWith(Response
        .Create()
        .WithBody(Helpers.GetResource($"{Assembly.GetExecutingAssembly().GetName().Name}.Assets.Response.xml"))
        .WithStatusCode(200));
    
    // act
    var result = await _sut.GetMirrors("x86_64", 37);

    // assert
    var mirrors = result.ToList();
    Assert.That(mirrors.Count, Is.EqualTo(109));
    Assert.That(mirrors.Count(m => m.Type == RepositoryType.Http), Is.EqualTo(43));
    Assert.That(mirrors.Count(m => m.Type == RepositoryType.Https), Is.EqualTo(31));
    Assert.That(mirrors.Count(m => m.Type == RepositoryType.RSync), Is.EqualTo(35));
  }  
}