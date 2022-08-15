using MathNet.Numerics.LinearAlgebra;
using MatrixOnlineCalculator.Models;
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

            for (int i = 0; i < Data.RowCount; i++)
            {
                var row = new StringBuilder();

                for (int j = 0; j < Data.ColumnCount; j++)
                {
                    double value = Data[i, j];

                    if (Precision != null)
                    {
                        value = Math.Round(Data[i, j], (int)Precision);
                    }

                    // Avoid negative zero
                    if (MathUtils.AreEqual(value, 0, MathUtils.Epsilon))
                    {
                        value = 0;
                    }

                    row.Append($"<mtd><mn>{value}</mn></mtd>");
                }

                output.Content.AppendHtml($"<mtr>{row}</mtr>");
            }
        }
    }
}
