using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : Singleton<GameController>
{
    public float CurrentPoints { get => _currentPoints; set => _currentPoints = value; }
    public float CurrentPointsMultiplier { get => _currentPointsMultiplier; set => _currentPointsMultiplier = value; }

    [Header("Lives Variables")]

    [SerializeField] int _maxLives;
    [SerializeField] int _currentLives;

    [Header("Ponts Variables")]

    [SerializeField] float _maxPoints;
    [SerializeField] float _currentPoints;
    [SerializeField] float _currentPointsMultiplier = 1;



    private void Start()
    {
        _currentLives = _maxLives;
    }



    public void SubstractLife(int value)// Metodo para restar vida
    {
        if (_currentLives >= 1)
        {
            _currentLives -= value;// Se resta la vida deseada
        }
        if(_currentLives <= 0)
        {
            EndGame();
        }
        //Mathf.Clamp(_currentLives, 0, Mathf.Infinity);// se realiza un Clamp para evitar que la vida sea menor que zero
    }



    void EndGame()
    {
        Debug.Log("Eliminado");
    }
}
