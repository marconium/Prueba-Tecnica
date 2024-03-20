using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class ControladorDatosGame : MonoBehaviour
{
    public GameObject _controller;

    public string archivoDeGuardado;

    public DatosGame _datosGame = new DatosGame();


    private void Awake()
    {
        archivoDeGuardado = Application.dataPath + "/datosGame.json";
        _controller = GameObject.FindGameObjectWithTag("GC");
    }
    

    public void GuardarDatos()
    {
        if (File.Exists(archivoDeGuardado))
        {
            string contenido = File.ReadAllText(archivoDeGuardado);
            _datosGame = JsonUtility.FromJson<DatosGame>(contenido);
        }

        var data = new SaveData(1, 1);

        DatosGame nuevosDatos = new DatosGame()
        {
            _currentTime = 1,
     
        };

        string cadenaJSON = JsonUtility.ToJson(nuevosDatos);

        File.WriteAllText(archivoDeGuardado, cadenaJSON);

        Debug.Log("Archivo Guardado");
    }
}
