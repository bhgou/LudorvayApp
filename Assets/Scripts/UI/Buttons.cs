using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
   public void Scene(int id)
    {
        SceneManager.LoadScene(id);
    }
}
