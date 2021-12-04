using MathNet.Numerics.LinearAlgebra;
using MatrixOnlineCalculator.Models.DeterminantCalculation;
using NUnit.Framework;
using System.Collections.Generic;

namespace UnitTests.Models
{
    [TestFixture]
    public class LaplaceExpansionTest
    {
        [Test]
        public void LaplaceExpansion()
        {
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

            var laplaceExpansion = new LaplaceExpansion(matrix);

            Assert.AreEqual(0, laplaceExpansion.Determinant, 0.0001);
            Assert.AreEqual(3, laplaceExpansion.Minors.Count);

            for(int k = 0; k < 3; k++)
            {
                Assert.AreEqual(expectedMinors[k].Row, laplaceExpansion.Minors[k].Row);
                Assert.AreEqual(expectedMinors[k].Column, laplaceExpansion.Minors[k].Column);
                
                Assert.AreEqual(2, laplaceExpansion.Minors[k].Minor.Matrix.RowCount);
                Assert.AreEqual(2, laplaceExpansion.Minors[k].Minor.Matrix.ColumnCount);

                for (int i = 0; i < 2; i++)
                {
                    for(int j = 0; j < 2; j++)
                    {
                        Assert.AreEqual(
                            expectedMinors[k].Minor[i, j], 
                            laplaceExpansion.Minors[k].Minor.Matrix[i, j],
                            0.0001);
                    }
                }
            }
        }

        [Test]
        public void LaplaceExpansionOneElementMatrix()
        {
            var matrix = Matrix<double>.Build.DenseOfRowArrays(new double[][]
            {
                new double[] { 1 }
            });

            var laplaceExpansion = new LaplaceExpansion(matrix);

            Assert.AreEqual(1, laplaceExpansion.Determinant, 0.0001);
            Assert.AreEqual(0, laplaceExpansion.Minors.Count);
        }
    }
}
