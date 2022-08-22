using MathNet.Numerics.LinearAlgebra;

namespace MatrixOnlineCalculator.Models.EquationsSystemsSolvers
{
    public interface IEquationsSystemsSolver
    {
        public Matrix<double> A { get; }
        public Matrix<double> B { get; }
        public Matrix<double> X { get; }
        public SolutionsNumber SolutionsNumber { get; }
    }
}
