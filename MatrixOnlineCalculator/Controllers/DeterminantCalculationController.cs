using MathNet.Numerics.LinearAlgebra;
using MatrixOnlineCalculator.Models.DeterminantCalculation;
using MatrixOnlineCalculator.ViewModels.DeterminantCalculation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace MatrixOnlineCalculator.Controllers
{
    public class DeterminantCalculationController : Controller
    {
        private IStringLocalizer<DeterminantCalculationController> localizer;

        public DeterminantCalculationController(
            IStringLocalizer<DeterminantCalculationController> localizer)
        {
            this.localizer = localizer;
        }

        public IActionResult LaplaceExpansion()
        {
            var viewModel = new DeterminantCalculationFormViewModel()
            {
                MethodName = localizer["теорема Лапласа"],
                ActionName = "LaplaceExpansionResult",
                MinMatrixSize = 2,
                MaxMatrixSize = 5,
                DefaultMatrixSize = 3
            };

            return View("DeterminantCalculationForm", viewModel);
        }

        public IActionResult LaplaceExpansionResult(int matrixSize, double[] matrixData)
        {
            var matrix = Matrix<double>.Build.DenseOfRowMajor(
                matrixSize, 
                matrixSize, 
                matrixData);

            var solution = new LaplaceExpansion(matrix);

            var viewModel = new DeterminantCalculationResultViewModel()
            {
                MethodName = localizer["теорема Лапласа"],
                DetailedSolution = solution,
                DetailedSolutionViewName = "_LaplaceExpansionDetailedSolution"
            };

            return View("DeterminantCalculationResult", viewModel);
        }

        public IActionResult GaussianElimination()
        {
            var viewModel = new DeterminantCalculationFormViewModel()
            {
                MethodName = localizer["метод Гаусса"],
                ActionName = "GaussianEliminationResult",
                MinMatrixSize = 2,
                MaxMatrixSize = 10,
                DefaultMatrixSize = 3
            };

            return View("DeterminantCalculationForm", viewModel);
        }

        public IActionResult GaussianEliminationResult(int matrixSize, double[] matrixData)
        {
            var matrix = Matrix<double>.Build.DenseOfRowMajor(
                matrixSize, 
                matrixSize, 
                matrixData);

            var solution = new DeterminantByGaussianElimination(matrix);

            var viewModel = new DeterminantCalculationResultViewModel()
            {
                MethodName = localizer["метод Гаусса"],
                DetailedSolution = solution,
                DetailedSolutionViewName = "_GaussianEliminationDetailedSolution"
            };

            return View("DeterminantCalculationResult", viewModel);
        }
    }
}
