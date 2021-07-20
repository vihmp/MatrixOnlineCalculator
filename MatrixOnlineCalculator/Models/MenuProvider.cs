using System.Collections.Generic;

namespace MatrixOnlineCalculator.Models
{
    public class MenuProvider
    {
        private static Dictionary<(string Controller, string Action), string> calculators =
            new Dictionary<(string Controller, string Action), string>()
            {
                [("MatrixCalculator", "CalculateDeterminant")] = "Вычисление определителя матрицы"
            };

        public static Dictionary<(string Controller, string Action), string> GetCalculators()
        {
            return calculators;
        }

        public static string GetCalculatorName(string controller, string action)
        {
            return calculators[(controller, action)];
        }
    }
}
