using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorMenu : MonoBehaviour
{
    void Start()
    {
        if(!PlayerPrefs.HasKey("Tutor"))
        {
            PlayerPrefs.SetInt("Tutor", 0);
            SinTransitionScript.SelectToScreen(2);
            TutorStart();
        }
    }

    public void TutorStart()
    {
        PlayerPrefs.SetInt("Tutor", 0);
        SinTransitionScript.SelectToScreen(2);
    }
}
