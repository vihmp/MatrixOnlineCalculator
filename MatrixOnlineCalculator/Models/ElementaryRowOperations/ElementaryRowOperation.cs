using MathNet.Numerics.LinearAlgebra;

namespace MatrixOnlineCalculator.Models.ElementaryRowOperations
{
    public abstract class ElementaryRowOperation
    {
        public Matrix<double> Initial { get; }
        public Matrix<double> Result { get; }

        protected ElementaryRowOperation(Matrix<double> initial, Matrix<double> result)
        {
            Initial = initial;
            Result = result;
        }
    }
}
