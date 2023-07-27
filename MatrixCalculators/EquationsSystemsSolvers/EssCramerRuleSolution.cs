using MathNet.Numerics.LinearAlgebra;
using System.Collections.Generic;

namespace MatrixCalculators.EquationsSystemsSolvers
{
    public class EssCramerRuleSolution : IEquationsSystemsSolverSolution
    {
        public class SolutionStep
        {
            public Matrix<double> Matrix { get; init; }
            public double Determinant { get; init; }
        }

        public Matrix<double> A { get; init; }
        public Matrix<double> B { get; init; }
        public Matrix<double> X { get; init; }
        public SolutionsNumber SolutionsNumber { get; init; }
        public List<SolutionStep> SolutionSteps { get; init; }
    }
}
