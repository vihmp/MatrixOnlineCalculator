using MathNet.Numerics.LinearAlgebra;

namespace MatrixOnlineCalculator.Models.ElementaryRowOperations
{
    public class RowSwitching : ElementaryRowOperation
    {
        public int FirstRow { get; }
        public int SecondRow { get; }

        public RowSwitching(Matrix<double> initial, Matrix<double> result, int firstRow, int secondRow)
            : base(initial, result)
        {
            FirstRow = firstRow;
            SecondRow = secondRow;
        }
    }
}
