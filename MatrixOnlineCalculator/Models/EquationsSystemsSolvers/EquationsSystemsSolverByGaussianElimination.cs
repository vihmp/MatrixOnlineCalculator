using MathNet.Numerics.LinearAlgebra;
using MatrixOnlineCalculator.Models.GaussianEliminationCalculation;
using System.Collections.Generic;
using System.Linq;

namespace MatrixOnlineCalculator.Models.EquationsSystemsSolvers
{
    public class EquationsSystemsSolverByGaussianElimination : IEquationsSystemsSolver
    {
        public class BasicVariableCalculation
        {
            public int CalculatedVariableIndex { get; set; }
            public double Divider { get; set; }
            public double[] PolynomCoefficients { get; set; }
        }

        public Matrix<double> A { get; }
        public Matrix<double> B { get; }
        public Matrix<double> X { get; private set; }
        public SolutionsNumber SolutionsNumber { get; }
        public GaussianElimination GaussianElimination { get; }
        public List<BasicVariableCalculation> BasicVariablesCalculation { get; }
        public List<int> FreeVariablesIndices { get; }

        public EquationsSystemsSolverByGaussianElimination(Matrix<double> a, Matrix<double> b)
        {
            var augmentedMatrix = a.Append(b);

            A = a;
            B = b;
            GaussianElimination = new GaussianElimination(augmentedMatrix);
            FreeVariablesIndices = new List<int>();
            BasicVariablesCalculation = new List<BasicVariableCalculation>();

            int aRank = a.Rank();
            int augmentedMatrixRank = augmentedMatrix.Rank();

            if(aRank == augmentedMatrixRank)
            {
                if(augmentedMatrixRank == a.ColumnCount)
                {
                    SolutionsNumber = SolutionsNumber.SingleSolution;
                }
                else 
                {
                    SolutionsNumber = SolutionsNumber.InfinitelyManySolutions;
                }

                GetSolution();
            }
            else 
            {
                X = Matrix<double>.Build.Dense(0, 0);
                SolutionsNumber = SolutionsNumber.NoSolution;
            }
        }

        private void GetSolution()
        {
            int variablesNumber = 
                GaussianElimination.Result.ColumnCount - 1;
            
            int row = 0;

            // Select basic and free variables
            for(int col = 0; col < variablesNumber; col++)
            {
                if ((row >= GaussianElimination.Result.RowCount) ||
                    MathUtils.AreEqual(GaussianElimination.Result[row, col], 0, MathUtils.Epsilon))
                {
                    FreeVariablesIndices.Add(col);
                }
                else
                {
                    var polynomCoefficients = new double[variablesNumber + 1];
                    polynomCoefficients[0] = GaussianElimination.Result.Row(row).Last();

                    for (int k = col + 1; k < variablesNumber; k++)
                    {
                        polynomCoefficients[k + 1] = -GaussianElimination.Result[row, k];
                    }

                    var variableCalculation = new BasicVariableCalculation()
                    {
                        CalculatedVariableIndex = col,
                        Divider = GaussianElimination.Result[row, col],
                        PolynomCoefficients = polynomCoefficients
                    };

                    BasicVariablesCalculation.Insert(0, variableCalculation);
                    row++;
                }
            }

            X = Matrix<double>.Build.Dense(
                variablesNumber, 
                FreeVariablesIndices.Count + 1);

            // Set free variables values
            for (int i = 0; i < FreeVariablesIndices.Count; i++)
            {
                var variableIndex = FreeVariablesIndices[i];

                X[variableIndex, i + 1] = 1;
            }

            // Calculate basic variables values
            foreach (var variableCalculation in BasicVariablesCalculation)
            {
                var calcVarIndex = variableCalculation.CalculatedVariableIndex;

                X[calcVarIndex, 0] = variableCalculation.PolynomCoefficients[0];

                for (int varIndex = 0; varIndex < variablesNumber; varIndex++)
                {
                    var coeff = 
                        variableCalculation.PolynomCoefficients[varIndex + 1];

                    for (int i = 0; i < X.ColumnCount; i++)
                    {
                        X[calcVarIndex, i] += coeff * X[varIndex, i];
                    }
                }

                for (int i = 0; i < X.ColumnCount; i++)
                {
                    X[calcVarIndex, i] = 
                        X[calcVarIndex, i] / variableCalculation.Divider;
                }
            }
        }
    }
}
