using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Menu_UI_Manager : MonoBehaviour
{
    [Header("References")]

    [SerializeField] Transform _gamesSavedContainerTransform;
    [SerializeField] GameObject _uiSavedGamesPrefab;
    [SerializeField] TextMeshProUGUI _totalPointsText;

    [Header("Statistics Text References")]

    [SerializeField] TextMeshProUGUI _averageObtainedText;
    [SerializeField] TextMeshProUGUI _maxObtainedText;
    [SerializeField] TextMeshProUGUI _minObtainedText;
    [SerializeField] TextMeshProUGUI _moreTha50PrcentText;
    [SerializeField] TextMeshProUGUI _moreThan100PrcentText;
    [SerializeField] TextMeshProUGUI _moreThan1000PrcentText;


    [Header("Total Points Variables")]

    [SerializeField] int _totalPoints;

    [Header("Statistics Variables")]

    [SerializeField] int _average;
    [SerializeField] int _maxPoints;
    [SerializeField] int _minPoints;

    private void Start()
    {
        ShowSavedGamesData();// se mustran las partidas guardadas
        ShowTotalPoints();// se mustran los puntos totales
        ShowStatistics();// se muestran las estadisticas
        AudioManager.Instance.PlayMusic(AudioManager.Instance.MenuMusic);// se inicia la musica del menu
    }

    void ShowSavedGamesData()// metodo que accede al listado de guardados y los muestra en pantalla
    {
        for (int i = 0; i < Data_Manager.Instance.SavedData.Count; i++)
        {
            GameObject ShowedData = Instantiate(_uiSavedGamesPrefab, _gamesSavedContainerTransform.position, Quaternion.identity, _gamesSavedContainerTransform);

            ShowedData.GetComponent<GameDataPrefabController>()._idText.text = $"ID: {Data_Manager.Instance.SavedData[i]._id}";
            ShowedData.GetComponent<GameDataPrefabController>()._multiText.text = $"Multi: x{Data_Manager.Instance.SavedData[i]._multi}";
            ShowedData.GetComponent<GameDataPrefabController>()._pointsText.text = $"Points: {Data_Manager.Instance.SavedData[i]._points}";

        }
    }

    void ShowTotalPoints()// metodo que muestra la puntuación total
    {
        for (int i = 0; i < Data_Manager.Instance.SavedData.Count; i++)
        {
            _totalPoints += Data_Manager.Instance.SavedData[i]._points;
        }

        _totalPointsText.text = $"Total Points Earned: {_totalPoints}";
    }

    void ShowStatistics()// metodo que muestra todas las estadisticas, si hay alguna partida guardada
    {
        if (Data_Manager.Instance.SavedData.Count >= 1)
        {
            ShowAverage();
            ShowMaxPoints();
            ShowMinPoints();
            ShowMoreThan50PointsPrcent();
            ShowMoreThan100PointsPrcent();
            ShowMoreThan1000PointsPrcent();
        }

    }

    void ShowAverage()// metodo que muestra la media de puntos
    {
        _average = (_totalPoints / Data_Manager.Instance.SavedData.Count);

        _averageObtainedText.text = $"Average  Obtained: {_average}";
    }

    void ShowMaxPoints()// metodo que muestra los puntos maximos realizados en una partida
    {
        for (int i = 0; i < Data_Manager.Instance.SavedData.Count; i++)
        {
            int max = Data_Manager.Instance.SavedData[i]._points;

            if (max > _maxPoints)
            {
                _maxPoints = max;
            }
        }

        _maxObtainedText.text = $"Max Obtained: {_maxPoints}";
    }

    void ShowMinPoints()// metodo que muestra los puntos minimos realizados en una partida
    {
        _minPoints = 20000;
        for (int i = 0; i < Data_Manager.Instance.SavedData.Count; i++)
        {
            int Min = Data_Manager.Instance.SavedData[i]._points;

            if (Min < _minPoints)
            {
                _minPoints = Min;
            }
        }

        _minObtainedText.text = $"Min Obtained: {_minPoints}";
    }

    void ShowMoreThan50PointsPrcent()// metodo que muestra el porcentage de hacer x numero de puntos 
    {
        _moreTha50PrcentText.text = $"Percentage of doing more than 50: {PrcetOfDoingXOrMorePoints(50).ToString("F0")}%";
    }
    void ShowMoreThan100PointsPrcent()// metodo que muestra el porcentage de hacer x numero de puntos 
    {
        _moreThan100PrcentText.text = $"Percentage of doing more than 100: {PrcetOfDoingXOrMorePoints(100).ToString("F0")}%";
    }
    void ShowMoreThan1000PointsPrcent()// metodo que muestra el porcentage de hacer x numero de puntos 
    {
        _moreThan1000PrcentText.text = $"Percentage of doing more than 1000: {PrcetOfDoingXOrMorePoints(1000).ToString("F0")}%";
    }


    float PrcetOfDoingXOrMorePoints(int value)// metodo que muestra el porcentage de hacer x numero de puntos 
    {

        int valueDoneCount = 0;
        for (int i = 0; i < Data_Manager.Instance.SavedData.Count; i++)
        {
            if (Data_Manager.Instance.SavedData[i]._points >= value)
            {
                valueDoneCount++;
            }
        }
      
       float prcent = (float)(valueDoneCount / (float)Data_Manager.Instance.SavedData.Count) * 100;

        return prcent;
    }


}
