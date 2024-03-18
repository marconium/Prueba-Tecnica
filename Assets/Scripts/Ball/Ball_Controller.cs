using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Ball_Controller : MonoBehaviour
{

    private void OnEnable()
    {
        // Aqui va la logica de que tipo de bola es
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag.Equals("BallDestroyer"))// Al colisionar con el destructor desactiva la bola para poder ser usada posteriormente
        {
            gameObject.SetActive(false);
        }
    }
}
