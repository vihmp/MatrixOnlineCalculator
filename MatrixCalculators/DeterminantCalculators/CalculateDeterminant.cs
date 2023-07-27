using MathNet.Numerics.LinearAlgebra;

namespace MatrixCalculators.DeterminantCalculators
{
    public static class CalculateDeterminant
    {
        public static IDeterminantCalculatorSolution UsingGaussianElimination(
            Matrix<double> matrix,
            int precision)
        {
            var calculator = new DcGaussianElimination();

            return calculator.GetDeterminant(matrix, precision);
        }

        public static IDeterminantCalculatorSolution UsingLaplaceExpansion(
            Matrix<double> matrix,
            int precision)
        {
            var calculator = new DcLaplaceExpansion();

            return calculator.GetDeterminant(matrix, precision);
        }
    }
}
