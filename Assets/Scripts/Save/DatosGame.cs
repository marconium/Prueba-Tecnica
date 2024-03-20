using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class SaveData
{
    public int _id;
    public float _points;

    public SaveData(int id, float points)
    {
        this._id = id;
        this._points = points;
    }
}

[Serializable]
public class DatosGame 
{
    [field: SerializeField] public List<SaveData> _gameSaveData;
    public float _currentTime;
}
