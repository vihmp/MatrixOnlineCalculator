using MatrixOnlineCalculator.Models;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MatrixOnlineCalculator.HtmlHelpers
{
    public static class MathHtmlHelper
    {
        public static IHtmlContent Number(
            double value, 
            bool useBrackets, 
            int? precision = null)
        {
            if (precision != null)
            {
                value = Math.Round(value, (int)precision);

                // Avoid negative zero
                if (MathUtils.AreEqual(value, 0, (int)precision))
                {
                    value = 0;
                }
            }

            var valueTag = new TagBuilder("mn");
            valueTag.InnerHtml.Append(value.ToString());

            if (useBrackets && (value < 0))
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

                return mrowTag;
            }
            else
            {
                return valueTag;
            }
        }

        public static IHtmlContent Polynomial(
            IEnumerable<double> coefficients,
            string variableName,
            int precision)
        {
            var terms = coefficients
                .Select((c, i) => new { Coefficient = c, Index = i })
                .Where(x => !MathUtils.AreEqual(x.Coefficient, 0, precision));

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
                PolynomialTerm(
                    Math.Abs(firstTerm.Coefficient), 
                    firstTerm.Index, 
                    variableName,
                    precision));

            foreach (var term in terms.Skip(1))
            {
                var operation = term.Coefficient > 0 ? "+" : "-";
                result.AppendHtml($"<mo>{operation}</mo>");
                result.AppendHtml(
                    PolynomialTerm(
                        Math.Abs(term.Coefficient), 
                        term.Index, 
                        variableName,
                        precision));
            }

            return result;
        }

        private static IHtmlContent PolynomialTerm(
            double coefficient, 
            int index, 
            string variableName,
            int precision)
        {
            if (string.IsNullOrWhiteSpace(variableName))
            {
                variableName = "c";
            }

            var result = new HtmlContentBuilder();

            if (index == 0)
            {
                result.AppendHtml(
                    Number(coefficient, false, precision));
            }
            else
            {
                if (!MathUtils.AreEqual(coefficient, 1, precision))
                {
                    result.AppendHtml(
                        Number(coefficient, true, precision));
                }

                result.AppendHtml(
                    $"<msub><mi>{variableName}</mi><mn>{index}</mn></msub>");
            }

            return result;
        }
    }
}
