using MatrixOnlineCalculator.HtmlHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;

namespace MatrixOnlineCalculator.TagHelpers
{
    public class MathPolynomTagHelper : TagHelper
    {
        public IEnumerable<double> Coefficients { get; set; }
        public int? Precision { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var content =
                MathHtmlHelper.Polynom(Coefficients, Precision);

            output.SuppressOutput();
            output.Content.SetHtmlContent(content);
        }
    }
}
