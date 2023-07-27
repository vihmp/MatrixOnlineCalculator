using MathNet.Numerics.LinearAlgebra;
using MatrixCalculators.Utils;
using MatrixCalculators.Utils.RowOperations;
using System.Linq;

namespace MatrixCalculators.DeterminantCalculators
{
    public class DcGaussianElimination : IDeterminantCalculator
    {
        public IDeterminantCalculatorSolution GetDeterminant(
            Matrix<double> matrix, 
            int precision)
        {
            var solutionSteps = new GaussianElimination(matrix, precision);

            int rowSwitchingNumber = solutionSteps.RowOperations
                .OfType<RowSwitching>()
                .Count();

            // Interchanging any pair of rows of a matrix multiplies its determinant by −1
            var determinant = 
                (rowSwitchingNumber % 2 == 0) ? 1.0 : -1.0;

            for(int i = 0; i < solutionSteps.Result.RowCount; i++)
            {
                determinant *= solutionSteps.Result[i, i];
            }

            return new DcGaussianEliminationSolution
            {
                Determinant = determinant,
                SolutionSteps = solutionSteps
            };
        }
    }
}
