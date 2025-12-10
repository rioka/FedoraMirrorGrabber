namespace FedoraMirrorGrabber.Core;

public enum ProxyType
{
  [Proxy("squid")]
  Squid,

  [Proxy("apt-cacher-ng")]
  AptCacher
}