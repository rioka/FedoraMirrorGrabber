namespace FedoraMirrorGrabber.Core.Uris;

public class Updates : FedoraUriTemplate
{
  public readonly static string PathTemplate = $"metalink?repo=updates-released-f{ReleasePlaceholder}&arch={BaseArchPlaceholder}";
  
  public Updates() : base(PathTemplate)
  { }
  
  public Updates(string host) : base(host, PathTemplate)
  { }
}