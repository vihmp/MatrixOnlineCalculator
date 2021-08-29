using System;

namespace MatrixOnlineCalculator.Models
{
    public class MathUtils
    {
        public const double Epsilon = 0.0000001;

        public static bool AreEqual(double a, double b, double epsilon)
        {
            return Math.Abs(a - b) < epsilon;
        }
    }
}
