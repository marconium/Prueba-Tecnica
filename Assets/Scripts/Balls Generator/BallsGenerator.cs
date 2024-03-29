using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class BallsGenerator : MonoBehaviour
{
    [Header("Settings")]

    [SerializeField] private GlobalEnum.SpawnModes spawMode;

    [Header("Fixed Delay")]

    [SerializeField] private float delayBtwSpawns;

    [Header("Random Delay")]

    [SerializeField] private float minRandomDelay;
    [SerializeField] private float maxRandomDelay;

    [Header("Ball References")]

    [SerializeField] GameObject _ball;

    [Header("Box Collider2D Reference")]

    [SerializeField] BoxCollider2D _collider;

    [Header("Pooler Referece")]

    [SerializeField] ObjectPooler _pooler;

    [Header("Ball Variables")]

    [SerializeField] Vector3 _instantiateBallsTransform;


    private float _spawnTimer;
    private void Awake()
    {
        _collider = GetComponent<BoxCollider2D>();// Se recoge el BoxCollider2D
    }
    private void Update()
    {
        if (!GameController.Instance.IsDead)
        {
            _spawnTimer -= Time.deltaTime;// se resta el tiempo transcurrido al Timer
            if (_spawnTimer < 0)// si el timer es menor que 0 
            {
                _spawnTimer = GetSpawnDelay();// se vuelve a poner bien el delay

                SpawnBall();// se espawnea una bola

            }
        }
    }
    public void SpawnBall()// metodo que coloca la bola en su lugar de lanzamiento
    {
        _instantiateBallsTransform = new Vector2(Random.Range(_collider.bounds.min.x, _collider.bounds.max.x), _collider.transform.position.y);

        GameObject NewBall = _pooler.GetInstanceFromPool();
        NewBall.transform.position = _instantiateBallsTransform;
        PutBallGravity(NewBall);
        NewBall.SetActive(true);
    }

    void PutBallGravity(GameObject NewBall)
    {
        Rigidbody2D _ballRigid = NewBall.GetComponent<Rigidbody2D>();
        if(GameController.Instance.CurrentPoints >= 100 && GameController.Instance.CurrentPoints < 500)
        {
            _ballRigid.gravityScale = 0.5f;
        }
        else if (GameController.Instance.CurrentPoints >= 500 && GameController.Instance.CurrentPoints < 1000)
        {
            _ballRigid.gravityScale = 0.8f;
        }
        else if (GameController.Instance.CurrentPoints >= 1000)
        {
            _ballRigid.gravityScale = 0.9f;
        }
    }

    private float GetSpawnDelay()// metodo para recojer el delay entre bolas
    {
        float delay = 0f;
        if (spawMode == GlobalEnum.SpawnModes.Fixed)
        {
            delay = delayBtwSpawns;
        }
        else
        {
            delay = GetRandomDelay();
        }

        return delay;
    }

    private float GetRandomDelay()// metodo que devuelve un delay random entre los dos numeros que le damos
    {
        float randomTimer = Random.Range(minRandomDelay, maxRandomDelay);
        return randomTimer;
    }
}
