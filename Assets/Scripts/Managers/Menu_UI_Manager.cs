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
        ShowSavedGamesData();
        ShowTotalPoints();
        ShowStatistics();
        AudioManager.Instance.PlayMusic(AudioManager.Instance.MenuMusic);
    }

    void ShowSavedGamesData()
    {
        for (int i = 0; i < Data_Manager.Instance.SavedData.Count; i++)
        {
            GameObject ShowedData = Instantiate(_uiSavedGamesPrefab, _gamesSavedContainerTransform.position, Quaternion.identity, _gamesSavedContainerTransform);

            ShowedData.GetComponent<GameDataPrefabController>()._idText.text = $"ID: {Data_Manager.Instance.SavedData[i]._id}";
            ShowedData.GetComponent<GameDataPrefabController>()._multiText.text = $"Multi: x{Data_Manager.Instance.SavedData[i]._multi}";
            ShowedData.GetComponent<GameDataPrefabController>()._pointsText.text = $"Points: {Data_Manager.Instance.SavedData[i]._points}";

        }
    }

    void ShowTotalPoints()
    {
        for (int i = 0; i < Data_Manager.Instance.SavedData.Count; i++)
        {
            _totalPoints += Data_Manager.Instance.SavedData[i]._points;
        }

        _totalPointsText.text = $"Total Points Earned: {_totalPoints}";
    }

    void ShowStatistics()
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

    void ShowAverage()
    {
        _average = (_totalPoints / Data_Manager.Instance.SavedData.Count);

        _averageObtainedText.text = $"Average  Obtained: {_average}";
    }

    void ShowMaxPoints()
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

    void ShowMinPoints()
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

    void ShowMoreThan50PointsPrcent()
    {
        _moreTha50PrcentText.text = $"Percentage of doing more than 50: {PrcetOfDoingXOrMorePoints(50).ToString("F0")}%";
    }
    void ShowMoreThan100PointsPrcent()
    {
        _moreThan100PrcentText.text = $"Percentage of doing more than 100: {PrcetOfDoingXOrMorePoints(100).ToString("F0")}%";
    }
    void ShowMoreThan1000PointsPrcent()
    {
        _moreThan1000PrcentText.text = $"Percentage of doing more than 1000: {PrcetOfDoingXOrMorePoints(1000).ToString("F0")}%";
    }


    float PrcetOfDoingXOrMorePoints(int value)
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
