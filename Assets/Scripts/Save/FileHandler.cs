using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;
using System.Linq;

public static class FileHandler
{
    public static void SaveToJSON<T>(List<T> ToSave, string filename)// metodo para guardar una Lista
    {
        Debug.Log(GetPath(filename));
        string content = JsonHelper.ToJson<T>(ToSave.ToArray());
        WriteFile(GetPath(filename),content);
    }
    public static void SaveToJSON<T>(T ToSave, string filename)// metodo para guardar una variable
    {
        Debug.Log(GetPath(filename));
        string content = JsonUtility.ToJson(ToSave);
        WriteFile(GetPath(filename), content);
    }

    public static List<T> ReadListFromJSON<T>(string filename)// metodo para leer una Lista
    {
        string content = ReadFile(GetPath(filename));

        if(string.IsNullOrEmpty(content) || content == "{}")
        {
            return new List<T>();
        }

        List<T> res = JsonHelper.FromJson<T>(content).ToList();

        return res;
    }

    public static T ReadFromJSON<T>(string filename)// metodo para leer una variable
    {
        string content = ReadFile(GetPath(filename));

        if (string.IsNullOrEmpty(content) || content == "{}")
        {
            return default(T);
        }

        T res = JsonUtility.FromJson<T>(content);

        return res;
    }

    private static string GetPath(string filename)
    {
        return Application.persistentDataPath + "/" + filename;
    }

    private static void WriteFile(string path, string content)// metodo para escibir o Crear un archivo dandole el camino
    {
        FileStream fileStream = new FileStream(path, FileMode.Create);

        using (StreamWriter writer = new StreamWriter(fileStream))
        {
            writer.Write(content);
        }
    }

    private static string ReadFile(string path)// metodo para leer un archivo dandole el camino
    {
        if (File.Exists(path))
        {
            using (StreamReader reader = new StreamReader(path))
            {
                string content = reader.ReadToEnd();
                return content;
            }
        }

        return "";
    }
}
public static class JsonHelper// se trata de una clase que facilita la conversion hacia Json
{
    public static T[] FromJson<T>(string json)
    {
        Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
        return wrapper.Items;
    }

    public static string ToJson<T>(T[] array)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper);
    }

    public static string ToJson<T>(T[] array, bool prettyPrint)
    {
        Wrapper<T> wrapper = new Wrapper<T>();
        wrapper.Items = array;
        return JsonUtility.ToJson(wrapper, prettyPrint);
    }

    [Serializable]
    private class Wrapper<T>
    {
        public T[] Items;
    }
}