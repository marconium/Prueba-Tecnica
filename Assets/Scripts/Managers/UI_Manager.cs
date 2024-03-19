using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Manager : Singleton<UI_Manager>
{
    [Header("Lives References")]

    [SerializeField] GameObject _livesContainer;

    [Header("Lives Array")]

    [SerializeField] GameObject[] _lives;


    [Header("Text References")]

    [SerializeField] TextMeshProUGUI _pointsText;
    [SerializeField] TextMeshProUGUI _multipierText;

    private void Awake()
    {
        ActivateUI();// Se activa la UI
    }


    void ActivateUI()
    {
        ActivateLives();
        UpdatePointsUI();
        UpdateMultiplierUI();
    }

    public void UpdatePointsUI()// Se actualizan los puntos mostrados en pantalla
    {
        _pointsText.text = $"Points: {(int)GameController.Instance.CurrentPoints}";
    }

    public void UpdateMultiplierUI()// Se actualiza el multiplicador mostrado en pantalla
    {
        _multipierText.text = $"Multi: x{GameController.Instance.CurrentPointsMultiplier}";
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
