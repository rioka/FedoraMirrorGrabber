using System.Reflection;

namespace FedoraMirrorGrabber.Core.Tests.Internals;

internal static class Helpers
{
  private static readonly Assembly Assembly = Assembly.GetExecutingAssembly();
  
  public static string GetResource(string name)
  {
    using (var stream = Assembly.GetManifestResourceStream(name))
    {
      using (var reader = new StreamReader(stream))
      {
        return reader.ReadToEnd();
      }
    }
  }
}