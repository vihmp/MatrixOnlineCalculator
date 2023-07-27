using MathNet.Numerics.LinearAlgebra;
using MatrixCalculators.Utils;

namespace MatrixCalculators.DeterminantCalculators
{
    public class DcLaplaceExpansion : IDeterminantCalculator
    {
        public IDeterminantCalculatorSolution GetDeterminant(
            Matrix<double> matrix, 
            int precision)
        {
            var solutionSteps = new LaplaceExpansion(matrix, precision);

            return new DcLaplaceExpansionSolution
            {
                SolutionSteps = solutionSteps
            };
        }
    }
}
