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

    [Header("Sprites References")]

    [SerializeField] Sprite _normalSprite;
    [SerializeField] Sprite _multiSprite;
    [SerializeField] Sprite _positiveSprite;
    [SerializeField] Sprite _negativeSprite;
    [SerializeField] Sprite _rainbowSprite;

    [Header("Collider Reference")]

    [SerializeField] CircleCollider2D _collider;

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
        }
        else if (_randomNum >= 6 && _randomNum <= 10)
        {
            _ballType = GlobalEnum.BallTypes.Negative;
        }
        else if (_randomNum >= 11 && _randomNum <= 15)
        {
            _ballType = GlobalEnum.BallTypes.Positive;
        }
        else if (_randomNum >= 16 && _randomNum <= 20)
        {
            _ballType = GlobalEnum.BallTypes.Rainbow;
        }
        else
        {
            _ballType = GlobalEnum.BallTypes.Normal;
        }
        PlaceSprite(_ballType);
    }

    void PlaceSprite(GlobalEnum.BallTypes type)
    {
        switch (type)
        {
            case GlobalEnum.BallTypes.Normal:
                _renderer.sprite = _normalSprite;
                _collider.offset = new Vector2(0, 0f);
                break;
            case GlobalEnum.BallTypes.Multi:
                _renderer.sprite = _multiSprite;
                _collider.offset = new Vector2(0, -0.31f);
                break;
            case GlobalEnum.BallTypes.Rainbow:
                _renderer.sprite = _rainbowSprite;
                _collider.offset = new Vector2(0, 0f);
                break;
            case GlobalEnum.BallTypes.Negative:
                _renderer.sprite = _negativeSprite;
                _collider.offset = new Vector2(0, 0f);
                break;
            case GlobalEnum.BallTypes.Positive:
                _renderer.sprite = _positiveSprite;
                _collider.offset = new Vector2(0, 0f);
                break;          
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
