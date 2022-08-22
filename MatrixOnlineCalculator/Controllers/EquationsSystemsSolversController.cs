using MathNet.Numerics.LinearAlgebra;
using MatrixOnlineCalculator.Models.EquationsSystemsSolvers;
using MatrixOnlineCalculator.ViewModels.EquationsSystemsSolvers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace MatrixOnlineCalculator.Controllers
{
    public class EquationsSystemsSolversController : Controller
    {
        private IStringLocalizer<DeterminantCalculationController> localizer;

        public EquationsSystemsSolversController(
            IStringLocalizer<DeterminantCalculationController> localizer)
        {
            this.localizer = localizer;
        }

        public IActionResult GaussianElimination()
        {
            var viewModel = new EquationsSystemsSolverFormViewModel()
            {
                MethodName = localizer["метод Гаусса"],
                ActionName = "GaussianEliminationResult",
                MinVariablesNumber = 2,
                MaxVariablesNumber = 7,
                DefaultVariablesNumber = 3,
                MinEquationsNumber = 2,
                MaxEquationsNumber = 7,
                DefaultEquationsNumber = 3
            };

            return View("EquationsSystemsSolverForm", viewModel);
        }

        public IActionResult GaussianEliminationResult(
            int equationsNumber, 
            int variablesNumber, 
            double[] a, 
            double[] b)
        {
            var aMatrix = Matrix<double>.Build.DenseOfRowMajor(
                equationsNumber, 
                variablesNumber, 
                a);
            var bMatrix = Matrix<double>.Build.DenseOfRowMajor(
                equationsNumber, 
                1,
                b);
            
            var solution = new EquationsSystemsSolverByGaussianElimination(
                aMatrix, 
                bMatrix);

            var viewModel = new EquationsSystemsSolverResultViewModel()
            {
                MethodName = localizer["метод Гаусса"],
                DetailedSolution = solution,
                DetailedSolutionViewName = "_GaussianEliminationDetailedSolution"
            };

            return View("EquationsSystemsSolverResult", viewModel);
        }

        public IActionResult CramerRule()
        {
            var viewModel = new SquareEquationsSystemsSolverFormViewModel()
            {
                MethodName = localizer["метод Крамера"],
                ActionName = "CramerRuleResult",
                MinVariablesNumber = 2,
                MaxVariablesNumber = 7,
                DefaultVariablesNumber = 3
            };

            return View("SquareEquationsSystemsSolverForm", viewModel);
        }

        public IActionResult CramerRuleResult(
            int variablesNumber,
            double[] a,
            double[] b)
        {
            var aMatrix = Matrix<double>.Build.DenseOfRowMajor(
                variablesNumber, 
                variablesNumber, 
                a);
            var bMatrix = Matrix<double>.Build.DenseOfRowMajor(
                variablesNumber, 
                1, 
                b);
            
            var solution = new EquationsSystemsSolverByCramerRule(
                aMatrix, 
                bMatrix);

            var viewModel = new EquationsSystemsSolverResultViewModel()
            {
                MethodName = localizer["метод Крамера"],
                DetailedSolution = solution,
                DetailedSolutionViewName = "_CramerRuleDetailedSolution"
            };

            return View("EquationsSystemsSolverResult", viewModel);
        }
    }
}
