using MathNet.Numerics.LinearAlgebra;
using System.Collections.Generic;

namespace MatrixOnlineCalculator.Models.ElementaryRowOperations
{
    public class RowAdditionsSet : ElementaryRowOperation
    {
        public List<(int FirstSummandRow, int SecondSummandRow, double Multiplier)> Additions { get; }

        public RowAdditionsSet(Matrix<double> initial, Matrix<double> result)
            : base(initial, result)
        {
            Additions = new List<(int FirstSummandRow, int SecondSummandRow, double Multiplier)>();
        }
    }
}
