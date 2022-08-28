using Microsoft.AspNetCore.Html;
using System.IO;
using System.Text.Encodings.Web;

namespace UnitTests.TestUtils
{
    public static class IHtmlContentExtensions
    {
        public static string AsString(this IHtmlContent content)
        {
            using (var writer = new StringWriter())
            {
                content.WriteTo(writer, HtmlEncoder.Default);

                return writer.ToString();
            }
        }
    }
}
