using MathNet.Numerics.LinearAlgebra;
using MatrixOnlineCalculator.Models.EquationsSystemsSolvers;
using Microsoft.AspNetCore.Mvc;

namespace MatrixOnlineCalculator.Controllers
{
    public class EquationsSystemsSolversController : Controller
    {
        public IActionResult GaussianElimination()
        {
            return View();
        }

        public IActionResult GaussianEliminationResult(
            int equationsNumber, 
            int variablesNumber, 
            double[] a, 
            double[] b)
        {
            var aMatrix = 
                Matrix<double>.Build.DenseOfRowMajor(equationsNumber, variablesNumber, a);
            var bMatrix =
                Matrix<double>.Build.DenseOfRowMajor(equationsNumber, 1, b);
            var equationSystemSolver = 
                new EquationsSystemSolverByGaussianElimination(aMatrix, bMatrix);

            return View(equationSystemSolver);
        }

        public IActionResult CramerRule()
        {
            return View();
        }

        public IActionResult CramerRuleResult(
            int variablesNumber,
            double[] a,
            double[] b)
        {
            var aMatrix =
                Matrix<double>.Build.DenseOfRowMajor(variablesNumber, variablesNumber, a);
            var bMatrix =
                Matrix<double>.Build.DenseOfRowMajor(variablesNumber, 1, b);
            var equationSystemSolver =
                new EquationsSystemSolverByCramerRule(aMatrix, bMatrix);

            return View(equationSystemSolver);
        }
    }
}
