using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : Singleton<UI_Manager>
{
    [Header("Lives References")]

    [SerializeField] GameObject _livesContainer;

    [Header("Lives Array")]

    [SerializeField] GameObject[] _lives;

    private void Awake()
    {
        ActivateLives();// Se activan las primeras vidas
    }

    void ActivateLives()// Se activan las vidas acorde con la vida maxima que tengas
    {
        for (int i = 0; i < GameController.Instance.MaxLives; i++)// Se pasa un for por el maximo de vidas que tengas
        {
            _lives[i].SetActive(true);// Se activan
        }
    }

    public void AddLiveUI()// Metodo que añade vida a la UI
    {
        for (int i = 0; i < GameController.Instance.CurrentLives; i++)// Se pasa un for por las current lives que tengas
        {
            if(_lives[i].gameObject.activeSelf == false)// Si esta descativada 
            {
                _lives[i].SetActive(true);// Se activa
            }           
        }
    }
    public void SubstractLiveUI()// Metodo que quita vida de la UI
    {
        for (int i = 0; i < GameController.Instance.MaxLives; i++)// Se pasa un for con las vidas maximas
        {
            if (i >= GameController.Instance.CurrentLives)// Si i es superior o igual a las current lives 
            {
                _lives[i].SetActive(false);// Se desactiva
            }
        }
    }
}
