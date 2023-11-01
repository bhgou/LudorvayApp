using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TutorialController : MonoBehaviour
{
    //public GameObject strela;
    public GameObject Panel;

    private TextMeshProUGUI text;
    private Tutor tutu;
    private ButtonController BC;
    private GameObject Pl;
    private int ind = 0;
    void Start()
    {
        text = Panel.transform.GetChild(0).GetComponent<TextMeshProUGUI>();

        Panel.SetActive(false);
        //strela.SetActive(false);

        BC = GameObject.FindGameObjectWithTag("ButtonController").GetComponent<ButtonController>();
        Pl = GameObject.FindGameObjectWithTag("Player");
        tutu = GameObject.FindGameObjectWithTag("Player").GetComponent<Tutor>();
    }

    // Update is called once per frame
    void Update()
    {
        if(ind <5)
        {
            if (Input.touchCount > 0) 
            {
                Touch touch = Input.GetTouch(0);
                if (touch.phase == TouchPhase.Began && ind!=3)
                {
                    StartCoroutine(Func(ind));
                }
            }

            if(ind== 3 && Pl.transform.position.y >=8)
            {
                StartCoroutine(Func(ind));
            }
        }
        
    }

    IEnumerator Func(int x)
    {
        if(x == 0)
        {
            text.text = "Приветствую в приложении 'Народная волна'. Нажмите для продолжения.";
            Panel.SetActive(true);
            ind+=1;
        }

        if(x == 1)
        {
            text.text = "Шар двигается по хз чему. Нажмите для продолжения";
            tutu.block = true;
            Time.timeScale = 1;
            ind+=1;
        }

        if(x == 2)
        {
            text.text = "При нажатии на экран шар начинает движение";
            tutu.block = false;
            ind+=1;
        }

        if(x == 3)
        {
            Time.timeScale = 0;
            SoundManager.instance.musicSource.Pause();
            text.text = "что-то написанно ";
            ind+=1;
        }

        if(x == 4)
        {
            ind+=1;
            BC.PausedPlay();
            text.text = "Обходите препядствия и собирайте слова";
            yield return new WaitForSecondsRealtime(3);
            Panel.SetActive(false);
            
        }
    }
}
