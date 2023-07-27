using System;

namespace MatrixCalculators.Utils
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
