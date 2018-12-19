using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Palabra", menuName = "Palabra", order = 1)]
public class Palabra2 : ScriptableObject {
    public string palabra;
    public Sprite imagen;

    
    private void Awake()
    {
        palabra = name;
    }
}
