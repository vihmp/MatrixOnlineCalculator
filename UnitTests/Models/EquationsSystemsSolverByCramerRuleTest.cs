using MathNet.Numerics.LinearAlgebra;
using NUnit.Framework;
using MatrixOnlineCalculator.Models.EquationsSystemsSolvers;
using System.Linq;
using MatrixOnlineCalculator.Models;

namespace UnitTests.Models
{
    [TestFixture]
    class EquationsSystemsSolverByCramerRuleTest
    {
        [Test]
        public void EquationsSystemsSolverByCramerRuleOneSolution()
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

            var actual = new EquationsSystemsSolverByCramerRule(a, b);

            for (int i = 0; i < expected.RowCount; i++)
            {
                Assert.AreEqual(expected[i, 0], actual.X[i, 0], 0.0001);
            }

            Assert.AreEqual(SolutionsNumber.OneSolution, actual.SolutionsNumber);
        }

        [Test]
        public void EquationsSystemsSolverByCramerRuleNoSolutions()
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

            var actual = new EquationsSystemsSolverByCramerRule(a, b);

            Assert.AreEqual(0, actual.X.RowCount);
            Assert.AreEqual(0, actual.Determinants[0].Determinant, 0.0001);
            Assert.IsTrue(
                actual.Determinants.Any(
                    x => !MathUtils.AreEqual(x.Determinant, 0, 0.0001)));
            Assert.AreEqual(SolutionsNumber.NoSolution, actual.SolutionsNumber);
        }

        [Test]
        public void EquationsSystemsSolverByCramerRuleManySolutions()
        {
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

            var actual = new EquationsSystemsSolverByCramerRule(a, b);

            Assert.AreEqual(0, actual.X.RowCount);
            Assert.AreEqual(0, actual.Determinants[0].Determinant, 0.0001);
            Assert.IsTrue(
                actual.Determinants.All(
                    x => MathUtils.AreEqual(x.Determinant, 0, 0.0001)));
            Assert.AreEqual(SolutionsNumber.InfinitelyManySolutions, actual.SolutionsNumber);
        }
    }
}
