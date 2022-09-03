using MathNet.Numerics.LinearAlgebra;
using MatrixOnlineCalculator.Models;
using NUnit.Framework;
using System;

namespace UnitTests.TestUtils
{
    public static class MatrixAssert
    {
        public static void AreEqual(Matrix<double> expected, Matrix<double> actual, int precision)
        {
            if (actual.RowCount != expected.RowCount)
            {
                throw new AssertionException(
                    $"Expected row count: {expected.RowCount}; but was: {actual.RowCount}");
            }

            if (actual.ColumnCount != expected.ColumnCount)
            {
                throw new AssertionException(
                    $"Expected column count: {expected.ColumnCount}; but was: {actual.ColumnCount}");
            }

            double delta = Math.Pow(0.1, precision);

            for (int i = 0; i < actual.RowCount; i++)
            {
                for (int j = 0; j < actual.ColumnCount; j++)
                {
                    if (!MathUtils.AreEqual(actual[i, j], expected[i, j], precision))
                    {
                        throw new AssertionException(
                            $"Element at row {i} column {j}{Environment.NewLine}" + 
                            $"Expected: {expected[i, j]} +/- {delta}{Environment.NewLine}" +
                            $"But was:  {actual[i, j]}");
                    }
                }
            }
        }
    }
}
