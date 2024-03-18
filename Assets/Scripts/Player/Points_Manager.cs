using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points_Manager : MonoBehaviour
{
    public void AddPoints(float points)
    {
        GameController.Instance.CurrentPoints += points * GameController.Instance.CurrentPointsMultiplier;
    }


    public void AddMultiplier(float multi)
    {
        GameController.Instance.CurrentPointsMultiplier += multi;
    }


    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag.Equals("Ball"))
        {
            Ball_Controller _ballcontroller = col.GetComponent<Ball_Controller>();
            if (_ballcontroller.BallType == GlobalEnum.BallTypes.Normal)
            {
                AddPoints(_ballcontroller.Points);
            }
            else if (_ballcontroller.BallType == GlobalEnum.BallTypes.Multi)
            {
                AddPoints(_ballcontroller.Points);
                AddMultiplier(1);
            }
            else if (_ballcontroller.BallType == GlobalEnum.BallTypes.Rainbow)
            {
                AddPoints(_ballcontroller.Points);
            }
            else if (_ballcontroller.BallType == GlobalEnum.BallTypes.Positive)
            {
                AddPoints(_ballcontroller.Points);
            }
            else if (_ballcontroller.BallType == GlobalEnum.BallTypes.Negative)
            {
                AddPoints(_ballcontroller.Points);
            }




            col.gameObject.SetActive(false);
        }
    }
}
