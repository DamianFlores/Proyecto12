using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmadorPalabras : MonoBehaviour
{
    public Modos.Visibilidad visibilidad;
    public Palabra2 palabra;

    public void Abrir(Palabra2 palabra, Modos.Visibilidad visibilidad)
    {
        this.palabra = palabra;
        this.visibilidad = visibilidad;
    }
}
