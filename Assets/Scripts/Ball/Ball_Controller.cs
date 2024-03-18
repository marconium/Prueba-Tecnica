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
        SelectColor();
    }

    public void SelectBallType()
    {
        if(_randomNum >= 5 && _randomNum >= 25)
        {
            _ballType = GlobalEnum.BallTypes.Multi;
        }
        else if(_randomNum == 2)
        {
            _ballType = GlobalEnum.BallTypes.Negative;
        }
        else if(_randomNum == 3)
        {
            _ballType = GlobalEnum.BallTypes.Positive;
        }
        else if(_randomNum == 4)
        {
            _ballType = GlobalEnum.BallTypes.Rainbow;
        }
        else
        {
            _ballType = GlobalEnum.BallTypes.Normal;
        }
    }

    public void SelectColor()
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
