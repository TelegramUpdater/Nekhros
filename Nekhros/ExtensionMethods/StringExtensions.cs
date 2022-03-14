using System.Text.Encodings.Web;

namespace Nekhros;

internal static class StringExtensions
{
    /// <summary>
    /// Encodes an string using default html encoder.
    /// </summary>
    /// <param name="st">The string to encode.</param>
    /// <returns></returns>
    public static string ToHtmlEncoded(this string st)
        => HtmlEncoder.Default.Encode(st);

    /// <summary>
    /// Push an string inside an html tag.
    /// </summary>
    /// <param name="st">String to push.</param>
    /// <param name="tagName">Tag name.</param>
    /// <param name="attrs">Tag attributes with values.</param>
    /// <returns></returns>
    public static string CreateHtmlTag(
        this string st, string tagName, params (string, string)[] attrs)
    {
        string parsedAttrs;
        if (attrs.Any())
        {
            parsedAttrs = ' ' + string.Join(
                ' ', attrs.Select(x => $"{x.Item1}='{x.Item2}'"));
        }
        else
        {
            parsedAttrs = string.Empty;
        }

        return $"<{tagName}{parsedAttrs}>{st}</{tagName}>";
    }

    /// <summary>
    /// Push an encoded string inside an html tag.
    /// </summary>
    /// <param name="st">String to push.</param>
    /// <param name="tagName">Tag name.</param>
    /// <param name="attrs">Tag attributes with values.</param>
    /// <returns></returns>
    public static string CreateEncodedHtmlTag(
        this string str, string tagName, params (string, string)[] attrs)
        => str.ToHtmlEncoded().CreateHtmlTag(tagName, attrs);

    /// <summary>
    /// Push an string into a "code" tag.
    /// </summary>
    /// <param name="str">The string.</param>
    /// <returns></returns>
    public static string ToHtmlCode(this string str)
        => str.CreateHtmlTag("code");

    /// <summary>
    /// Push an string into a "i" tag.
    /// </summary>
    /// <param name="str">The string.</param>
    /// <returns></returns>
    public static string ToHtmlItalic(this string str)
        => str.CreateHtmlTag("i");

    /// <summary>
    /// Push an string into a "b" tag.
    /// </summary>
    /// <param name="str">The string.</param>
    /// <returns></returns>
    public static string ToHtmlBold(this string str)
        => str.CreateHtmlTag("b");

    /// <summary>
    /// Push an string with a link into an "a" tag.
    /// </summary>
    /// <param name="str">The string.</param>
    /// <param name="link">The link.</param>
    /// <returns></returns>
    public static string ToHtmlHyperLink(this string str, string link)
        => str.CreateHtmlTag("a", ("href", link));
}
