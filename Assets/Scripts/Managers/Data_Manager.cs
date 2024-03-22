using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Data_Manager : Singleton<Data_Manager>
{
    public List<SaveData> SavedData { get => savedData; }

    [field:SerializeField] List<SaveData> savedData = new List<SaveData>();

    [SerializeField] string filename;


    private void Awake()
    {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Data");

        if (objs.Length > 1)
        {
            Destroy(this.gameObject);
        }

        DontDestroyOnLoad(this.gameObject);

        SaveData();// se cargan los datos al iniciar
    }
    private void Start()
    {
        
    }

    public void SaveData()
    {
        savedData = FileHandler.ReadListFromJSON<SaveData>(filename);// se cargan los guardados
    }

    public void AddNewSave(SaveData data)// metodo para guardar los datos de las nuevas partidas
    {
        savedData.Add(data);

        FileHandler.SaveToJSON<SaveData>(savedData, filename);
    }
}
