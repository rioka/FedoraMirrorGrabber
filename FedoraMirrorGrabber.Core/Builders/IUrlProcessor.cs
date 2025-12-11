namespace FedoraMirrorGrabber.Core.Builders;

public interface IUrlProcessor
{
  bool TryProcess(string url, out string? result);    
}