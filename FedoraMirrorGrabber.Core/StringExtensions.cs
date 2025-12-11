namespace FedoraMirrorGrabber.Core;

internal static class StringExtensions
{
  #region APIs

  /// <summary>
  /// Trim a string at the first occurrence of <paramref name="pattern"/>
  /// </summary>
  /// <param name="value">The string to trim</param>
  /// <param name="pattern">The pattern at which  <paramref name="value"/> is trimmed</param>
  /// <param name="offset">
  /// Optional offset in <paramref name="pattern"/> to trim at,
  /// e.g., to keep the first <code>n</code> characters</param>
  /// <returns></returns>
  /// <exception cref="ArgumentNullException">Thrown when <paramref name="value"/> is null.</exception>
  public static string TrimAt(this string value, string pattern, int offset = 0)
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

    return value[..(pos + offset)];
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