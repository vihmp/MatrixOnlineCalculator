using MathNet.Numerics.LinearAlgebra;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;

namespace MatrixOnlineCalculator.TagHelpers
{
    public class MathEquationSystemTagHelper : TagHelper
    {
        public Matrix<double> A { get; set; }
        public Matrix<double> B { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "mtable";
            output.Attributes.Add("columnalign", "left");
            output.TagMode = TagMode.StartTagAndEndTag;

            for (int i = 0; i < A.RowCount; i++)
            {
                var row = new StringBuilder();
                row.Append("<mtd>");

                for (int j = 0; j < A.ColumnCount; j++)
                {
                    string op = j < A.ColumnCount - 1 ? "+" : "=";

                    if(A[i, j] < 0)
                    {
                        row.Append($"<mo>(</mo><mn>{A[i, j]}</mn><mo>)</mo>");
                    }
                    else
                    {
                        row.Append($"<mn>{A[i, j]}</mn>");
                    }

                    row.Append($"<mo>&sdot;</mo><msub><mi>x</mi><mn>{j + 1}</mn></msub>");
                    row.Append($"<mo>{op}</mo>");
                }

                row.Append($"<mn>{B[i, 0]}</mn>");
                row.Append("</mtd>");
                output.Content.AppendHtml($"<mtr>{row}</mtr>");
            }
        }
    }
}
