using MatrixCalculators.DeterminantCalculators;

namespace MatrixOnlineCalculator.ViewModels.DeterminantCalculation
{
    public class DeterminantCalculationResultViewModel
    {
        public string MethodName { get; set; }
        public IDeterminantCalculatorSolution DetailedSolution { get; set; }
        public string DetailedSolutionViewName { get; set; }
    }
}
