using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalEnum : Singleton<GlobalEnum>
{
   public enum BallTypes
    {
        Normal,
        Multi,
        Rainbow,
        Negative,
        Positive
    }

    public enum SpawnModes
    {
        Fixed,
        Random
    }

    public enum AnimationId
    {
        Walk = 0,
        Absorb = 1
    }
}
