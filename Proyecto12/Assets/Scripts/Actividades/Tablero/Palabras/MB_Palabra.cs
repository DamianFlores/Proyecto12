using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable()]
public class Palabra
{
    [System.Serializable()]
    public class Referencia
    {
        public Cumulo cumulo;
        public int indice;
        public Palabra palabra { get { return cumulo.palabras[indice]; } }
    }

    public string palabra;
    public Sprite imagen;

    public Palabra(string palabra, Sprite imagen)
    {
        this.palabra = palabra;
        this.imagen = imagen;
    }
}

public class MB_Palabra : MonoBehaviour
{
    public Sprite imagen;
    private Palabra _palabra;

    public MB_Cumulo cumulo
    {
        get { return GetComponentInParent<MB_Cumulo>(); }
    }

    public Palabra palabra
    {
        get
        {
            if(_palabra == null)
                _palabra = new Palabra(name, imagen);
            return _palabra;
        }
    }
}
