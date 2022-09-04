using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using MatrixOnlineCalculator.Models;

namespace UnitTests.Models
{
    [TestFixture]
    public class MathUtilsTest
    {
        [TestCase(0, 0, 5, ExpectedResult = true)]
        [TestCase(0, 1, 5, ExpectedResult = false)]
        [TestCase(0, 0.00005, 5, ExpectedResult = false)]
        [TestCase(0, 0.000005, 5, ExpectedResult = true)]
        public bool AreEqual(double a, double b, int precision)
        {
            return MathUtils.AreEqual(a, b, precision);
        }
    }
}
