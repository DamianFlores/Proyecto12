using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmadorPalabras : MonoBehaviour {

    public Modos.Visibilidad visibilidad;
    public Palabra palabra;

    public void Abrir(Palabra palabra, Modos.Visibilidad visibilidad)
    {
        this.palabra = palabra;
        this.visibilidad = visibilidad;
    }
}
