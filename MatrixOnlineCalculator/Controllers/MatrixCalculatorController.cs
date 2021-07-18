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

        public IActionResult CalculateDeterminantResult(double[][] rows)
        {
            var dct = new DeterminantCalculationTree(
                Matrix<double>.Build.DenseOfRowArrays(rows));
            
            return View(dct);
        }
    }
}