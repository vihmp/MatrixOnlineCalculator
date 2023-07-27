using MathNet.Numerics.LinearAlgebra;

namespace MatrixCalculators.Utils.RowOperations
{
    public class RowSwitching : RowOperation
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
