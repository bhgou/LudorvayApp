using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneLeverAnimationScript : MonoBehaviour
{

     public GameObject LoadingText;
     public GameObject ImageBack;

     public Color colorAlpha;

     [SerializeField]private float Timer = 100;
    void Start()
    {
        StartCoroutine(Mapka());
        UnityEngine.Debug.Log("sintransition");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator Mapka()
    {
        yield return new WaitForSecondsRealtime(0.5f);
        LoadingText.SetActive(false);
        while (true)
        {
            yield return new WaitForEndOfFrame();
            colorAlpha.a -= 0.000235294f*16;  
            ImageBack.GetComponent<Image>().color = colorAlpha;
        }
    }
}
