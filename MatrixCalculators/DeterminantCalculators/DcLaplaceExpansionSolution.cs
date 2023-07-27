using MathNet.Numerics.LinearAlgebra;
using MatrixCalculators.Utils;

namespace MatrixCalculators.DeterminantCalculators
{
    public class DcLaplaceExpansionSolution : IDeterminantCalculatorSolution
    {
        public LaplaceExpansion SolutionSteps { get; init; }
        public Matrix<double> Matrix { get => SolutionSteps.Matrix; }
        public double Determinant { get => SolutionSteps.Determinant; }
    }
}
