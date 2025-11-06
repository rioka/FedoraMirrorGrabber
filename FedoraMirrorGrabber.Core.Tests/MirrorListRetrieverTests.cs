using FedoraMirrorGrabber.Core.Tests.Internals;
using FedoraMirrorGrabber.Core.Uris;
using Microsoft.Extensions.Logging;
using System.Reflection;
using WireMock.Matchers;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;

namespace FedoraMirrorGrabber.Core.Tests;

[TestFixture]
public class MirrorListRetrieverTests
{
  #region Data

  private ILoggerFactory _loggerFactory;
  private HttpClient _client;
  private ResponseProcessor _processor;
  private WireMockServer _server;
  private MirrorListRetriever _sut;

  #endregion

  #region Setup & teardown
  
  [OneTimeSetUp]
  public void BeforeAll()
  {
    _loggerFactory = LoggerFactory.Create(builder => builder.AddDebug());
  }

  [OneTimeTearDown]
  public void AfterAll()
  {
    _loggerFactory.Dispose();
  }
  
  [SetUp]
  public void BeforeEach()
  {
    _server = WireMockServer.Start();

    _client = new HttpClient();
    _processor = new ResponseProcessor();

    _sut = new MirrorListRetriever(_client, _processor, _loggerFactory.CreateLogger<MirrorListRetriever>());
  }

  [TearDown]
  public void AfterEach()
  {
    _client.Dispose();
    _server.Dispose();
  }

  #endregion

  [Test]
  public async Task GetMirrors_returns_a_list_of_mirrors()
  {
    // arrange
    var uris = new MirrorUriTemplate[] {
      new Release(_server.Url!), 
      new Updates(_server.Url!)
    };
    const int release = 37;
    const string arch = "x86_64";
    _server
      .Given(Request
        .Create()
        .WithPath("/metalink")
        .WithParam("repo", new WildcardMatcher("fedora*"))
        .UsingGet())
      .RespondWith(Response
        .Create()
        .WithBody(Helpers.GetResource($"{Assembly.GetExecutingAssembly().GetName().Name}.Assets.ReleaseResponse.xml"))
        .WithStatusCode(200));
    _server
      .Given(Request
        .Create()
        .WithPath("/metalink")
        .WithParam("repo", new WildcardMatcher("updates*"))
        .UsingGet())
      .RespondWith(Response
        .Create()
        .WithBody(Helpers.GetResource($"{Assembly.GetExecutingAssembly().GetName().Name}.Assets.UpdatesResponse.xml"))
        .WithStatusCode(200));

    // act
    var result = new List<Mirror>();
    await foreach (var mirrorList in _sut.GetMirrors(uris, arch, release))
    {
      result.AddRange(mirrorList);
    }

    // assert
    Assert.That(result.Count, Is.EqualTo(188));
    Assert.That(result.Count(m => m.Type == RepositoryType.Http), Is.EqualTo(73));
    Assert.That(result.Count(m => m.Type == RepositoryType.Https), Is.EqualTo(54));
    Assert.That(result.Count(m => m.Type == RepositoryType.RSync), Is.EqualTo(61));
  }
}