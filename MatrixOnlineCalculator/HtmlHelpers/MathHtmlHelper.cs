using MatrixOnlineCalculator.Models;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;

namespace MatrixOnlineCalculator.HtmlHelpers
{
    public static class MathHtmlHelper
    {
        public static HtmlString Number(
            double value, 
            bool? useBrackets = null, 
            int? precision = null)
        {
            double epsilon = MathUtils.Epsilon;

            if (precision != null)
            {
                value = Math.Round(value, (int)precision);
                epsilon = Math.Pow(0.1, (int)precision);
            }

            // Avoid negative zero
            if (MathUtils.AreEqual(value, 0, epsilon))
            {
                value = 0;
            }

            var valueTag = new TagBuilder("mn");
            valueTag.InnerHtml.Append(value.ToString());

            if ((useBrackets == true) && (value < 0))
            {
                var openingBracketTag = new TagBuilder("mo");
                var closingBracketTag = new TagBuilder("mo");
                var mrowTag = new TagBuilder("mrow");

                openingBracketTag.MergeAttribute("stretchy", "false");
                openingBracketTag.InnerHtml.Append("(");

                closingBracketTag.MergeAttribute("stretchy", "false");
                closingBracketTag.InnerHtml.Append(")");

                mrowTag.InnerHtml.AppendHtml(openingBracketTag);
                mrowTag.InnerHtml.AppendHtml(valueTag);
                mrowTag.InnerHtml.AppendHtml(closingBracketTag);

                using (var writer = new StringWriter())
                {
                    mrowTag.WriteTo(writer, HtmlEncoder.Default);
                    return new HtmlString(writer.ToString());
                }
            }
            else
            {
                using (var writer = new StringWriter())
                {
                    valueTag.WriteTo(writer, HtmlEncoder.Default);
                    return new HtmlString(writer.ToString());
                }
            }
        }

        public static HtmlString Polynom(
            IEnumerable<double> coefficients,
            int? precision)
        {
            double epsilon = (precision != null) ? 
                Math.Pow(0.1, (int)precision) :
                MathUtils.Epsilon;

            var terms = coefficients
                .Select((c, i) => new { Coefficient = c, Index = i })
                .Where(x => !MathUtils.AreEqual(x.Coefficient, 0, epsilon));

            if (terms.Count() == 0)
            {
                return new HtmlString("<mn>0</mn>");
            }

            var result = new HtmlContentBuilder();
            var firstTerm = terms.First();

            if (firstTerm.Coefficient < 0)
            {
                result.AppendHtml("<mo>-</mo>");
            }

            result.AppendHtml(
                PolynomTerm(Math.Abs(firstTerm.Coefficient), firstTerm.Index, precision));

            foreach (var term in terms.Skip(1))
            {
                var operation = term.Coefficient > 0 ? "+" : "-";
                result.AppendHtml($"<mo>{operation}</mo>");
                result.AppendHtml(
                    PolynomTerm(Math.Abs(term.Coefficient), term.Index, precision));
            }

            using (var writer = new StringWriter())
            {
                result.WriteTo(writer, HtmlEncoder.Default);
                return new HtmlString(writer.ToString());
            }
        }

        private static IHtmlContent PolynomTerm(
            double coefficient, 
            int index, 
            int? precision)
        {
            double epsilon = (precision != null) ?
                Math.Pow(0.1, (int)precision) :
                MathUtils.Epsilon;

            var result = new HtmlContentBuilder();

            if (index == 0)
            {
                result.AppendHtml(
                    Number(coefficient, false, precision));
            }
            else
            {
                if (!MathUtils.AreEqual(coefficient, 1, epsilon))
                {
                    result.AppendHtml(
                        Number(coefficient, true, precision));
                }

                result.AppendHtml($"<msub><mi>c</mi><mn>{index}</mn></msub>");
            }

            return result;
        }
    }
}
