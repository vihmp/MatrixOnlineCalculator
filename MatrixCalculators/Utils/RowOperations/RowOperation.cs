using MathNet.Numerics.LinearAlgebra;

namespace MatrixCalculators.Utils.RowOperations
{
    public abstract class RowOperation
    {
        public Matrix<double> Initial { get; }
        public Matrix<double> Result { get; }

        protected RowOperation(Matrix<double> initial, Matrix<double> result)
        {
            Initial = initial;
            Result = result;
        }
    }
}
