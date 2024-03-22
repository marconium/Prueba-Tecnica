using System;

[Serializable]// clase que sirve para guardar la data de cada partida y ser usada en la lista
public class SaveData
{
    public int _id;
    public int _points;
    public int _multi;

    public SaveData(int id, int points, int multi)
    {
        this._id = id;
        this._points = points;
        this._multi = multi;
    }
}
