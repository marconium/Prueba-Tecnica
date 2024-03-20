using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_UI_Manager : MonoBehaviour
{
    [SerializeField] Transform _gamesSavedContainerTransform;
    [SerializeField] GameObject _uiSavedGamesPrefab;




    void ShowSavedGamesData()
    {
        for (int i = 0; i < Data_Manager.Instance.SavedData.Count; i++)
        {
            GameObject ShowedData = Instantiate(_uiSavedGamesPrefab, _gamesSavedContainerTransform);

            
        }
    }

}
