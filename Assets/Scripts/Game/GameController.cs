using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Singleton<GameController>
{
    public float CurrentPoints { get => _currentPoints; set => _currentPoints = value; }
    public float CurrentPointsMultiplier { get => _currentPointsMultiplier; set => _currentPointsMultiplier = value; }
    public int MaxLives { get => _maxLives; set => _maxLives = value; }
    public int CurrentLives { get => _currentLives; set => _currentLives = value; }

    [Header("Lives Variables")]

    [SerializeField] int _maxLives;
    [SerializeField] int _currentLives;

    [Header("Ponts Variables")]

    [SerializeField] float _maxPoints;
    [SerializeField] float _currentPoints;
    [SerializeField] float _currentPointsMultiplier = 1;

    [Header("Controll Variables")]

    [SerializeField] bool isDead;

    private void Start()
    {
        _currentLives = _maxLives;
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
            EndGame();// Se llama al metodo que acaba el juego
        }
        //Mathf.Clamp(_currentLives, 0, Mathf.Infinity);// se realiza un Clamp para evitar que la vida sea menor que zero
    }
    public void AddLife(int value)
    {
        if (!isDead)
        {
            if (_currentLives < _maxLives)
            {
                _currentLives += value;
                UI_Manager.Instance.AddLiveUI();// Se cambia en la UI
            }
        }
    }
    public void AddMaxLife(int value)
    {
        if (!isDead)
        {
            if(_maxLives + value <= 10)
            {
                _maxLives += value;
            }
        }
    }

    void EndGame()
    {
        isDead = true;
        Debug.Log("Eliminado");
    }
}
