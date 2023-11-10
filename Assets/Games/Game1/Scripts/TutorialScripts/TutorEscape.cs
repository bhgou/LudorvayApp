using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class TutorEscape : MonoBehaviour
{
    private ButtonController BC;

    public GameObject[] Panels = new GameObject[0];

    void Start()
    {
        BC = GameObject.FindGameObjectWithTag("ButtonController").GetComponent<ButtonController>();
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(Panels[0].activeSelf == true || Panels[1].activeSelf == true || Panels[1].activeSelf == true)
            {
                BC.Home();
            }
            else
            {
                Panels[0].SetActive(true);
                BC.Paused();
                Panels[3].SetActive(false);
            }
            
        }
    }
}
