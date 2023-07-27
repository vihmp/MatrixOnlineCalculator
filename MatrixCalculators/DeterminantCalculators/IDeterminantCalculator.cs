using MathNet.Numerics.LinearAlgebra;

namespace MatrixCalculators.DeterminantCalculators
{
    public interface IDeterminantCalculator
    {
        IDeterminantCalculatorSolution GetDeterminant(
            Matrix<double> matrix, 
            int precision);
    }
}
