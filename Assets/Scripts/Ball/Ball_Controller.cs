using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Ball_Controller : MonoBehaviour
{
    public float Points { get => _points; set => _points = value; }
    public GlobalEnum.BallTypes BallType { get => _ballType; set => _ballType = value; }

    [Header("Puntos Sumados")]

    [SerializeField] float _points;

    [Header("Ball type Variables")]

    [SerializeField] GlobalEnum.BallTypes _ballType;


    [Header("Sprite Renderer Reference")]

    [SerializeField] SpriteRenderer _renderer;

    private int _randomNum;
    private void OnEnable()
    {
        _randomNum = Random.Range(1, 100);
        SelectBallType();
       // SelectColor();
    }

    public void SelectBallType()// metodo que selecci�na de que tipo y color es la Bola
    {
        if(_randomNum >= 1 && _randomNum <= 5)
        {
            _ballType = GlobalEnum.BallTypes.Multi;
            _renderer.color = Color.green;
        }
        else if(_randomNum >= 6 && _randomNum <= 10)
        {
            _ballType = GlobalEnum.BallTypes.Negative;
            _renderer.color = Color.black;
        }
        else if(_randomNum >= 11 && _randomNum <= 15)
        {
            _ballType = GlobalEnum.BallTypes.Positive;
            _renderer.color = Color.red;
        }
        else if(_randomNum >= 16 && _randomNum <= 20)
        {
            _ballType = GlobalEnum.BallTypes.Rainbow;
            _renderer.color = Color.blue;
        }
        else
        {
            _ballType = GlobalEnum.BallTypes.Normal;
            _renderer.color = Color.white;
        }
    }

    public void SelectColor()// Metodo que cambia el color dependiendo del tipo 
    {
        switch (_ballType)
        {
            case GlobalEnum.BallTypes.Normal:

                _renderer.color = Color.white;

                break;
            case GlobalEnum.BallTypes.Multi:

                _renderer.color = Color.green;

                break;
            case GlobalEnum.BallTypes.Rainbow:

                _renderer.color = Color.blue;

                break;
            case GlobalEnum.BallTypes.Negative:

                _renderer.color = Color.black;

                break;
            case GlobalEnum.BallTypes.Positive:

                _renderer.color = Color.red;

                break;

            default:

                break;
        }

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag.Equals("BallDestroyer"))// Al colisionar con el destructor desactiva la bola para poder ser usada posteriormente
        {
            gameObject.SetActive(false);
        }
    }
}
