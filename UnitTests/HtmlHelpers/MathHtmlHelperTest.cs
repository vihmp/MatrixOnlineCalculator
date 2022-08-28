using System.Collections.Generic;
using NUnit.Framework;
using System.Globalization;
using UnitTests.TestUtils;
using MatrixOnlineCalculator.HtmlHelpers;

namespace UnitTests.HtmlHelpers
{
    [TestFixture]
    public class MathHtmlHelperTest
    {
        [TestCase(1.23456789, false, null, ExpectedResult = "<mn>1,23456789</mn>")]
        [TestCase(1.23456789, false, 3, ExpectedResult = "<mn>1,235</mn>")]
        [TestCase(1.23456789, false, 2, ExpectedResult = "<mn>1,23</mn>")]
        [TestCase(1.23456789, false, 0, ExpectedResult = "<mn>1</mn>")]
        [TestCase(-1.23456789, false, null, ExpectedResult = "<mn>-1,23456789</mn>")]
        [TestCase(-1.23456789, true, null, ExpectedResult = "<mrow><mo stretchy=\"false\">(</mo>" +
            "<mn>-1,23456789</mn><mo stretchy=\"false\">)</mo></mrow>")]
        [TestCase(-0.000001, true, 2, ExpectedResult = "<mn>0</mn>")]
        public string MathHtmlHelperNumber(double value, bool useBrackets, int? precision)
        {
            CultureInfo.CurrentCulture = new CultureInfo("ru");

            return MathHtmlHelper.Number(value, useBrackets, precision)
                .AsString();
        }

        [TestCase(new double[] { 1, 2, 3 }, null, 3, ExpectedResult = "<mn>1</mn>" +
            "<mo>+</mo><mn>2</mn><msub><mi>c</mi><mn>1</mn></msub>" +
            "<mo>+</mo><mn>3</mn><msub><mi>c</mi><mn>2</mn></msub>")]
        [TestCase(new double[] { 1, 1, 1 }, null, 3, ExpectedResult = "<mn>1</mn>" +
            "<mo>+</mo><msub><mi>c</mi><mn>1</mn></msub>" +
            "<mo>+</mo><msub><mi>c</mi><mn>2</mn></msub>")]
        [TestCase(new double[] { 1.23456, 2.34567 }, null, 3, ExpectedResult = "<mn>1,235</mn>" +
            "<mo>+</mo><mn>2,346</mn><msub><mi>c</mi><mn>1</mn></msub>")]
        [TestCase(new double[] { -1, -2, -3 }, null, 3, ExpectedResult = "<mo>-</mo><mn>1</mn>" +
            "<mo>-</mo><mn>2</mn><msub><mi>c</mi><mn>1</mn></msub>" +
            "<mo>-</mo><mn>3</mn><msub><mi>c</mi><mn>2</mn></msub>")]
        [TestCase(new double[] { 0, 0, 3, 4 }, null, 3, 
            ExpectedResult = "<mn>3</mn><msub><mi>c</mi><mn>2</mn></msub>" +
                "<mo>+</mo><mn>4</mn><msub><mi>c</mi><mn>3</mn></msub>")]
        [TestCase(new double[] { 1, 2, 0, 0 }, null, 3, ExpectedResult = "<mn>1</mn>" +
            "<mo>+</mo><mn>2</mn><msub><mi>c</mi><mn>1</mn></msub>")]
        [TestCase(new double[] { 0, 0, 0 }, null, 3, ExpectedResult = "<mn>0</mn>")]
        [TestCase(new double[] {}, null, 3, ExpectedResult = "<mn>0</mn>")]
        [TestCase(new double[] { 3 }, null, 3, ExpectedResult = "<mn>3</mn>")]
        [TestCase(new double[] { 1, 2, 3 }, "a", 3, ExpectedResult = "<mn>1</mn>" +
            "<mo>+</mo><mn>2</mn><msub><mi>a</mi><mn>1</mn></msub>" +
            "<mo>+</mo><mn>3</mn><msub><mi>a</mi><mn>2</mn></msub>")]
        public string MathHtmlHelperPolynomial(
            IEnumerable<double> coefficients, 
            string variableName, 
            int precision)
        {
            CultureInfo.CurrentCulture = new CultureInfo("ru");

            return MathHtmlHelper.Polynomial(coefficients, variableName, precision)
                .AsString();
        }
    }
}
