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

    [Header("Shake Variables")]

    [SerializeField] Transform _currentTransform;
    [SerializeField] Vector2 _initPos;
    [SerializeField] bool _isShake;

    [Header("Menu Reference")]

    [SerializeField] GameObject _menuObj;

    [Header("Final Panel Reference")]

    [SerializeField] GameObject _finalPanel;

    private void Awake()
    {
        ActivateUI();// Se activa la UI
    }


    private void Update()
    {
        if (_isShake)
        {
            Shake(_currentTransform);// Se activa el Shake
        }

        if (Input.GetKeyDown(KeyCode.Escape) && GameController.Instance.CanOpenMenu)
        {
            HandleMenu();
        }
    }

    void ActivateUI()
    {
        ActivateLives();
        UpdatePointsUI();
        UpdateMultiplierUI();
    }


    void HandleMenu()
    {
        if(_menuObj.activeSelf == false)
        {
            _menuObj.SetActive(true);
            Time.timeScale = 0;
        }
        else 
        {
            _menuObj.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void ClosePuseMenu()
    {
        _menuObj.SetActive(false);
        Time.timeScale = 1;
    }

    public IEnumerator FinalGame()
    {
        _finalPanel.SetActive(true);

        yield return new WaitForSeconds(2);

        Scene_Manager.Instance.LoadScene(0);
    }


    public void PointsShakeUI(int value)// funcion que llama a la corrutina del points shacke
    {
        StartCoroutine(PointsShake(value));
    }

    public void MultiShakeUI(int value)// funcion que llama a la corrutina del multi shacke
    {
        StartCoroutine(MultiShake(value));
    }

    IEnumerator MultiShake(int value)
    {
        if (value == 1)// Dependiendo del valor proporcionado se aplica un color o otro
        {
            _multipierText.color = Color.green;
        }
        else if (value == -1)
        {
            _multipierText.color = Color.red;
        }

        _initPos = _multipierText.transform.position;// se guarda la posición inicial
        _currentTransform = _multipierText.transform;// se guarda el transform del texto
        _isShake = true;// Se activa el Rumle

        yield return new WaitForSeconds(0.2f);// se espera el tiempo indicado

        _isShake = false;// se desactiva el Shake
        _multipierText.color = Color.white;// se devuelve el color al texto
        _currentTransform.position = _initPos;// se devuelve el texto a su posición inicial
        _currentTransform = null;// se elimina el current transform
    }



    IEnumerator PointsShake(int value)
    {
        if (value == 1)// Dependiendo del valor proporcionado se aplica un color o otro
        {
            _pointsText.color = Color.green;
        }
        else if (value == -1)
        {
            _pointsText.color = Color.red;
        }

        _initPos = _pointsText.transform.position;// se guarda la posición inicial
        _currentTransform = _pointsText.transform;// se guarda el transform del texto
        _isShake = true;// Se activa el Rumle

        yield return new WaitForSeconds(0.2f);// se espera el tiempo indicado

        _isShake = false;// se desactiva el Shake
        _pointsText.color = Color.white;// se devuelve el color al texto
        _currentTransform.position = _initPos;// se devuelve el texto a su posición inicial
        _currentTransform = null;// se elimina el current transform

    }

    void Shake(Transform transform)
    {
        transform.position = new Vector2(Random.Range(_initPos.x - 0.1f, _initPos.x + 0.1f), Random.Range(_initPos.y - 0.1f, _initPos.y + 0.1f));// se modifican los valores de posicion para simular un Shake
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
