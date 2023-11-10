using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameController : MonoBehaviour
{

    public TextMeshProUGUI currentScoreText;
    public TextMeshProUGUI bestScoreText;
    
    

    int currentScore;


    void Start()
    {
        currentScore = 0;
        bestScoreText.text = PlayerPrefs.GetInt("BestScore", 0).ToString();
        SetScore();
    }

    

  
    

    public void Restart()
    {
        //SinTransitionScript.SelectToScreen(1);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        SoundManager.instance.musicSource.Play();

    }

    public void AddScore()
    {
        currentScore++;
        if(currentScore > PlayerPrefs.GetInt("BestScore", 0))
        {
            PlayerPrefs.SetInt("BestScore", currentScore);
            bestScoreText.text = currentScore.ToString();
        }
        SetScore();
    }

    void SetScore()
    {
        currentScoreText.text = currentScore.ToString();
    }
}
