using MathNet.Numerics.LinearAlgebra;
using MatrixCalculators.DeterminantCalculators;
using MatrixCalculators.Utils;
using System.Collections.Generic;
using System.Linq;
using SolutionStep = MatrixCalculators.EquationsSystemsSolvers.EssCramerRuleSolution.SolutionStep;

namespace MatrixCalculators.EquationsSystemsSolvers
{
    public class EssCramerRule : IEquationsSystemsSolver
    {
        public IEquationsSystemsSolverSolution Solve(
            Matrix<double> a,
            Matrix<double> b,
            int precision)
        {
            var solutionSteps = BuildSolutionSteps(a, b, precision);
            Matrix<double> x;
            SolutionsNumber solutionsNumber;

            if (!MathUtils.AreEqual(solutionSteps[0].Determinant, 0, precision))
            {
                int variablesNumber = b.RowCount;
                x = Matrix<double>.Build.Dense(variablesNumber, 1);

                for (int i = 0; i < variablesNumber; i++)
                {
                    x[i, 0] = solutionSteps[i + 1].Determinant / solutionSteps[0].Determinant;
                }

                solutionsNumber = SolutionsNumber.OneSolution;
            }
            else
            {
                x = Matrix<double>.Build.Dense(0, 0);

                if (solutionSteps.Skip(1)
                    .Any(x => MathUtils.AreEqual(x.Determinant, 0, precision)))
                {
                    solutionsNumber = SolutionsNumber.NoSolution;
                }
                else
                {
                    solutionsNumber = SolutionsNumber.InfinitelyManySolutions;
                }
            }

            return new EssCramerRuleSolution
            {
                A = a,
                B = b,
                X = x,
                SolutionsNumber = solutionsNumber,
                SolutionSteps = solutionSteps
            };
        }

        private List<SolutionStep> BuildSolutionSteps(
            Matrix<double> a,
            Matrix<double> b,
            int precision)
        {
            var solutionSteps = new List<SolutionStep>();

            double determinant =
                CalculateDeterminant.UsingGaussianElimination(a, precision)
                .Determinant;
            solutionSteps.Add(
                new SolutionStep { Matrix = a, Determinant = determinant });

            for (int j = 0; j < a.ColumnCount; j++)
            {
                var buffer = a.Clone();

                for (int i = 0; i < buffer.RowCount; i++)
                {
                    buffer[i, j] = b[i, 0];
                }

                determinant =
                    CalculateDeterminant.UsingGaussianElimination(buffer, precision)
                    .Determinant;
                solutionSteps.Add(
                    new SolutionStep { Matrix = buffer, Determinant = determinant });
            }

            return solutionSteps;
        }
    }
}
