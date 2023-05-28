using CommandLine;
using FedoraMirrorGrabber.App;
using Microsoft.Extensions.Logging;

internal partial class Program
{
  private static ILoggerFactory _loggerFactory;
  private static ILogger<Program> _logger = null!;

  public static async Task Main(string[] args)
  {
    using (_loggerFactory = LoggerFactory.Create(builder => builder.AddConsole()))
    {
      _logger = _loggerFactory.CreateLogger<Program>();
      
      using (var parser = new Parser(config => {
               config.CaseInsensitiveEnumValues = true;
               // temporary, or I do not get help since not using Parser.Default
               config.HelpWriter = Console.Error;
             }))
      {
        await parser
          .ParseArguments<Options>(args)
          .WithParsedAsync(Run);
      }
    }
  }
}