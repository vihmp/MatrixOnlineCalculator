using MathNet.Numerics.LinearAlgebra;
using MatrixCalculators.Utils;

namespace MatrixCalculators.DeterminantCalculators
{
    public class DcGaussianEliminationSolution : IDeterminantCalculatorSolution
    {
        public double Determinant { get; init; }
        public GaussianElimination SolutionSteps { get; init; }
        public Matrix<double> Matrix { get => SolutionSteps.Initial; }

    }
}
