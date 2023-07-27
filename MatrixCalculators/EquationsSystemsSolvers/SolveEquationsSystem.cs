using MathNet.Numerics.LinearAlgebra;

namespace MatrixCalculators.EquationsSystemsSolvers
{
    public static class SolveEquationsSystem
    {
        public static IEquationsSystemsSolverSolution UsingCramerRule(
            Matrix<double> a,
            Matrix<double> b,
            int precision)
        {
            var calculator = new EssCramerRule();

            return calculator.Solve(a, b, precision);
        }

        public static IEquationsSystemsSolverSolution UsingGaussianElimination(
            Matrix<double> a,
            Matrix<double> b,
            int precision)
        {
            var calculator = new EssGaussianElimination();

            return calculator.Solve(a, b, precision);
        }
    }
}
