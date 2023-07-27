using MathNet.Numerics.LinearAlgebra;
using MatrixCalculators.DeterminantCalculators;
using MatrixOnlineCalculator.Models.Options;
using MatrixOnlineCalculator.ViewModels.DeterminantCalculation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace MatrixOnlineCalculator.Controllers
{
    public class DeterminantCalculationController : Controller
    {
        private readonly IOptions<MathFormatOptions> options;

        public DeterminantCalculationController(IOptions<MathFormatOptions> options)
        {
            this.options = options;
        }

        public IActionResult LaplaceExpansion()
        {
            var viewModel = new DeterminantCalculationFormViewModel()
            {
                MethodName = "теорема Лапласа",
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

            var solution = CalculateDeterminant.UsingLaplaceExpansion(
                matrix, 
                options.Value.DecimalPrecision);

            var viewModel = new DeterminantCalculationResultViewModel()
            {
                MethodName = "теорема Лапласа",
                DetailedSolution = solution,
                DetailedSolutionViewName = "_LaplaceExpansionDetailedSolution"
            };

            return View("DeterminantCalculationResult", viewModel);
        }

        public IActionResult GaussianElimination()
        {
            var viewModel = new DeterminantCalculationFormViewModel()
            {
                MethodName = "метод Гаусса",
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

            var solution = CalculateDeterminant.UsingGaussianElimination(
                matrix,
                options.Value.DecimalPrecision);

            var viewModel = new DeterminantCalculationResultViewModel()
            {
                MethodName = "метод Гаусса",
                DetailedSolution = solution,
                DetailedSolutionViewName = "_GaussianEliminationDetailedSolution"
            };

            return View("DeterminantCalculationResult", viewModel);
        }
    }
}
