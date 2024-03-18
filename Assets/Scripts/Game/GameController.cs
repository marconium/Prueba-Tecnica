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

    
}
