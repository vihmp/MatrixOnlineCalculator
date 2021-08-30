using MathNet.Numerics.LinearAlgebra;
using MatrixOnlineCalculator.Models;
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
            var dct = new LaplaceExpansion(
                Matrix<double>.Build.DenseOfRowMajor(matrixSize, matrixSize, matrixData));

            return View(dct);
        }
    }
}
