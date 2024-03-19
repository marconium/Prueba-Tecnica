using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransportWall : MonoBehaviour
{
    [Header("Object Reference")]

    [SerializeField] GameObject _targuetPos;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag.Equals("Player"))
        {
            col.transform.position = _targuetPos.transform.position;
        }
    }
}
