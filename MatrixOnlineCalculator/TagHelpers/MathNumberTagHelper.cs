using MatrixOnlineCalculator.Models;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;

namespace MatrixOnlineCalculator.TagHelpers
{
    public class MathNumberTagHelper : TagHelper
    {
        public double Value { get; set; }

        public bool? UseBrackets { get; set; }

        public int? Precision { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "mn";
            output.TagMode = TagMode.StartTagAndEndTag;
            double value = Value;

            if(Precision != null)
            {
                value = Math.Round(value, (int)Precision);
            }

            // Avoid negative zero
            if(MathUtils.AreEqual(value, 0, MathUtils.Epsilon))
            {
                value = 0;
            }

            output.Content.SetContent(value.ToString());

            if ((UseBrackets == true) && (Value < 0))
            {
                output.PreElement.SetHtmlContent("<mrow><mo stretchy=\"false\">(</mo>");
                output.PostElement.SetHtmlContent("<mo stretchy=\"false\">)</mo></mrow>");
            }
        }
    }
}
