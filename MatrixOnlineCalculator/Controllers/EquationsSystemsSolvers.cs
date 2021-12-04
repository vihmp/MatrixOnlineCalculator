using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MatrixOnlineCalculator.Controllers
{
    public class EquationsSystemsSolvers : Controller
    {
        public IActionResult GaussianElimination()
        {
            return View();
        }

        public IActionResult GaussianEliminationResult(
            int rowsNumber, 
            int columnsNumber, 
            double[] a, 
            double[] b)
        {
            return View();
        }
    }
}
