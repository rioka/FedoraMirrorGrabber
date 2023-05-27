using CommandLine;
using FedoraMirrorGrabber.App;
using FedoraMirrorGrabber.Core;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.IO.Abstractions;

internal partial class Program
{
  public static async Task Main(string[] args)
  {
    using (var parser = new Parser(config => {
               config.CaseInsensitiveEnumValues = true;
             }))
    {
      await parser
        .ParseArguments<Options>(args)
        .WithParsedAsync(Run);
    }
  }
  
  private static IHostBuilder CreateHostBuilder(string[] args)
  {
    var builder = Host
      .CreateDefaultBuilder(args)              
      .ConfigureServices((services) => {

        services.AddHttpClient<MirrorListRetriever>();

        services
          .AddScoped<IFileSystem, FileSystem>()
          .AddScoped<DbBuilder>()
          .AddScoped<MirrorListRetriever>()
          .AddScoped<ResponseProcessor>();

        //services.AddScoped<SampleApp>();
      });
  
    return builder;
  }        
  
}
