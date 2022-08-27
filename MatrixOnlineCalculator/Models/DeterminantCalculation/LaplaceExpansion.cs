using System.Collections.Generic;
using MathNet.Numerics.LinearAlgebra;

namespace MatrixOnlineCalculator.Models.DeterminantCalculation
{
    public class LaplaceExpansion : IDeterminantCalculation
    {
        public Matrix<double> Matrix { get; }
        public double Determinant { get; }
        public List<(int Row, int Column, LaplaceExpansion Minor)> Minors { get; }

        public LaplaceExpansion(Matrix<double> matrix, int precision)
        {
            Matrix = matrix;
            Determinant = 0;
            Minors = new List<(int Row, int Column, LaplaceExpansion Minor)>();

            if(matrix.ColumnCount > 1)
            {
                for (int j = 0; j < matrix.ColumnCount; j++)
                {
                    var submatrix = matrix.RemoveRow(0).RemoveColumn(j);
                    var minor = new LaplaceExpansion(submatrix, precision);
                    Minors.Add((1, j + 1, minor));

                    int sign = (j % 2 == 0) ? 1 : -1;
                    Determinant += sign * matrix[0, j] * minor.Determinant;
                }
            }
            else
            {
                Determinant = matrix[0, 0];
            }
        }
    }
}
