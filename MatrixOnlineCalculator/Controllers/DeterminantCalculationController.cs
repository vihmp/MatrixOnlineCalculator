using MathNet.Numerics.LinearAlgebra;
using MatrixOnlineCalculator.Models.DeterminantCalculation;
using Microsoft.AspNetCore.Mvc;

namespace MatrixOnlineCalculator.Controllers
{
    public class DeterminantCalculationController : Controller
    {
        public IActionResult LaplaceExpansion()
        {
            return View();
        }

        public IActionResult LaplaceExpansionResult(int matrixSize, double[] matrixData)
        {
            var laplaceExpansion = new LaplaceExpansion(
                Matrix<double>.Build.DenseOfRowMajor(matrixSize, matrixSize, matrixData));

            return View(laplaceExpansion);
        }

        public IActionResult GaussianElimination()
        {
            return View();
        }

        public IActionResult GaussianEliminationResult(int matrixSize, double[] matrixData)
        {
            var gaussianElimination = new DeterminantByGaussianElimination(
                Matrix<double>.Build.DenseOfRowMajor(matrixSize, matrixSize, matrixData));

            return View(gaussianElimination);
        }
    }
}
