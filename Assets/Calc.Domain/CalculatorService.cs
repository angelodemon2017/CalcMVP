using System;

namespace Calc.Domain
{

    public class CalculatorService : ICalculatorService
    {
        public double PerformCalculation(double operand1, double operand2, Operation operation)
        {
            if (operation != Operation.Addition || !IsValidNumber(operand1) || !IsValidNumber(operand2))
            {
                return double.NaN;
            }

            return operand1 + operand2;
        }

        private bool IsValidNumber(double number)
        {
            return Math.Abs(number - Math.Floor(number)) < double.Epsilon && number >= 0;
        }
    }
}