using MathNet.Numerics.LinearAlgebra;
using MatrixOnlineCalculator.Models.DeterminantCalculation;
using System.Collections.Generic;
using System.Linq;

namespace MatrixOnlineCalculator.Models.EquationsSystemsSolvers
{
    public class EquationsSystemsSolverByCramerRule : IEquationsSystemsSolver
    {
        public Matrix<double> A { get; }
        public Matrix<double> B { get; }
        public Matrix<double> X { get; }
        public SolutionsNumber SolutionsNumber { get; }
        public List<IDeterminantCalculation> Determinants { get; }

        public EquationsSystemsSolverByCramerRule(Matrix<double> a, Matrix<double> b)
        {
            A = a;
            B = b;
            Determinants = new List<IDeterminantCalculation>();
            
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
                int variablesNumber = b.RowCount;
                X = Matrix<double>.Build.Dense(variablesNumber, 1);

                for (int i = 0; i < variablesNumber; i++)
                {
                    X[i, 0] = Determinants[i + 1].Determinant / Determinants[0].Determinant;
                }

                SolutionsNumber = SolutionsNumber.SingleSolution;
            }
            else
            {
                X = Matrix<double>.Build.Dense(0, 0);

                if (Determinants.Skip(1).Any(x => x.Determinant != 0))
                {
                    SolutionsNumber = SolutionsNumber.NoSolution;
                }
                else
                {
                    SolutionsNumber = SolutionsNumber.InfinitelyManySolutions;
                }
            }
        }
    }
}
