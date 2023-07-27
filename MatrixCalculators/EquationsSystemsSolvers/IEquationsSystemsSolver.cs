using MathNet.Numerics.LinearAlgebra;

namespace MatrixCalculators.EquationsSystemsSolvers
{
    public interface IEquationsSystemsSolver
    {
        IEquationsSystemsSolverSolution Solve(
            Matrix<double> a,
            Matrix<double> b,
            int precision);
    }
}
