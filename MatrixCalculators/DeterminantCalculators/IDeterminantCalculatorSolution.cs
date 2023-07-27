using MathNet.Numerics.LinearAlgebra;

namespace MatrixCalculators.DeterminantCalculators
{
    public interface IDeterminantCalculatorSolution
    {
        Matrix<double> Matrix { get; }
        double Determinant { get; }
    }
}
