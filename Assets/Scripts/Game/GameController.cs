using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Singleton<GameController>
{
    public float CurrentPoints { get => _currentPoints; set => _currentPoints = value; }
    public float CurrentPointsMultiplier { get => _currentPointsMultiplier; set => _currentPointsMultiplier = value; }
    public int MaxLives { get => _maxLives; set => _maxLives = value; }
    public int CurrentLives { get => _currentLives; set => _currentLives = value; }
    public bool IsDead { get => isDead; set => isDead = value; }
    public bool CanOpenMenu { get => _canOpenMenu; set => _canOpenMenu = value; }

    [Header("Lives Variables")]

    [SerializeField] int _maxLives;
    [SerializeField] int _currentLives;

    [Header("Ponts Variables")]

    [SerializeField] float _maxPoints;
    [SerializeField] float _currentPoints;
    [SerializeField] float _currentPointsMultiplier = 1;

    [Header("Controll Variables")]

    [SerializeField] bool isDead;
    [SerializeField] bool _canOpenMenu;

    private void Start()
    {
        AudioManager.Instance.PlayMusic(AudioManager.Instance.GameMusic);
        _currentLives = _maxLives;
        _canOpenMenu = true;
    }


    public void SubstractLife(int value)// Metodo para restar vida
    {
        if (_currentLives >= 1)
        {
            _currentLives -= value;// Se resta la vida deseada
            UI_Manager.Instance.SubstractLiveUI();// Se cambia en la UI
        }
        if (_currentLives <= 0)// si las vidas son menor o igual a 0
        {
            if (!isDead)
            {
                EndGame();// Se llama al metodo que acaba el juego
            }
        }
        //Mathf.Clamp(_currentLives, 0, Mathf.Infinity);// se realiza un Clamp para evitar que la vida sea menor que zero
    }
    public void AddLife(int value)// Funcion para a�adir vida
    {
        if (!isDead)// Si no esta muerto
        {
            if (_currentLives < _maxLives)// mientras tengas menos vidas que max lives
            {
                _currentLives += value;// se a�ade vida
                UI_Manager.Instance.AddLiveUI();// Se cambia en la UI
            }
        }
    }
    public void AddMaxLife(int value)// Funcion para a�adir vida maxima
    {
        if (!isDead)// Si no esta muerto
        {
            if (_maxLives + value <= 10)// si la suma del valor a las vidas maximas da menor o igual a 10 
            {
                _maxLives += value;// se suma el valor
            }
        }
    }

    void EndGame()// metodo de finalizaci�n del juego
    {
        isDead = true;
        _canOpenMenu = false;

        StartCoroutine(UI_Manager.Instance.FinalGame());

        SaveData data = new SaveData(Data_Manager.Instance.SavedData.Count + 1, (int)_currentPoints, (int)_currentPointsMultiplier);// se crea la variable que se guardara

        Data_Manager.Instance.AddNewSave(data);// se guardan los datos del Game

        Data_Manager.Instance.SaveData();// se lee el Json para que se pueda exponer en la UI del menu

        Debug.Log("Eliminado");
    }
}
