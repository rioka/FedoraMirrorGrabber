using FedoraMirrorGrabber.Core;
using Microsoft.Extensions.DependencyInjection;
using System.IO.Abstractions;

internal class Program
{
  public static async Task<int> Main(string[] args)
  {
    var registrations = new ServiceCollection();
    registrations
      .AddSingleton<MirrorListRetriever>()
      .AddSingleton<IFileSystem, FileSystem>()
      .AddSingleton<DbBuilder>();
    
    var registrar = new TypeRegistrar(registrations);
    
  }
}