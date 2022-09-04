using MathNet.Numerics.LinearAlgebra;
using MatrixOnlineCalculator.Models.GaussianEliminationCalculation;
using NUnit.Framework;
using UnitTests.TestUtils;

namespace UnitTests.Models.GaussianEliminationCalculation
{
    [TestFixture]
    public class GaussianEliminationTest
    {
        [Test]
        public void GaussianEliminationSquareMatrix()
        {
            int precision = 5;

            var initial = Matrix<double>.Build.DenseOfRowArrays(new double[][]
            { 
                new double[] { 3, 2, 1 },
                new double[] { 5, 4, 6 },
                new double[] { 8, 7, 9 }
            });

            var expected = Matrix<double>.Build.DenseOfRowArrays(new double[][]
            {
                new double[] { 8, 7, 9 },
                new double[] { 0, -0.625, -2.375 },
                new double[] { 0, 0, 1.8 }
            });

            var actual = new GaussianElimination(initial, precision);

            MatrixAssert.AreEqual(expected, actual.Result, precision);
        }

        [Test]
        public void GaussianEliminationSingularMatrix()
        {
            int precision = 5;

            var initial = Matrix<double>.Build.DenseOfRowArrays(new double[][]
            {
                new double[] { 3, 2.625, 1, 2 },
                new double[] { 5, 4.375, 6, 4 },
                new double[] { 8, 7, 9, 1 },
                new double[] { 4, 3.5, 5, 3 }
            });

            var expected = Matrix<double>.Build.DenseOfRowArrays(new double[][]
            {
                new double[] { 8, 7, 9, 1 },
                new double[] { 0, 0, -2.375, 1.625 },
                new double[] { 0, 0, 0, 3.63158 },
                new double[] { 0, 0, 0, 0 }
            });

            var actual = new GaussianElimination(initial, precision);

            MatrixAssert.AreEqual(expected, actual.Result, precision);
        }

        [Test]
        public void GaussianEliminationColumnCountGreater()
        {
            int precision = 5;

            var initial = Matrix<double>.Build.DenseOfRowArrays(new double[][]
            {
                new double[] { 1, 4, 9, 11 },
                new double[] { 2, 5, 8, 11 },
                new double[] { 3, 6, 9, 12 }
            });

            var expected = Matrix<double>.Build.DenseOfRowArrays(new double[][]
            {
                new double[] { 3, 6, 9, 12 },
                new double[] { 0, 2, 6, 7 },
                new double[] { 0, 0, -1, -0.5 }
            });

            var actual = new GaussianElimination(initial, precision);

            MatrixAssert.AreEqual(expected, actual.Result, precision);
        }

        [Test]
        public void GaussianEliminationRowCountGreater()
        {
            int precision = 5;

            var initial = Matrix<double>.Build.DenseOfRowArrays(new double[][]
            {
                new double[] { 1, 5, 9 },
                new double[] { 2, 6, 11 },
                new double[] { 3, 7, 13 },
                new double[] { 4, 8, 12 }
            });

            var expected = Matrix<double>.Build.DenseOfRowArrays(new double[][]
            {
                new double[] { 4, 8, 12 },
                new double[] { 0, 3, 6 },
                new double[] { 0, 0, 2 },
                new double[] { 0, 0, 0 }
            });

            var actual = new GaussianElimination(initial, precision);

            MatrixAssert.AreEqual(expected, actual.Result, precision);
        }

        [Test]
        public void GaussianEliminationNoOperations()
        {
            int precision = 5;

            var initial = Matrix<double>.Build.DenseOfRowArrays(new double[][]
            {
                new double[] { 1, 0, 0 },
                new double[] { 0, 1, 0 },
                new double[] { 0, 0, 1 }
            });

            var expected = Matrix<double>.Build.DenseOfRowArrays(new double[][]
            {
                new double[] { 1, 0, 0 },
                new double[] { 0, 1, 0 },
                new double[] { 0, 0, 1 }
            });

            var actual = new GaussianElimination(initial, precision);

            MatrixAssert.AreEqual(expected, actual.Result, precision);
        }
    }
}
