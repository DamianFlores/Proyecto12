using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[System.Serializable()]
public class Cumulo
{
    public Palabra[] palabras;

    public Cumulo(Palabra[] palabras)
    {
        this.palabras = palabras;
    }
}

public class MB_Cumulo : MonoBehaviour {

    public Cumulo cumulo;

    private void Awake()
    {
        cumulo = new Cumulo(GetComponentsInChildren<MB_Palabra>().Select(p => p.palabra).ToArray());
    }

    private void Start()
    {
        name = transform.GetChild(0).name;
    }
}
