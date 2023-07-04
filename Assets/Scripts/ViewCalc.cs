using System;
using UnityEngine;
using TMPro;
using System.Collections.Generic;
using UnityEngine.UI;

public class ViewCalc : MonoBehaviour, ICalculatorView
{
    public TextMeshProUGUI PrefabResult;
    public Transform ParentStory;
    public Action ActionResult;
    public Action ActionEditing;
    public TextMeshProUGUI TextRequest;
    public TMP_InputField inputField;
    public AspectRatioFitter aspectRatioFitter;

    string ICalculatorView.InputExpression { get => inputField.text; set => inputField.text = value; }

    public void FieldEditing()
    {
        ActionEditing?.Invoke();
    }

    public void ButtonResult()
    {
        ActionResult?.Invoke();
    }

    public void UpdateHistory(List<string> history)
    {
        foreach (Transform child in ParentStory)
        {
            Destroy(child.gameObject);
        }
        foreach (var res in history)
        {
            Instantiate(PrefabResult, ParentStory).text = res;
        }
        aspectRatioFitter.aspectRatio = history.Count > 7 ? 1f : 7f / (history.Count);
    }
}
