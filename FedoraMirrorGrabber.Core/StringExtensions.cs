using System.Diagnostics.CodeAnalysis;

namespace FedoraMirrorGrabber.Core;

internal static class StringExtensions
{
  #region APIs

  [SuppressMessage("NDepend", "ND1807:AvoidPublicMethodsNotPubliclyVisible", Justification = "Public methods in this internal class are not implementation details.")]
  public static string TrimAt(this string value, string pattern)
  {
    if (value is null)
    {
      throw new ArgumentNullException(nameof(value));
    }

    var pos = value.IndexOf(pattern, StringComparison.OrdinalIgnoreCase);

    if (pos < 0)
    {
      return value;
    }

    return value[..pos];
  }

  [SuppressMessage("NDepend", "ND1807:AvoidPublicMethodsNotPubliclyVisible", Justification = "Public methods in this internal class are not implementation details.")]
  public static string EscapeForRegex(this string value)
  {
    if (value is null)
    {
      throw new ArgumentNullException(nameof(value));
    }

    return value
      .Replace("/", @"\/") // escape "/"
      .Replace(".", @"\."); // escape "." (e.g. in domain)
  }

  #endregion
}