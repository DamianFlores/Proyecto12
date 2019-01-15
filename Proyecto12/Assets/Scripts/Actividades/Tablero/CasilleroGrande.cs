using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CasilleroGrande : MonoBehaviour {

    public Image imagen;
    public Text referencia;
    public InputField respuesta;

    public Palabra2 palabra;
    public Tablero.Estado.Visibilidad visibilidad;

    public void Abrir(Palabra2 palabra, Tablero.Estado.Visibilidad visibilidad)
    {
        this.palabra = palabra;
        this.visibilidad = visibilidad;

        imagen.sprite = palabra.imagen;
        referencia.text = visibilidad.efecto(palabra.name);
        respuesta.text = "";

        gameObject.SetActive(true);
    }

    public void CambiaTextoRespuesta()
    {
        if (respuesta.text.ToUpper() == palabra.name.ToUpper())
            Completar();
    }

    private void Completar()
    {
        gameObject.SetActive(false);
    }
}
