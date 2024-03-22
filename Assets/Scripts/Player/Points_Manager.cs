using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points_Manager : MonoBehaviour
{

    [Header("Animator Reference")]

    [SerializeField] Animator _animator;

    [Header("Audio Clip Reference")]

    [SerializeField] AudioClip _absorbSFX;

    void AddPointsWithMulti(float points)// Metodo para sumar puntos con multi
    {
        GameController.Instance.CurrentPoints += points * GameController.Instance.CurrentPointsMultiplier;// Se suman los puntos multiplicados por el multiplicador
        UI_Manager.Instance.UpdatePointsUI();// Se actualiza la UI
        UI_Manager.Instance.PointsShakeUI(1);// Se realiza un pequeño shake al texto cuando se modifica
    }

    void SubstractPointsWithMulti(float points)// Se restan los puntos multiplicados por el Multiplicador Al final no se usa pero puede estar bien 
    {
        GameController.Instance.CurrentPoints -= points * GameController.Instance.CurrentPointsMultiplier;
        UI_Manager.Instance.UpdatePointsUI();// Se actualiza la UI
        UI_Manager.Instance.PointsShakeUI(-1);// Se realiza un pequeño shake al texto cuando se modifica
    }

    void AddMultiplier(float multi)// Se suma Multiplicador
    {
        GameController.Instance.CurrentPointsMultiplier += multi;
        UI_Manager.Instance.UpdateMultiplierUI();// Se actualiza la UI
        UI_Manager.Instance.MultiShakeUI(1);// Se realiza un pequeño shake al texto cuando se modifica
    }
    void ResetMulti()//Metodo para resetear el multiplicador a 1
    {
        GameController.Instance.CurrentPointsMultiplier = 1;
        UI_Manager.Instance.UpdateMultiplierUI();// Se actualiza la UI
        UI_Manager.Instance.MultiShakeUI(-1);// Se realiza un pequeño shake al texto cuando se modifica
    }




    void BallsEffect(Ball_Controller _ballcontroller)
    {
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
        else if (_ballcontroller.BallType == GlobalEnum.BallTypes.Negative)// Si es Negative se resetea el multiplicador
        {
            ResetMulti();
        }
        AudioManager.Instance.PlaySfx(_absorbSFX);
        AnimatorController.Instance.Play(GlobalEnum.AnimationId.Absorb);
    }






    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag.Equals("Ball") && !GameController.Instance.IsDead)
        {
            Ball_Controller _ballcontroller = col.GetComponent<Ball_Controller>();// Se guarda el Ball Controller

            BallsEffect(_ballcontroller);

            col.gameObject.SetActive(false);// Se desactiva la bola para volver a ser usada
        }
    }
}
