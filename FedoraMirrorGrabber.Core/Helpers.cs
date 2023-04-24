namespace FedoraMirrorGrabber.Core;

internal static class Helpers
{
  #region APIs

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