using CommandLine;
using FedoraMirrorGrabber.App;

internal partial class Program
{
  public static async Task Main(string[] args)
  {
    await Parser
      .Default
      .ParseArguments<Options>(args)
      .WithParsedAsync(Run);
  }
}
