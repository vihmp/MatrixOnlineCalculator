using MathNet.Numerics.LinearAlgebra;
using MatrixCalculators.Utils;
using System.Collections.Generic;

namespace MatrixCalculators.EquationsSystemsSolvers
{
    public class EssGaussianEliminationSolution : IEquationsSystemsSolverSolution
    {
        public Matrix<double> A { get; init; }
        public Matrix<double> B { get; init; }
        public Matrix<double> X { get; init; }
        public SolutionsNumber SolutionsNumber { get; init; }
        public GaussianElimination SolutionSteps { get; init; }
        public List<int> BasicVariables { get; init; }
        public List<int> FreeVariables { get; init; }
    }
}
