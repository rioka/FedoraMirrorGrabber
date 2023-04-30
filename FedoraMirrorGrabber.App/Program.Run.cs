using FedoraMirrorGrabber.App;
using FedoraMirrorGrabber.Core;
using System.IO.Abstractions;

internal partial class Program
{
  public static async Task Run(Options options)
  {
      var client = new HttpClient() ;
      var retriever = new MirrorListRetriever(client, new ResponseProcessor()) {
        BaseAddress = new Uri(options.Url)
      };
      var mirrors = await retriever.GetMirrors(options.Architecture, options.ReleaseVersion);

      Func<Mirror, bool>? filter = default;
      if (options.Protocols is not null && options.Protocols.Any())
      {
        filter = m => options.Protocols.Contains(m.Type);
      }

      var fs = new FileSystem();
      var builder = new DbBuilder(fs);
      await builder.Save(options.SaveTo, options.Architecture, options.ReleaseVersion, mirrors, filter);  
  } 
}