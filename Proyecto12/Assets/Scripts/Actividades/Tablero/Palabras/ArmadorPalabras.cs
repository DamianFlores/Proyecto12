using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmadorPalabras : MonoBehaviour
{
    public Tablero.Estado.Visibilidad visibilidad;
    public Palabra2 palabra;

    public void Abrir(Palabra2 palabra, Tablero.Estado.Visibilidad visibilidad)
    {
        this.palabra = palabra;
        this.visibilidad = visibilidad;
    }
}
