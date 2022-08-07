using MatrixOnlineCalculator.Models.DeterminantCalculation;

namespace MatrixOnlineCalculator.ViewModels.DeterminantCalculation
{
    public class DeterminantCalculationResultViewModel
    {
        public string MethodName { get; set; }
        public IDeterminantCalculation DetailedSolution { get; set; }
        public string DetailedSolutionViewName { get; set; }
    }
}
