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
               // temporary, or I do not get help since not using Parser.Default
               config.HelpWriter = Console.Error;
             }))
    {
      // var result = parser.ParseArguments<Options>(args);
      //
      // await result.WithParsedAsync(Run);
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
          .AddScoped<ResponseProcessor>();

        services.AddScoped<Executor>();
      });
  
    return builder;
  }        
}
