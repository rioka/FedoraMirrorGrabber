﻿namespace FedoraMirrorGrabber.Core.Uris;

public class RpmFusionNonFreeUpdates : RpmFusionUriTemplate
{
  public static readonly string PathTemplate = $"metalink?repo=nonfree-fedora-updates-released-{ReleasePlaceholder}&arch={BaseArchPlaceholder}"; 

  public static readonly RpmFusionNonFreeUpdates Default = new RpmFusionNonFreeUpdates();

  private RpmFusionNonFreeUpdates() : base(PathTemplate)
  { }

  public RpmFusionNonFreeUpdates(string host) : base(host, PathTemplate)
  { }
}