using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Manager : Singleton<Scene_Manager>
{

    public void QuitAplication()//metodo que sirve para cerrar la applicación
    {
        Application.Quit();
    }
    public void LoadScene(int value)// metodo para cambiar de escena, tambien activa el tiempo
    {
        SceneManager.LoadScene(value);
        Time.timeScale = 1;
    }

   
}
