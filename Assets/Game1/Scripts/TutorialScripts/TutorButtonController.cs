using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class TutorButtonController : MonoBehaviour
{
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void FadeToLevel()
    {
        anim.SetTrigger("fade");
    }


    
    public SoundManager SoundManager;

    public Tutor Pl;

    public GameObject SentencingPanel;

    public void Language()
    {
        PlayerPrefs.SetInt("Language", 0);
    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Home()
    {
        //SinTransitionScript.SelectToScreen(0);
        Time.timeScale = 1;
        SceneManager.LoadScene("Menu");
    }

    public void Instructions()
    {
        Time.timeScale = 1;
        SoundManager.instance.musicSource.Play();
    }

    public void Paused()
    {
        StartCoroutine(Pause());
    }
    IEnumerator Pause()
    {

        Pl.GamePausedWord.text = Pl.Slovo;
        yield return new WaitForSeconds(0.1f);
        Time.timeScale = 0;
        SoundManager.instance.musicSource.Pause();
        yield break;
    }

    public void PausedPlay()
    {
        StartCoroutine(PausPlay());
    }

    IEnumerator PausPlay()
    {
        for(int i = 0; i<3; i++)
        {
            SentencingPanel.SetActive(true);
            SentencingPanel.GetComponent<TextMeshProUGUI>().text = (3-i).ToString();
            yield return new WaitForSecondsRealtime(1);
        }
        Time.timeScale = 1;
        SoundManager.instance.musicSource.Play();
        SentencingPanel.SetActive(false);
    }
}
