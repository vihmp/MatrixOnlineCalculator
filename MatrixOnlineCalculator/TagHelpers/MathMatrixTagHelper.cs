using MathNet.Numerics.LinearAlgebra;
using MatrixOnlineCalculator.HtmlHelpers;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace MatrixOnlineCalculator.TagHelpers
{
    public class MathMatrixTagHelper : TagHelper
    {
        public Matrix<double> Data { get; set; }
        public int? Precision { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "mtable";
            output.TagMode = TagMode.StartTagAndEndTag;

            for (int i = 0; i < Data.RowCount; i++)
            {
                var rowTag = new TagBuilder("mtr");

                for (int j = 0; j < Data.ColumnCount; j++)
                {
                    var cellTag = new TagBuilder("mtd");

                    cellTag.InnerHtml.AppendHtml(
                        MathHtmlHelper.Number(Data[i, j], false, Precision));
                    rowTag.InnerHtml.AppendHtml(cellTag);
                }

                output.Content.AppendHtml(rowTag);
            }
        }
    }
}
