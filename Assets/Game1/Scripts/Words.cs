using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Words : MonoBehaviour
{
    public TextMeshProUGUI Instructions;
    [SerializeField] private string[] InstructionsText = new string[]{"",""};

    public TextMeshProUGUI FallMenu;

    [SerializeField] private string[] FallMenuText = new string[]{"",""};
    void Start()
    {
        Instructions.text = InstructionsText[PlayerPrefs.GetInt("Language")];
        FallMenu.text = FallMenuText[PlayerPrefs.GetInt("Language")];
    }
    void Update()
    {
        
    }
}
