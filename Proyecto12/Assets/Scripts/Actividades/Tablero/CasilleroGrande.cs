using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CasilleroGrande : MonoBehaviour {

    public Image imagen;
    public Text referencia;
    public Text solucion;

    public Palabra2 palabra;
    public Tablero.Estado.Visibilidad visibilidad;

    public void Abrir(Palabra2 palabra, Tablero.Estado.Visibilidad visibilidad)
    {
        this.palabra = palabra;
        this.visibilidad = visibilidad;

        imagen.sprite = palabra.imagen;
        referencia.text = visibilidad.efecto(palabra.name);
    }

    public void UbicarLetra()
    {

    }

    public void Completar()
    {

    }
}
