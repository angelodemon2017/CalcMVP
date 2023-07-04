using UnityEngine;
using Calc.Data;
using Calc.Domain;

public class Startup : MonoBehaviour
{
    public ViewCalc viewCalc;

    CalculationRepository calculationRepository = new CalculationRepository();
    CalculatorService calculatorService = new CalculatorService();
    CalculatorPresenter calculatorPresenter;

    void Awake()
    {
        calculatorPresenter = new CalculatorPresenter(viewCalc, calculatorService, calculationRepository);
        viewCalc.ActionResult += calculatorPresenter.PerformCalculation;
        viewCalc.ActionEditing += calculatorPresenter.ChangeInput;
    }
}