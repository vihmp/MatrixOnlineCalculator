using MatrixOnlineCalculator.Models.Options;
using System;

namespace MatrixOnlineCalculator.Models
{
    public class MathUtils
    {
        public static bool AreEqual(double a, double b, int precision)
        {
            double delta = Math.Pow(0.1, precision);

            return Math.Abs(a - b) < delta;
        }
    }
}
