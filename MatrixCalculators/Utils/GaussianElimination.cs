using MathNet.Numerics.LinearAlgebra;
using MatrixCalculators.Utils.RowOperations;
using System;
using System.Collections.Generic;

namespace MatrixCalculators.Utils
{
    public class GaussianElimination
    {
        public List<RowOperation> RowOperations { get; }
        public Matrix<double> Initial { get; }
        public Matrix<double> Result { get; }

        public GaussianElimination(Matrix<double> matrix, int precision)
        {
            RowOperations = new List<RowOperation>();
            Initial = matrix;

            int i = 0;
            int j = 0;
            var currentMatrix = matrix;

            while ((i < currentMatrix.RowCount) && (j < currentMatrix.ColumnCount))
            {
                // Check if we need to switch rows
                double maxAbs = Math.Abs(currentMatrix[i, j]);
                int secondRow = i;

                for(int k = i + 1; k < currentMatrix.RowCount; k++)
                {
                    if(maxAbs < Math.Abs(currentMatrix[k, j]))
                    {
                        maxAbs = Math.Abs(currentMatrix[k, j]);
                        secondRow = k;
                    }
                }

                if (MathUtils.AreEqual(maxAbs, 0, precision))
                {
                    j++;
                    continue;
                }

                if(secondRow != i)
                {
                    var rowSwitching = new RowSwitching(
                        currentMatrix,
                        Matrix<double>.Build.DenseOfMatrix(currentMatrix),
                        i,
                        secondRow);

                    var rowBuffer = currentMatrix.Row(i);
                    rowSwitching.Result.SetRow(i, currentMatrix.Row(secondRow));
                    rowSwitching.Result.SetRow(secondRow, rowBuffer);
                    
                    RowOperations.Add(rowSwitching);
                    currentMatrix = rowSwitching.Result;
                }

                // Add row Ri to all rows below Ri
                var rowAdditionsSet = new RowAdditionsSet(
                    currentMatrix, 
                    Matrix<double>.Build.DenseOfMatrix(currentMatrix));

                for(int k = i + 1; k < currentMatrix.RowCount; k++)
                {
                    double multiplier = -currentMatrix[k, j] / currentMatrix[i, j];
                    rowAdditionsSet.Additions.Add((k, i, multiplier));

                    for(int m = 0; m < currentMatrix.ColumnCount; m++)
                    {
                        rowAdditionsSet.Result[k, m] += multiplier * currentMatrix[i, m];
                    }
                }

                if(rowAdditionsSet.Additions.Count > 0)
                {
                    RowOperations.Add(rowAdditionsSet);
                    currentMatrix = rowAdditionsSet.Result;
                }

                i++;
                j++;
            }

            Result = currentMatrix;
        }
    }
}
