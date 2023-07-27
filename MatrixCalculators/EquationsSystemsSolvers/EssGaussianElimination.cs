using MathNet.Numerics.LinearAlgebra;
using MatrixCalculators.Utils;
using System.Collections.Generic;

namespace MatrixCalculators.EquationsSystemsSolvers
{
    public class EssGaussianElimination : IEquationsSystemsSolver
    {
        public IEquationsSystemsSolverSolution Solve(
            Matrix<double> a, 
            Matrix<double> b,
            int precision)
        {
            Matrix<double> x;
            SolutionsNumber solutionsNumber;
            List<int> freeVariables;
            List<int> basicVariables;

            var augmentedMatrix = a.Append(b);
            var solutionSteps = 
                new GaussianElimination(augmentedMatrix, precision);

            int aRank = a.Rank();
            int augmentedMatrixRank = augmentedMatrix.Rank();

            if (aRank == augmentedMatrixRank)
            {
                if(augmentedMatrixRank == a.ColumnCount)
                {
                    solutionsNumber = SolutionsNumber.OneSolution;
                }
                else 
                {
                    solutionsNumber = SolutionsNumber.InfinitelyManySolutions;
                }

                (freeVariables, basicVariables) = 
                    SelectVariables(solutionSteps.Result,precision);
                x = GetVariablesValues(
                    solutionSteps.Result, 
                    freeVariables, 
                    basicVariables, 
                    precision);
            }
            else 
            {
                x = Matrix<double>.Build.Dense(0, 0);
                solutionsNumber = SolutionsNumber.NoSolution;
                freeVariables = new List<int>();
                basicVariables = new List<int>();
            }

            return new EssGaussianEliminationSolution
            {
                A = a,
                B = b,
                X = x,
                SolutionsNumber = solutionsNumber,
                SolutionSteps = solutionSteps,
                BasicVariables = basicVariables,
                FreeVariables = freeVariables
            };
        }

        private (List<int> Free, List<int> Basic) SelectVariables(
            Matrix<double> rowEchelonMatrix, 
            int precision)
        {
            int variablesNumber = rowEchelonMatrix.ColumnCount - 1;

            var freeVariables = new List<int>();
            var basicVariables = new List<int>();
            int row = 0;

            for (int col = 0; col < variablesNumber; col++)
            {
                if ((row >= rowEchelonMatrix.RowCount) ||
                    MathUtils.AreEqual(rowEchelonMatrix[row, col], 0, precision))
                {
                    freeVariables.Add(col);
                }
                else
                {
                    basicVariables.Add(col);
                    row++;
                }
            }

            basicVariables.Reverse();

            return (freeVariables, basicVariables);
        }

        private Matrix<double> GetVariablesValues(
            Matrix<double> rowEchelonMatrix,
            List<int> freeVariables,
            List<int> basicVariables,
            int precision)
        {
            int variablesNumber = rowEchelonMatrix.ColumnCount - 1;

            var x = Matrix<double>.Build.Dense(
                variablesNumber,
                freeVariables.Count + 1);

            // Set free variables values
            for (int i = 0; i < freeVariables.Count; i++)
            {
                var variableIndex = freeVariables[i];
                x[variableIndex, i + 1] = 1;
            }

            // Calculate basic variables values
            for (int i = 0; i < basicVariables.Count; i++)
            {
                int basicVariable = basicVariables[i];
                x[basicVariable, 0] = rowEchelonMatrix[basicVariable, variablesNumber];

                for (int j = basicVariable + 1; j < variablesNumber; j++)
                {
                    if (!MathUtils.AreEqual(rowEchelonMatrix[i, j], 0, precision))
                    {
                        for (int k = 0; k < x.ColumnCount; k++)
                        {
                            x[basicVariable, k] += rowEchelonMatrix[i, j] * x[j, k];
                        }
                    }
                }

                for (int k = 0; k < x.ColumnCount; k++)
                {
                    x[basicVariable, k] /= rowEchelonMatrix[i, basicVariable];
                }
            }

            return x;
        }
    }
}
