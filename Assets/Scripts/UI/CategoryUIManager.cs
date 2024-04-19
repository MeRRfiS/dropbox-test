using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CategoryUIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _buttonText;

    public string Category { get; private set; }

    public void SetUpButton(string category)
    {
        Category = category;
        _buttonText.text = category;
    }
}
