using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MatrixOnlineCalculator.TagHelpers
{
    public class MathNumberTagHelper : TagHelper
    {
        public double Value { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "mn";
            output.TagMode = TagMode.StartTagAndEndTag;
            output.Content.SetContent(Value.ToString());

            if (Value < 0)
            {
                output.PreElement.SetHtmlContent("<mo stretchy=\"false\">(</mo>");
                output.PostElement.SetHtmlContent("<mo stretchy=\"false\">)</mo>");
            }
        }
    }
}
