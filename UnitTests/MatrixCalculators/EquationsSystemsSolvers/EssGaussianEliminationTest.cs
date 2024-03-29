﻿using MathNet.Numerics.LinearAlgebra;
using MatrixCalculators.EquationsSystemsSolvers;
using NUnit.Framework;
using UnitTests.TestUtils;

namespace UnitTests.MatrixCalculators.EquationsSystemsSolvers
{
    [TestFixture]
    public class EssGaussianEliminationTest
    {
        [Test]
        public void SolveOneSolution()
        {
            int precision = 5;

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

            var solver = new EssGaussianElimination();
            var actual = solver.Solve(a, b, precision);

            MatrixAssert.AreEqual(expected, actual.X, precision);
            Assert.AreEqual(SolutionsNumber.OneSolution, actual.SolutionsNumber);
        }

        [Test]
        public void SolveOneSolutionMoreRows()
        {
            int precision = 5;

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

            var solver = new EssGaussianElimination();
            var actual = solver.Solve(a, b, precision);

            MatrixAssert.AreEqual(expected, actual.X, precision);
            Assert.AreEqual(SolutionsNumber.OneSolution, actual.SolutionsNumber);
        }

        [Test]
        public void SolveNoSolution()
        {
            int precision = 5;

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

            var expected = Matrix<double>.Build.Dense(0, 0);

            var solver = new EssGaussianElimination();
            var actual = solver.Solve(a, b, precision);

            MatrixAssert.AreEqual(expected, actual.X, precision);
            Assert.AreEqual(SolutionsNumber.NoSolution, actual.SolutionsNumber);
        }

        [Test]
        public void SolveManySolutions()
        {
            int precision = 5;

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

            var solver = new EssGaussianElimination();
            var actual = solver.Solve(a, b, precision);

            MatrixAssert.AreEqual(expected, actual.X, precision);
            Assert.AreEqual(SolutionsNumber.InfinitelyManySolutions, actual.SolutionsNumber);
        }

        [Test]
        public void SolveManySolutionsMoreColumns()
        {
            int precision = 5;

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

            var solver = new EssGaussianElimination();
            var actual = solver.Solve(a, b, precision);

            MatrixAssert.AreEqual(expected, actual.X, precision);
            Assert.AreEqual(SolutionsNumber.InfinitelyManySolutions, actual.SolutionsNumber);
        }

        [Test]
        public void SolveManySolutionsMoreRows()
        {
            int precision = 5;

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

            var solver = new EssGaussianElimination();
            var actual = solver.Solve(a, b, precision);

            MatrixAssert.AreEqual(expected, actual.X, precision);
            Assert.AreEqual(SolutionsNumber.InfinitelyManySolutions, actual.SolutionsNumber);
        }
    }
}
