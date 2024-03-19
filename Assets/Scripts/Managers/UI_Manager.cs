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

    [Header("Rumble Variables")]

    [SerializeField] Transform _currentTransform;
    [SerializeField] Vector2 _initPos;
    [SerializeField] bool _isRumble;
    private void Awake()
    {
        ActivateUI();// Se activa la UI
    }


    private void Update()
    {
        if (_isRumble)
        {
            Rumble(_currentTransform);
        }      
    }

    void ActivateUI()
    {
        ActivateLives();
        UpdatePointsUI();
        UpdateMultiplierUI();
    }



    public void PointsShakeUI(int value)
    {
        StartCoroutine(PointsShake(value));
    }

    public void MultiShakeUI(int value)
    {
        StartCoroutine(MultiShake(value));
    }

    IEnumerator MultiShake(int value)
    {
        if (value == 1)
        {
            _multipierText.color = Color.green;
        }
        else if (value == -1)
        {
            _multipierText.color = Color.red;
        }

        _initPos = _multipierText.transform.position;
        _currentTransform = _multipierText.transform;
        _isRumble = true;

        yield return new WaitForSeconds(0.2f);

        _isRumble = false;
        _multipierText.color = Color.white;
        _currentTransform.position = _initPos;
        _currentTransform = null;
    }



    IEnumerator PointsShake(int value)
    {
        if (value == 1)
        {
            _pointsText.color = Color.green;
        }
        else if (value == -1)
        {
            _pointsText.color = Color.red;
        }

        _initPos = _pointsText.transform.position;
        _currentTransform = _pointsText.transform;
        _isRumble = true;

        yield return new WaitForSeconds(0.2f);

        _isRumble = false;
        _pointsText.color = Color.white;
        _currentTransform.position = _initPos;
        _currentTransform = null;

    }

    void Rumble(Transform transform)
    {
        transform.position = new Vector2(Random.Range(_initPos.x - 0.1f, _initPos.x + 0.1f), Random.Range(_initPos.y - 0.1f, _initPos.y + 0.1f));
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
            if (_lives[i].gameObject.activeSelf == false)// Si esta descativada 
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
