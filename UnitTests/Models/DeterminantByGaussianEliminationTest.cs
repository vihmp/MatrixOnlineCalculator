﻿using MathNet.Numerics.LinearAlgebra;
using MatrixOnlineCalculator.Models.DeterminantCalculation;
using NUnit.Framework;
using System;

namespace UnitTests.Models
{
    [TestFixture]
    public class DeterminantByGaussianEliminationTest
    {
        [Test]
        public void DeterminantByGaussianEliminationNoRowSwitching()
        {
            int precision = 5;
            double delta = Math.Pow(0.1, precision);

            var a = Matrix<double>.Build.DenseOfRowArrays(new double[][]
            {
                new double[] { 4, 4, 4, 4 },
                new double[] { 1, 4, 4, 4 },
                new double[] { 1, 2, 4, 4 },
                new double[] { 1, 2, 3, 4 }
            });

            var actual = new DeterminantByGaussianElimination(a, precision);

            Assert.AreEqual(24, actual.Determinant, delta);
        }

        [Test]
        public void DeterminantByGaussianEliminationRowSwitchingOddNumber()
        {
            int precision = 5;
            double delta = Math.Pow(0.1, precision);

            var a = Matrix<double>.Build.DenseOfRowArrays(new double[][]
            {
                new double[] { 1, 4, 4, 4 },
                new double[] { 4, 4, 4, 4 },
                new double[] { 1, 2, 4, 4 },
                new double[] { 1, 2, 3, 4 }
            });

            var actual = new DeterminantByGaussianElimination(a, precision);

            Assert.AreEqual(-24, actual.Determinant, delta);
        }

        [Test]
        public void DeterminantByGaussianEliminationRowSwitchingEvenNumber()
        {
            int precision = 5;
            double delta = Math.Pow(0.1, precision);

            var a = Matrix<double>.Build.DenseOfRowArrays(new double[][]
            {
                new double[] { 1, 2, 4, 4 },
                new double[] { 4, 4, 4, 4 },
                new double[] { 1, 4, 4, 4 },
                new double[] { 1, 2, 3, 4 }
            });

            var actual = new DeterminantByGaussianElimination(a, precision);

            Assert.AreEqual(24, actual.Determinant, delta);
        }
    }
}
