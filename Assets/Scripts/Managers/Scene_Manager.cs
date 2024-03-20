using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Manager : MonoBehaviour
{

    public void QuitAplication()
    {
        Application.Quit();
    }
    public void LoadScene(int value)
    {
        SceneManager.LoadScene(value);
        Time.timeScale = 1;
    }

   
}
