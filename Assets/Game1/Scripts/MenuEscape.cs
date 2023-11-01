using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuEscape : MonoBehaviour
{
    public PanelAnimator[] Pan = new PanelAnimator[0];
    
    private void Update() 
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            for(int i = 1; i<Pan.Length;i++)
            {
                if(Pan[i].GetComponent<PanelAnimator>()._animate == true)
                {
                    StartCoroutine(menus(i));
                    break;
                }
            }
            if(Pan[0].GetComponent<PanelAnimator>()._animate == true)
            {
                Application.Quit();
            }
        }
    }
    IEnumerator menus(int i)
    {
        Pan[i].GetComponent<PanelAnimator>().StartAnimOut();
        Pan[0].GetComponent<PanelAnimator>().StartAnimIn();
        yield return null;
    }
}
