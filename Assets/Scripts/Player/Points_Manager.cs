using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Points_Manager : MonoBehaviour
{
    void AddPointsWithMulti(float points)
    {
        GameController.Instance.CurrentPoints += points * GameController.Instance.CurrentPointsMultiplier;
    }

    void SubstractPointsWithMulti(float points)
    {
        GameController.Instance.CurrentPoints -= points * GameController.Instance.CurrentPointsMultiplier;
    }
    void AddMultiplier(float multi)
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
                AddPointsWithMulti(_ballcontroller.Points);
            }
            else if (_ballcontroller.BallType == GlobalEnum.BallTypes.Multi)
            {
                AddPointsWithMulti(_ballcontroller.Points);
                AddMultiplier(1);
            }
            else if (_ballcontroller.BallType == GlobalEnum.BallTypes.Rainbow)
            {
                AddPointsWithMulti(_ballcontroller.Points);
                int multi = Random.Range(1, 10);
                AddMultiplier(multi);
                Debug.Log($"Multi added: {multi}");
            }
            else if (_ballcontroller.BallType == GlobalEnum.BallTypes.Positive)
            {
                AddPointsWithMulti(_ballcontroller.Points);
                GameController.Instance.AddLife(1);
            }
            else if (_ballcontroller.BallType == GlobalEnum.BallTypes.Negative)
            {
                SubstractPointsWithMulti(_ballcontroller.Points);
            }

            col.gameObject.SetActive(false);
        }
    }
}
