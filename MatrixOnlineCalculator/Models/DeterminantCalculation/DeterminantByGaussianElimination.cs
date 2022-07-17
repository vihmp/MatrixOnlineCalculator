using MathNet.Numerics.LinearAlgebra;
using MatrixOnlineCalculator.Models.GaussianEliminationCalculation;
using MatrixOnlineCalculator.Models.GaussianEliminationCalculation.ElementaryRowOperations;
using System.Linq;

namespace MatrixOnlineCalculator.Models.DeterminantCalculation
{
    public class DeterminantByGaussianElimination
    {
        public double Determinant { get; }

        public GaussianElimination GaussianElimination { get; }

        public DeterminantByGaussianElimination(Matrix<double> matrix)
        {
            GaussianElimination = new GaussianElimination(matrix);

            int rowSwitchingNumber = GaussianElimination.ElementaryRowOperations
                .OfType<RowSwitching>()
                .Count();

            // Interchanging any pair of rows of a matrix multiplies its determinant by −1
            Determinant = 
                (rowSwitchingNumber % 2 == 0) ? 1.0 : -1.0;

            for(int i = 0; i < GaussianElimination.Result.RowCount; i++)
            {
                Determinant *= GaussianElimination.Result[i, i];
            }
        }
    }
}
