using MathNet.Numerics.LinearAlgebra;
using MatrixOnlineCalculator.Models;
using NUnit.Framework;

namespace UnitTests.Models
{
    [TestFixture]
    public class GaussianEliminationTest
    {
        [Test]
        public void GaussianEliminationSquareMatrix()
        {
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

            var actual = new GaussianElimination(initial);

            for(int i = 0; i < initial.RowCount; i++)
            {
                for (int j = 0; j < initial.ColumnCount; j++)
                {
                    Assert.AreEqual(expected[i, j], actual.Result[i, j], 0.0001);
                }
            }
        }

        [Test]
        public void GaussianEliminationSingularMatrix()
        {
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
                new double[] { 0, 0, 0, 3.6316 },
                new double[] { 0, 0, 0, 0 }
            });

            var actual = new GaussianElimination(initial);

            for (int i = 0; i < initial.RowCount; i++)
            {
                for (int j = 0; j < initial.ColumnCount; j++)
                {
                    Assert.AreEqual(expected[i, j], actual.Result[i, j], 0.0001);
                }
            }
        }

        [Test]
        public void GaussianEliminationColumnCountGreater()
        {
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

            var actual = new GaussianElimination(initial);

            for (int i = 0; i < initial.RowCount; i++)
            {
                for (int j = 0; j < initial.ColumnCount; j++)
                {
                    Assert.AreEqual(expected[i, j], actual.Result[i, j], 0.0001);
                }
            }
        }

        [Test]
        public void GaussianEliminationRowCountGreater()
        {
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

            var actual = new GaussianElimination(initial);

            for (int i = 0; i < initial.RowCount; i++)
            {
                for (int j = 0; j < initial.ColumnCount; j++)
                {
                    Assert.AreEqual(expected[i, j], actual.Result[i, j], 0.0001);
                }
            }
        }

        [Test]
        public void GaussianEliminationNoOperations()
        {
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

            var actual = new GaussianElimination(initial);

            for (int i = 0; i < initial.RowCount; i++)
            {
                for (int j = 0; j < initial.ColumnCount; j++)
                {
                    Assert.AreEqual(expected[i, j], actual.Result[i, j], 0.0001);
                }
            }
        }
    }
}
