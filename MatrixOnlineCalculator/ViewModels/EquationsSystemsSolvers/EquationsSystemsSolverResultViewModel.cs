using MatrixOnlineCalculator.Models.EquationsSystemsSolvers;

namespace MatrixOnlineCalculator.ViewModels.EquationsSystemsSolvers
{
    public class EquationsSystemsSolverResultViewModel
    {
        public string MethodName { get; set; }
        public IEquationsSystemsSolver DetailedSolution { get; set; }
        public string DetailedSolutionViewName { get; set; }
    }
}
