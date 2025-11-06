using System.Diagnostics.CodeAnalysis;
using System.Reflection;

namespace FedoraMirrorGrabber.Core.Tests.Internals;

internal static class Helpers
{
  private static readonly Assembly Assembly = Assembly.GetExecutingAssembly();
  
  [SuppressMessage("NDepend", "ND1807:AvoidPublicMethodsNotPubliclyVisible", Justification = "Public methods in this internal class are not implementation details.")]
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
