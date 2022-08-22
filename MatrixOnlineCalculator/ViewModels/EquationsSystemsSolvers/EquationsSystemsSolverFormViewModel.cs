namespace MatrixOnlineCalculator.ViewModels.EquationsSystemsSolvers
{
    public class EquationsSystemsSolverFormViewModel
    {
        public string MethodName { get; set; }
        public string ActionName { get; set; }
        public int MinVariablesNumber { get; set; }
        public int MaxVariablesNumber { get; set; }
        public int DefaultVariablesNumber { get; set; }
        public int MinEquationsNumber { get; set; }
        public int MaxEquationsNumber { get; set; }
        public int DefaultEquationsNumber { get; set; }
    }
}
