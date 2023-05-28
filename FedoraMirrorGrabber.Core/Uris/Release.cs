namespace FedoraMirrorGrabber.Core.Uris;

public class Release : FedoraUriTemplate
{
  public static readonly string PathTemplate = $"metalink?repo=fedora-{ReleasePlaceholder}&arch={BaseArchPlaceholder}";

  /// <summary>
  ///   Default instance
  /// </summary>
  /// <remarks>
  /// <para>Do not move, order is important, or <see cref="PathTemplate"/> will not be set.</para>
  /// <para>See https://stackoverflow.com/a/53020008</para>
  /// </remarks>
  public static readonly Release Default = new Release();
  
  private Release() : base(PathTemplate) 
  { }

  public Release(string host) : base(host, PathTemplate)
  { }
}