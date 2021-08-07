using Microsoft.AspNetCore.Mvc;
using MatrixOnlineCalculator.Models;
using MathNet.Numerics.LinearAlgebra;

namespace MatrixOnlineCalculator.Controllers
{
    public class MatrixCalculatorController : Controller
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