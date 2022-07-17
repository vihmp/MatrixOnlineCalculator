using MathNet.Numerics.LinearAlgebra;
using MatrixOnlineCalculator.Models.DeterminantCalculation;
using NUnit.Framework;

namespace UnitTests.Models
{
    [TestFixture]
    public class DeterminantByGaussianEliminationTest
    {
        [Test]
        public void DeterminantByGaussianEliminationNoRowSwitching()
        {
            var a = Matrix<double>.Build.DenseOfRowArrays(new double[][]
            {
                new double[] { 4, 4, 4, 4 },
                new double[] { 1, 4, 4, 4 },
                new double[] { 1, 2, 4, 4 },
                new double[] { 1, 2, 3, 4 }
            });

            var actual = new DeterminantByGaussianElimination(a);

            Assert.AreEqual(24, actual.Determinant, 0.0001);
        }

        [Test]
        public void DeterminantByGaussianEliminationRowSwitchingOddNumber()
        {
            var a = Matrix<double>.Build.DenseOfRowArrays(new double[][]
            {
                new double[] { 1, 4, 4, 4 },
                new double[] { 4, 4, 4, 4 },
                new double[] { 1, 2, 4, 4 },
                new double[] { 1, 2, 3, 4 }
            });

            var actual = new DeterminantByGaussianElimination(a);

            Assert.AreEqual(-24, actual.Determinant, 0.0001);
        }

        [Test]
        public void DeterminantByGaussianEliminationRowSwitchingEvenNumber()
        {
            var a = Matrix<double>.Build.DenseOfRowArrays(new double[][]
            {
                new double[] { 1, 2, 4, 4 },
                new double[] { 4, 4, 4, 4 },
                new double[] { 1, 4, 4, 4 },
                new double[] { 1, 2, 3, 4 }
            });

            var actual = new DeterminantByGaussianElimination(a);

            Assert.AreEqual(24, actual.Determinant, 0.0001);
        }
    }
}
