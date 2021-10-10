using MathNet.Numerics.LinearAlgebra;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System;
using System.Text;

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

            for(int i = 0; i < Data.RowCount; i++)
            {
                var row = new StringBuilder();

                for(int j = 0; j < Data.ColumnCount; j++)
                {
                    if(Precision != null)
                    {
                        row.Append($"<mtd><mn>{Math.Round(Data[i, j], (int)Precision)}</mn></mtd>");
                    }
                    else
                    {
                        row.Append($"<mtd><mn>{Data[i, j]}</mn></mtd>");
                    }
                }

                output.Content.AppendHtml($"<mtr>{row}</mtr>");
            }
        }
    }
}
