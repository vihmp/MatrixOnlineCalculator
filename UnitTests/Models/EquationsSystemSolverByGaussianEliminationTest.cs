using MathNet.Numerics.LinearAlgebra;
using NUnit.Framework;
using MatrixOnlineCalculator.Models.EquationsSystemsSolvers;

namespace UnitTests.Models
{
    [TestFixture]
    class EquationsSystemSolverByGaussianEliminationTest
    {
        [Test]
        public void EquationsSystemSolverByGaussianEliminationOneSolution()
        {
            var a = Matrix<double>.Build.DenseOfRowArrays(new double[][]
            {
                new double[] { 2, 2, -1, 1 },
                new double[] { 4, 3, -1, 2 },
                new double[] { 8, 5, -3, 4 },
                new double[] { 3, 3, -2, 2 }
            });

            var b = Matrix<double>.Build.DenseOfRowArrays(new double[][]
            {
                new double[] { 4 },
                new double[] { 6 },
                new double[] { 12 },
                new double[] { 6 }
            });

            var expected = Matrix<double>.Build.DenseOfRowArrays(new double[][]
            {
                new double[] { 1 },
                new double[] { 1 },
                new double[] { -1 },
                new double[] { -1 }
            });

            var actual = new EquationsSystemSolverByGaussianElimination(a, b);

            Assert.AreEqual(1, actual.X.ColumnCount);

            for (int i = 0; i < expected.RowCount; i++)
            {
                Assert.AreEqual(expected[i, 0], actual.X[i, 0], 0.0001);
            }
        }

        [Test]
        public void EquationsSystemSolverByGaussianEliminationOneSolutionMoreRows()
        {
            var a = Matrix<double>.Build.DenseOfRowArrays(new double[][]
            {
                new double[] { 1, 0, 0 },
                new double[] { 0, 1, 0 },
                new double[] { 0, 0, 1 },
                new double[] { 0, 0, 0 }
            });

            var b = Matrix<double>.Build.DenseOfRowArrays(new double[][]
            {
                new double[] { 1 },
                new double[] { 1 },
                new double[] { 1 },
                new double[] { 0 }
            });

            var expected = Matrix<double>.Build.DenseOfRowArrays(new double[][]
            {
                new double[] { 1 },
                new double[] { 1 },
                new double[] { 1 }
            });

            var actual = new EquationsSystemSolverByGaussianElimination(a, b);

            Assert.AreEqual(1, actual.X.ColumnCount);

            for (int i = 0; i < expected.RowCount; i++)
            {
                Assert.AreEqual(expected[i, 0], actual.X[i, 0], 0.0001);
            }
        }

        [Test]
        public void EquationsSystemSolverByGaussianEliminationNoSolution()
        {
            var a = Matrix<double>.Build.DenseOfRowArrays(new double[][]
            {
                new double[] { 2, -1, 1 },
                new double[] { 1, 2, 3 },
                new double[] { 1, -3, -2 }
            });

            var b = Matrix<double>.Build.DenseOfRowArrays(new double[][]
            {
                new double[] { -2 },
                new double[] { -1 },
                new double[] { 3 }
            });

            var actual = new EquationsSystemSolverByGaussianElimination(a, b);

            Assert.AreEqual(0, actual.X.RowCount);
        }

        [Test]
        public void EquationsSystemSolverByGaussianEliminationManySolutions()
        {
            var a = Matrix<double>.Build.DenseOfRowArrays(new double[][]
            {
                new double[] { 2, -1, 1, 2, 3 },
                new double[] { 6, -3, 2, 4, 5 },
                new double[] { 6, -3, 4, 8, 13 },
                new double[] { 4, -2, 1, 1, 2 }
            });

            var b = Matrix<double>.Build.DenseOfRowArrays(new double[][]
            {
                new double[] { 2 },
                new double[] { 3 },
                new double[] { 9 },
                new double[] { 1 }
            });

            var expected = Matrix<double>.Build.DenseOfRowArrays(new double[][]
            {
                new double[] { -0.5, 0.5, 0.5 },
                new double[] { 0, 1, 0 },
                new double[] { 3, 0, -4 },
                new double[] { 0, 0, 0 },
                new double[] { 0, 0, 1 }
            });

            var actual = new EquationsSystemSolverByGaussianElimination(a, b);

            Assert.AreEqual(3, actual.X.ColumnCount);

            for (int i = 0; i < expected.RowCount; i++)
            {
                for(int j = 0; j < expected.ColumnCount; j++)
                {
                    Assert.AreEqual(expected[i, j], actual.X[i, j], 0.0001);
                }
            }
        }

        [Test]
        public void EquationsSystemSolverByGaussianEliminationManySolutionsMoreColumns()
        {
            var a = Matrix<double>.Build.DenseOfRowArrays(new double[][]
            {
                new double[] { 1, 1, 0, 0, 0 },
                new double[] { 0, 1, 1, 0, 0 },
                new double[] { 0, 0, 1, 1, 0 }
            });

            var b = Matrix<double>.Build.DenseOfRowArrays(new double[][]
            {
                new double[] { 1 },
                new double[] { 1 },
                new double[] { 1 }
            });

            var expected = Matrix<double>.Build.DenseOfRowArrays(new double[][]
            {
                new double[] { 1, -1, 0 },
                new double[] { 0, 1, 0 },
                new double[] { 1, -1, 0 },
                new double[] { 0, 1, 0 },
                new double[] { 0, 0, 1 }
            });

            var actual = new EquationsSystemSolverByGaussianElimination(a, b);

            Assert.AreEqual(3, actual.X.ColumnCount);

            for (int i = 0; i < expected.RowCount; i++)
            {
                for (int j = 0; j < expected.ColumnCount; j++)
                {
                    Assert.AreEqual(expected[i, j], actual.X[i, j], 0.0001);
                }
            }
        }

        [Test]
        public void EquationsSystemSolverByGaussianEliminationManySolutionsMoreRows()
        {
            var a = Matrix<double>.Build.DenseOfRowArrays(new double[][]
            {
                new double[] { 1, 1, 0, 0, 0 },
                new double[] { 0, 1, 1, 0, 0 },
                new double[] { 0, 0, 1, 1, 0 },
                new double[] { 0, 0, 0, 0, 0 },
                new double[] { 0, 0, 0, 0, 0 },
                new double[] { 0, 0, 0, 0, 0 }
            });

            var b = Matrix<double>.Build.DenseOfRowArrays(new double[][]
            {
                new double[] { 1 },
                new double[] { 1 },
                new double[] { 1 },
                new double[] { 0 },
                new double[] { 0 },
                new double[] { 0 }
            });

            var expected = Matrix<double>.Build.DenseOfRowArrays(new double[][]
            {
                new double[] { 1, -1, 0 },
                new double[] { 0, 1, 0 },
                new double[] { 1, -1, 0 },
                new double[] { 0, 1, 0 },
                new double[] { 0, 0, 1 }
            });

            var actual = new EquationsSystemSolverByGaussianElimination(a, b);

            Assert.AreEqual(3, actual.X.ColumnCount);

            for (int i = 0; i < expected.RowCount; i++)
            {
                for (int j = 0; j < expected.ColumnCount; j++)
                {
                    Assert.AreEqual(expected[i, j], actual.X[i, j], 0.0001);
                }
            }
        }
    }
}
