namespace FedoraMirrorGrabber.Core.Uris;

public class Updates : FedoraUriTemplate
{
  public static readonly string PathTemplate = $"metalink?repo=updates-released-f{ReleasePlaceholder}&arch={BaseArchPlaceholder}";
  
  public static readonly Updates Default = new Updates();

  private Updates() : base(PathTemplate)
  { }
  
  public Updates(string host) : base(host, PathTemplate)
  { }
}