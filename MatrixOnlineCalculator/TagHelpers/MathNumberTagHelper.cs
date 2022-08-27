using MatrixOnlineCalculator.HtmlHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MatrixOnlineCalculator.TagHelpers
{
    public class MathNumberTagHelper : TagHelper
    {
        public double Value { get; set; }
        public bool? UseBrackets { get; set; }
        public int? Precision { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            var content = MathHtmlHelper.Number(
                Value, 
                UseBrackets ?? false, 
                Precision);

            output.SuppressOutput();
            output.Content.SetHtmlContent(content);
        }
    }
}
