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

    [Header("Total Points Variables")]

    [SerializeField] int _totalPoints;

    private void Start()
    {
        ShowSavedGamesData();
        ShowTotalPoints();
    }

    void ShowSavedGamesData()
    {
        for (int i = 0; i < Data_Manager.Instance.SavedData.Count; i++)
        {
            GameObject ShowedData = Instantiate(_uiSavedGamesPrefab,_gamesSavedContainerTransform.position,Quaternion.identity, _gamesSavedContainerTransform);

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

}
