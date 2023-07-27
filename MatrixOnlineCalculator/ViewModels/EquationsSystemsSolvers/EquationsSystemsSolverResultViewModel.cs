using MatrixCalculators.EquationsSystemsSolvers;

namespace MatrixOnlineCalculator.ViewModels.EquationsSystemsSolvers
{
    public class EquationsSystemsSolverResultViewModel
    {
        public string MethodName { get; set; }
        public IEquationsSystemsSolverSolution DetailedSolution { get; set; }
        public string DetailedSolutionViewName { get; set; }
    }
}
