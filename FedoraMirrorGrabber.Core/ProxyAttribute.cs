namespace FedoraMirrorGrabber.Core;

[AttributeUsage(AttributeTargets.Field)]
public class ProxyAttribute : Attribute
{
  public string Name { get; }

  public ProxyAttribute(string name)
  {
    Name = name;
  }
}