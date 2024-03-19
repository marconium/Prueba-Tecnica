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
    }

    public void SelectBallType()// metodo que seleccióna de que tipo y color es la Bola dependiendo el _randomNum
    {
        if (_randomNum >= 1 && _randomNum <= 5)
        {
            _ballType = GlobalEnum.BallTypes.Multi;
            _renderer.color = Color.green;
        }
        else if (_randomNum >= 6 && _randomNum <= 10)
        {
            _ballType = GlobalEnum.BallTypes.Negative;
            _renderer.color = Color.black;
        }
        else if (_randomNum >= 11 && _randomNum <= 15)
        {
            _ballType = GlobalEnum.BallTypes.Positive;
            _renderer.color = Color.red;
        }
        else if (_randomNum >= 16 && _randomNum <= 20)
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



    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag.Equals("BallDestroyer"))// Al colisionar con el destructor se resta la correspondiente vida y se desactiva la bola para poder ser usada posteriormente
        {
            if (_ballType == GlobalEnum.BallTypes.Normal)// Se comprueba que sea una bola de tipo normal
            {
                GameController.Instance.SubstractLife(1);
            }
            gameObject.SetActive(false);
        }
    }
}
