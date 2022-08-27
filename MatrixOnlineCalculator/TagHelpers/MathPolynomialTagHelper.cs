using MatrixOnlineCalculator.HtmlHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Collections.Generic;

namespace MatrixOnlineCalculator.TagHelpers
{
    public class MathPolynomialTagHelper : TagHelper
    {
        public IEnumerable<double> Coefficients { get; set; }
        public string VariableName { get; set; }
        public int Precision { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var content = 
                MathHtmlHelper.Polynomial(Coefficients, VariableName, Precision);

            output.SuppressOutput();
            output.Content.SetHtmlContent(content);
        }
    }
}
