using MathNet.Numerics.LinearAlgebra;
using MatrixCalculators.DeterminantCalculators;
using NUnit.Framework;
using System;

namespace UnitTests.MatrixCalculators.DeterminantCalculators
{
    [TestFixture]
    public class DcLaplaceExpansionTest
    {
        [Test]
        public void GetDeterminant()
        {
            int precision = 5;
            double delta = Math.Pow(0.1, precision);

            var a = Matrix<double>.Build.DenseOfRowArrays(new double[][]
            {
                new double[] { 1, 2, 3 },
                new double[] { 4, 5, 6 },
                new double[] { 7, 8, 9 }
            });

            var calculator = new DcLaplaceExpansion();
            var actual = calculator.GetDeterminant(a, precision);

            Assert.AreEqual(0, actual.Determinant, delta);
        }
    }
}
