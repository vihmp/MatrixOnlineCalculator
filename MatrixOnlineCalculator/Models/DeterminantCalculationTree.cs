using System.Collections.Generic;
using MathNet.Numerics.LinearAlgebra;

namespace MatrixOnlineCalculator.Models
{
    public class DeterminantCalculationTree
    {
        public Matrix<double> Matrix { get; private set; }
        public double Determinant { get; private set; }
        public List<DeterminantCalculationTree> Subtrees { get; private set; }

        public DeterminantCalculationTree(Matrix<double> matrix)
        {
            Matrix = matrix;
            Determinant = 0;
            Subtrees = new List<DeterminantCalculationTree>();

            if(matrix.ColumnCount > 1)
            {
                for (int j = 0; j < matrix.ColumnCount; j++)
                {
                    var submatrix = matrix.RemoveRow(0).RemoveColumn(j);
                    var substep = new DeterminantCalculationTree(submatrix);
                    Subtrees.Add(substep);

                    double multiplier = j % 2 == 0 ? matrix[0, j] : -matrix[0, j];
                    Determinant += multiplier * substep.Determinant;
                }
            }
            else
            {
                Determinant = matrix[0, 0];
            }
        }
    }
}
