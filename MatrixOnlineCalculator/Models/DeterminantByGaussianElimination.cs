using MathNet.Numerics.LinearAlgebra;

namespace MatrixOnlineCalculator.Models
{
    public class DeterminantByGaussianElimination
    {
        public double Determinant { get; }

        public GaussianElimination GaussianElimination { get; }

        public DeterminantByGaussianElimination(Matrix<double> matrix)
        {
            GaussianElimination = new GaussianElimination(matrix);
            Determinant = 1.0;

            for(int i = 0; i < GaussianElimination.Result.RowCount; i++)
            {
                Determinant *= GaussianElimination.Result[i, i];
            }
        }
    }
}
