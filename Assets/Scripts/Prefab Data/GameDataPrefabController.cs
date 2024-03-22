using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameDataPrefabController : MonoBehaviour
{
    // Estos son los campos de texto que muestran los puntos, multi y id del prefab de cada partida
    [SerializeField] public TextMeshProUGUI _idText;
    [SerializeField] public TextMeshProUGUI _multiText;
    [SerializeField] public TextMeshProUGUI _pointsText;
}
