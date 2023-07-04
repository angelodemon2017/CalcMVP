using System.Collections.Generic;

public interface ICalculatorView
{
    string InputExpression { get; set; }
    void UpdateHistory(List<string> history);
}