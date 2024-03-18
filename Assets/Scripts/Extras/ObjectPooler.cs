using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    [SerializeField] private int poolSize = 10;

    private List<GameObject> _pool;
    private GameObject _poolContainer;

    private void Awake()
    {
        _pool = new List<GameObject>();// Se inicializa la lista de objetos de la pool
        _poolContainer = new GameObject($"Pool - {prefab.name}");// Se crea un contenedor para los objetos

        CreatePooler();// se crea la pool
    }

    private void CreatePooler()// metodo para crear las instancias iniciales indicadas para el Pooler
    {
        for (int i = 0; i < poolSize; i++)// se hace un for con el numero de instancias que debe de tener
        {
            _pool.Add(CreateInstance());// se crea cada instancia
        }
    }

    private GameObject CreateInstance()// metodo para crear una nueva instancia 
    {
        GameObject newInstance = Instantiate(prefab);// se instancia el prefab
        newInstance.transform.SetParent(_poolContainer.transform);// se coloca con el padre adecuado
        newInstance.SetActive(false);// se desactiva
        return newInstance;// devuelve la nueva instancia

    }

    public GameObject GetInstanceFromPool()// Metodo para cojer una instancia de la pool
    {
        for (int i = 0; i < _pool.Count; i++)// realiza un for para acceder a todas las instancias
        {
            if (!_pool[i].activeInHierarchy)// se comprueba si la instancia esta desactivada
            {
                return _pool[i];// devuelve la instancia 
            }
        }

        return CreateInstance();// si no hay ninguna desactivada devuelve una nueva
    }

    public static void ReturnToPool(GameObject instance)// metodo para devolver una instancia a la pool Aunque con desactivarla ya vale
    {
        instance.SetActive(false);// se desactiva
    }

    public static IEnumerator ReturnToPoolWithDelay(GameObject instance, float delay)// Corrutina para devolver una instancia con delay
    {
        yield return new WaitForSeconds(delay);// se aplica el dalay
        instance.SetActive(false);// se desactiva
    }
}
