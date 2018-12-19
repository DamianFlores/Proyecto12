using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CasilleroGrande : MonoBehaviour {

    public Image imagen;
    public Text referencia;
    public Text solucion;

    public Palabra palabra;
    public Modos.Visibilidad visibilidad;

    public void Abrir(Palabra palabra, Modos.Visibilidad visibilidad)
    {
        this.palabra = palabra;
        this.visibilidad = visibilidad;

        imagen.sprite = palabra.imagen;
        referencia.text = visibilidad.efecto(palabra.palabra);
    }

    public void UbicarLetra()
    {

    }

    public void Completar()
    {

    }
}
