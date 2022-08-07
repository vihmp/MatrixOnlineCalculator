using MathNet.Numerics.LinearAlgebra;

namespace MatrixOnlineCalculator.Models.DeterminantCalculation
{
    public interface IDeterminantCalculation
    {
        public Matrix<double> Matrix { get; }
        public double Determinant { get; }
    }
}
