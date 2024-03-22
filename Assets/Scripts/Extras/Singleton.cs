using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : Component
{
    private static T instance;
    // Esta clase esta hecha unicamente para generar Singletons de otras clases facilmente
    public static T Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<T>();
                if (instance == null)
                {
                    GameObject newInstance = new GameObject();
                    instance = newInstance.AddComponent<T>();
                }
            }
            return instance;
        }
    }


    private void Awake()
    {
        instance = this as T;
    }

}
