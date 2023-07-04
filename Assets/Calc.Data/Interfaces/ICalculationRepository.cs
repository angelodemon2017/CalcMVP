using System.Collections.Generic;

public interface ICalculationRepository
{
    void ChangeInputField(string input);
    void SaveResult(string result);
    List<string> GetHistory();
    string GetInput();
}