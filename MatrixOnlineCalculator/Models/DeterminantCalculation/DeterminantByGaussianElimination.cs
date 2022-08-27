using MathNet.Numerics.LinearAlgebra;
using MatrixOnlineCalculator.Models.GaussianEliminationCalculation;
using MatrixOnlineCalculator.Models.GaussianEliminationCalculation.ElementaryRowOperations;
using System.Linq;

namespace MatrixOnlineCalculator.Models.DeterminantCalculation
{
    public class DeterminantByGaussianElimination : IDeterminantCalculation
    {
        public double Determinant { get; }
        public GaussianElimination GaussianElimination { get; }
        public Matrix<double> Matrix 
        { 
            get
            {
                return GaussianElimination.Initial;
            }
        }

        public DeterminantByGaussianElimination(Matrix<double> matrix, int precision)
        {
            GaussianElimination = new GaussianElimination(matrix, precision);

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
