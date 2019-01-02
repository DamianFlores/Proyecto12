using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEditor;
using UnityEngine;

public static class UtilsSO
{
    public static List<T> ListarEnCarpeta<T>(string carpeta) where T : ScriptableObject
    {
        var r = new List<T>();
        var paths = Directory.GetFiles(carpeta, "*.asset");
        foreach(string p in paths)
        {
            var a = AssetDatabase.LoadAssetAtPath<T>(p);
            if(a)
                r.Add(a);
        }

        return r;
    }
}
