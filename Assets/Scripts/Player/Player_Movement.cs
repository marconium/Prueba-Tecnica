using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{

    [Header("Direccion del movimiento")]

    [SerializeField] public Vector2 MovementDirection;

    [Header("RigidBody2D Reference")]

    [SerializeField] Rigidbody2D _rigidbody2D;

    [Header("Movement Variables")]

    [SerializeField] float _speed;

    void Update()
    {
        HandleControls();
        HandleMovenemt();     
    }

    void HandleControls()// Metodo que recoge el input de movimento
    {
        MovementDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));// Aqui se esta recogiendo el movimento tanto Horizontal como Vertical
    }

    void HandleMovenemt()// Metodo que gestiona la aplicación del movimiento
    {
        _rigidbody2D.velocity = new Vector2(MovementDirection.x * _speed, _rigidbody2D.velocity.y);// se le aplica velociad al  rigidbody2d
    }
}
