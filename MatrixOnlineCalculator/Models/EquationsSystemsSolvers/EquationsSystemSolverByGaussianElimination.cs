using MathNet.Numerics.LinearAlgebra;
using MatrixOnlineCalculator.Models.GaussianEliminationCalculation;
using System.Collections.Generic;

namespace MatrixOnlineCalculator.Models.EquationsSystemsSolvers
{
    public class EquationsSystemSolverByGaussianElimination
    {
        public Matrix<double> A { get; }
        public Matrix<double> B { get; }
        public Matrix<double> X { get; }
        public GaussianElimination GaussianElimination { get; }

        public EquationsSystemSolverByGaussianElimination(Matrix<double> a, Matrix<double> b)
        {
            var augmentedMatrix = a.Append(b);

            A = a;
            B = b;
            GaussianElimination = new GaussianElimination(augmentedMatrix);

            int aRank = a.Rank();
            int augmentedMatrixRank = augmentedMatrix.Rank();

            if(aRank == augmentedMatrixRank)
            {
                if(augmentedMatrixRank == a.ColumnCount)
                {
                    X = GetOneSolution(GaussianElimination);
                }
                else 
                {
                    X = GetManySolutions(GaussianElimination);
                }
            }
            else 
            {
                // No solutions
                X = Matrix<double>.Build.Dense(0, 0);
            }
        }

        private static Matrix<double> GetOneSolution(GaussianElimination gaussianElimination)
        {
            int variablesNumber = gaussianElimination.Result.ColumnCount - 1;
            int constantsColumn = gaussianElimination.Result.ColumnCount - 1;
            var X = Matrix<double>.Build.Dense(variablesNumber, 1);

            for (int i = X.RowCount - 1; i >= 0; i--)
            {
                X[i, 0] = gaussianElimination.Result[i, constantsColumn];

                for (int j = i + 1; j < X.RowCount; j++)
                {
                    X[i, 0] -= gaussianElimination.Result[i, j] * X[j, 0];
                }

                X[i, 0] /= gaussianElimination.Result[i, i];
            }

            return X;
        }

        private static Matrix<double> GetManySolutions(GaussianElimination gaussianElimination)
        {
            int constantsColumn = gaussianElimination.Result.ColumnCount - 1;
            int variablesNumber = gaussianElimination.Result.ColumnCount - 1;
            int basicVariablesNumber = gaussianElimination.Result.RemoveColumn(constantsColumn).Rank();
            int freeVariablesNumber = variablesNumber - basicVariablesNumber;

            var X = Matrix<double>.Build.Dense(variablesNumber, freeVariablesNumber + 1);
            var basicVariablesIndices = new List<int>();

            int i = 0;
            int j = 0;
            int currentFreeVariableNumber = 1;

            // Select basic and free variables
            for(j = 0; j < variablesNumber; j++)
            {
                if ((i >= gaussianElimination.Result.RowCount) ||
                    MathUtils.AreEqual(gaussianElimination.Result[i, j], 0, MathUtils.Epsilon))
                {
                    X[j, currentFreeVariableNumber] = 1;
                    currentFreeVariableNumber++;
                }
                else
                {
                    basicVariablesIndices.Add(j);
                    i++;
                }
            }

            // Calculate values of basic variables
            for(i = basicVariablesNumber - 1; i >= 0; i--)
            {
                j = basicVariablesIndices[i];

                X[j, 0] = gaussianElimination.Result[i, constantsColumn];

                for(int k = j + 1; k < variablesNumber; k++)
                {
                    double a = gaussianElimination.Result[i, k];
                    var ax = X.Row(k).Multiply(a);
                    X.SetRow(j, X.Row(j).Subtract(ax));
                }

                X.SetRow(j, X.Row(j).Divide(gaussianElimination.Result[i, j]));
            }

            return X;
        }
    }
}
