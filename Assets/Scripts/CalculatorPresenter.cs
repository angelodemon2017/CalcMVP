using Calc.Domain;
using System.Collections.Generic;

public class CalculatorPresenter : ICalculatorPresenter
{
    private readonly ICalculatorView _view;
    private readonly ICalculatorService _calculatorService;
    private readonly ICalculationRepository _calculationRepository;

    public CalculatorPresenter(ICalculatorView view, ICalculatorService calculatorService, ICalculationRepository calculationRepository)
    {
        _view = view;
        _calculatorService = calculatorService;
        _calculationRepository = calculationRepository;
        LoadHistory();
    }

    public void PerformCalculation()
    {
        string input = _view.InputExpression;
        _view.InputExpression = string.Empty;
        int operand1, operand2;
        Operation operation;
        bool isError = false;
        double result = 0;

        if (!TryParseInput(input, out operand1, out operand2, out operation))
        {
            isError = true;
        }

        if (!isError)
        {
            result = _calculatorService.PerformCalculation(operand1, operand2, operation);
        }

        if (double.IsNaN(result))
        {
            isError = true;
        }

        string logResult;
        if (isError)
            logResult = $"{input}=ERROR";
        else
            logResult = $"{input}={result}";

        _calculationRepository.SaveResult(logResult);
        LoadHistory();
    }

    public void ChangeInput()
    {
        _calculationRepository.ChangeInputField(_view.InputExpression);
    }

    public void LoadHistory()
    {
        List<string> history = _calculationRepository.GetHistory();
        var asd = _calculationRepository.GetInput();
        _view.InputExpression = _calculationRepository.GetInput();
        _view.UpdateHistory(history);
    }

    private bool TryParseInput(string input, out int operand1, out int operand2, out Operation operation)
    {
        operand1 = 0;
        operand2 = 0;
        operation = Operation.Addition;

        input += '+';

        string[] parts = input.Split('+');

        if (parts.Length > 3)
        {
            return false;
        }

        if (!int.TryParse(parts[0], out operand1) || !int.TryParse(parts[1], out operand2))
        {
            return false;
        }

        return true;
    }
}