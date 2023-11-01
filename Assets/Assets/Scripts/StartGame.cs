using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public void WaveGame()
    {
        SceneManager.LoadScene(2);
    }

    public void Puzzle()
    {
        SceneManager.LoadScene(3);
    }
}
