using MathNet.Numerics.LinearAlgebra;
using MatrixCalculators.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using UnitTests.TestUtils;

namespace UnitTests.MatrixCalculators.Utils
{
    [TestFixture]
    public class LaplaceExpansionTest
    {
        [Test]
        public void LaplaceExpansion()
        {
            int precision = 5;
            double delta = Math.Pow(0.1, precision);

            var matrix = Matrix<double>.Build.DenseOfRowArrays(new double[][]
            {
                new double[] { 1, 2, 3 },
                new double[] { 4, 5, 6 },
                new double[] { 7, 8, 9 }
            });

            var expectedMinors = new List<(int Row, int Column, Matrix<double> Minor)>
            {
                (1, 1, Matrix<double>.Build.DenseOfRowArrays(new double[][]
                    {
                        new double[] { 5, 6, },
                        new double[] { 8, 9  }
                    })),
                (1, 2, Matrix<double>.Build.DenseOfRowArrays(new double[][]
                    {
                        new double[] { 4, 6, },
                        new double[] { 7, 9  }
                    })),
                (1, 3, Matrix<double>.Build.DenseOfRowArrays(new double[][]
                    {
                        new double[] { 4, 5, },
                        new double[] { 7, 8  }
                    }))
            };

            var laplaceExpansion = new LaplaceExpansion(matrix, precision);

            Assert.AreEqual(0, laplaceExpansion.Determinant, delta);
            Assert.AreEqual(3, laplaceExpansion.Minors.Count);

            for(int k = 0; k < 3; k++)
            {
                Assert.AreEqual(expectedMinors[k].Row, laplaceExpansion.Minors[k].Row);
                Assert.AreEqual(expectedMinors[k].Column, laplaceExpansion.Minors[k].Column);
                MatrixAssert.AreEqual(
                    expectedMinors[k].Minor, 
                    laplaceExpansion.Minors[k].Minor.Matrix, 
                    precision);
            }
        }

        [Test]
        public void LaplaceExpansionOneElementMatrix()
        {
            int precision = 5;
            double delta = Math.Pow(0.1, precision);

            var matrix = Matrix<double>.Build.DenseOfRowArrays(new double[][]
            {
                new double[] { 1 }
            });

            var laplaceExpansion = new LaplaceExpansion(matrix, precision);

            Assert.AreEqual(1, laplaceExpansion.Determinant, delta);
            Assert.AreEqual(0, laplaceExpansion.Minors.Count);
        }
    }
}
