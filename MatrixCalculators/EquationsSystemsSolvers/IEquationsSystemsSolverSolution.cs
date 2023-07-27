using MathNet.Numerics.LinearAlgebra;

namespace MatrixCalculators.EquationsSystemsSolvers
{
    public interface IEquationsSystemsSolverSolution
    {
        Matrix<double> A { get; }
        Matrix<double> B { get; }
        Matrix<double> X { get; }
        SolutionsNumber SolutionsNumber { get; }
    }
}
