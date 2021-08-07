using System.Collections.Generic;
using MathNet.Numerics.LinearAlgebra;

namespace MatrixOnlineCalculator.Models
{
    public class LaplaceExpansion
    {
        public Matrix<double> Matrix { get; private set; }
        public double Determinant { get; private set; }
        public List<(int Row, int Column, LaplaceExpansion Minor)> Minors { get; private set; }

        public LaplaceExpansion(Matrix<double> matrix)
        {
            Matrix = matrix;
            Determinant = 0;
            Minors = new List<(int Row, int Column, LaplaceExpansion Minor)>();

            if(matrix.ColumnCount > 1)
            {
                for (int j = 0; j < matrix.ColumnCount; j++)
                {
                    var submatrix = matrix.RemoveRow(0).RemoveColumn(j);
                    var minor = new LaplaceExpansion(submatrix);
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
