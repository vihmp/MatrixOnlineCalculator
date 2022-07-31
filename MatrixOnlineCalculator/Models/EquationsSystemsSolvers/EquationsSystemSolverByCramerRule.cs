using MathNet.Numerics.LinearAlgebra;
using MatrixOnlineCalculator.Models.DeterminantCalculation;
using System.Collections.Generic;

namespace MatrixOnlineCalculator.Models.EquationsSystemsSolvers
{
    public class EquationsSystemSolverByCramerRule
    {
        public Matrix<double> A { get; }
        public Matrix<double> B { get; }
        public List<double> X { get; }
        public List<DeterminantByGaussianElimination> Determinants { get; }

        public EquationsSystemSolverByCramerRule(Matrix<double> a, Matrix<double> b)
        {
            A = a;
            B = b;
            X = new List<double>();
            Determinants = new List<DeterminantByGaussianElimination>();
            
            Determinants.Add(new DeterminantByGaussianElimination(a));

            for (int j = 0; j < a.ColumnCount; j++)
            {
                var buffer = a.Clone();

                for (int i = 0; i < buffer.RowCount; i++)
                {
                    buffer[i, j] = b[i, 0];
                }

                Determinants.Add(new DeterminantByGaussianElimination(buffer));
            }

            if (!MathUtils.AreEqual(Determinants[0].Determinant, 0, MathUtils.Epsilon))
            {
                for (int i = 1; i < Determinants.Count; i++)
                {
                    X.Add(Determinants[i].Determinant / Determinants[0].Determinant);
                }
            }
        }
    }
}
