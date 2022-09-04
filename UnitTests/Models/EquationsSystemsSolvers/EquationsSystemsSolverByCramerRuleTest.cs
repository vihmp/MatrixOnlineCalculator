using MathNet.Numerics.LinearAlgebra;
using NUnit.Framework;
using MatrixOnlineCalculator.Models.EquationsSystemsSolvers;
using System.Linq;
using MatrixOnlineCalculator.Models;
using System;
using UnitTests.TestUtils;

namespace UnitTests.Models.EquationsSystemsSolvers
{
    [TestFixture]
    class EquationsSystemsSolverByCramerRuleTest
    {
        [Test]
        public void EquationsSystemsSolverByCramerRuleOneSolution()
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

            var actual = 
                new EquationsSystemsSolverByCramerRule(a, b, precision);

            MatrixAssert.AreEqual(expected, actual.X, precision);
            Assert.AreEqual(SolutionsNumber.OneSolution, actual.SolutionsNumber);
        }

        [Test]
        public void EquationsSystemsSolverByCramerRuleNoSolutions()
        {
            int precision = 5;
            double delta = Math.Pow(0.1, precision);

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

            var actual = 
                new EquationsSystemsSolverByCramerRule(a, b, precision);

            var expected = Matrix<double>.Build.Dense(0, 0);

            MatrixAssert.AreEqual(expected, actual.X, precision);
            Assert.AreEqual(SolutionsNumber.NoSolution, actual.SolutionsNumber);
            Assert.IsTrue(
                actual.Determinants.Any(
                    x => !MathUtils.AreEqual(x.Determinant, 0, precision)));
        }

        [Test]
        public void EquationsSystemsSolverByCramerRuleManySolutions()
        {
            int precision = 5;
            double delta = Math.Pow(0.1, precision);

            var a = Matrix<double>.Build.DenseOfRowArrays(new double[][]
            {
                new double[] { 0, 1, 1 },
                new double[] { 0, 0, 1 },
                new double[] { 0, 0, 0 }
            });

            var b = Matrix<double>.Build.DenseOfRowArrays(new double[][]
            {
                new double[] { 2 },
                new double[] { 1 },
                new double[] { 0 }
            });

            var actual = 
                new EquationsSystemsSolverByCramerRule(a, b, precision);

            var expected = Matrix<double>.Build.Dense(0, 0);

            MatrixAssert.AreEqual(expected, actual.X, precision);
            Assert.AreEqual(SolutionsNumber.InfinitelyManySolutions, actual.SolutionsNumber);
            Assert.IsTrue(
                actual.Determinants.All(
                    x => MathUtils.AreEqual(x.Determinant, 0, precision)));
        }
    }
}
