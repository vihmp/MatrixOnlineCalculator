using Microsoft.AspNetCore.Mvc;
using MatrixOnlineCalculator.Models;
using MathNet.Numerics.LinearAlgebra;

namespace MatrixOnlineCalculator.Controllers
{
    public class MatrixCalculatorController : Controller
    {
        public IActionResult CalculateDeterminant()
        {
            return View();
        }

        public IActionResult CalculateDeterminantResult(int matrixSize, double[] matrixData)
        {
            var dct = new DeterminantCalculationTree(
                Matrix<double>.Build.DenseOfRowMajor(matrixSize, matrixSize, matrixData));
            
            return View(dct);
        }
    }
}