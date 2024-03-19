using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points_Manager : MonoBehaviour
{
    void AddPointsWithMulti(float points)// Metodo para sumar puntos con multi
    {
        GameController.Instance.CurrentPoints += points * GameController.Instance.CurrentPointsMultiplier;// Se suman los puntos multiplicados por el multiplicador
        UI_Manager.Instance.UpdatePointsUI();// Se actualiza la UI
        UI_Manager.Instance.PointsShakeUI(1);// Se realiza un peque�o shake al texto cuando se modifica
    }

    void SubstractPointsWithMulti(float points)// Se restan los puntos multiplicados por el Multiplicador
    {
        GameController.Instance.CurrentPoints -= points * GameController.Instance.CurrentPointsMultiplier;
        UI_Manager.Instance.UpdatePointsUI();// Se actualiza la UI
        UI_Manager.Instance.PointsShakeUI(-1);// Se realiza un peque�o shake al texto cuando se modifica
    }

    void AddMultiplier(float multi)// Se suma Multiplicador
    {
        GameController.Instance.CurrentPointsMultiplier += multi;
        UI_Manager.Instance.UpdateMultiplierUI();// Se actualiza la UI
        UI_Manager.Instance.MultiShakeUI(1);// Se realiza un peque�o shake al texto cuando se modifica
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag.Equals("Ball"))
        {
            Ball_Controller _ballcontroller = col.GetComponent<Ball_Controller>();// Se guarda el Ball Controller
            if (_ballcontroller.BallType == GlobalEnum.BallTypes.Normal)// Si la Bola es normal se suman Puntos
            {
                AddPointsWithMulti(_ballcontroller.Points);
            }
            else if (_ballcontroller.BallType == GlobalEnum.BallTypes.Multi)// Si es Multi se suman puntos y multiplicador
            {
                AddPointsWithMulti(_ballcontroller.Points);
                AddMultiplier(1);
            }
            else if (_ballcontroller.BallType == GlobalEnum.BallTypes.Rainbow)// Si es Rainbow se suman puntos y un multiplicador aleatorio del 1 al 10
            {
                AddPointsWithMulti(_ballcontroller.Points);
                int multi = Random.Range(1, 10);
                AddMultiplier(multi);
            }
            else if (_ballcontroller.BallType == GlobalEnum.BallTypes.Positive)// Si es Positive se suman puntos, una vida maxima y una vida
            {
                AddPointsWithMulti(_ballcontroller.Points);
                GameController.Instance.AddMaxLife(1);
                GameController.Instance.AddLife(1);
            }
            else if (_ballcontroller.BallType == GlobalEnum.BallTypes.Negative)// Si es Negative se restan puntos
            {
                SubstractPointsWithMulti(_ballcontroller.Points);
            }

            col.gameObject.SetActive(false);// Se desactiva la bola para volver a ser usada
        }
    }
}
