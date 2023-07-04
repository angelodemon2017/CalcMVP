namespace Calc.Domain
{
    public interface ICalculatorService
    {
        double PerformCalculation(double operand1, double operand2, Operation operation);
    }
}