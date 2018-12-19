using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ElegirPaciente2 : MonoBehaviour {

    public BotonElegirPaciente botonPrefab;
    public RectTransform contenido;
    public float separacion;

    public void Abrir(Paciente[] pacientes)
    {
        Vaciar();
        gameObject.SetActive(true);

        for(var i = 0; i < pacientes.Length; i++)
        {
            var b = Instantiate(botonPrefab, contenido.transform);
            b.GetComponent<RectTransform>().localPosition = new Vector3(140, -separacion * i, 0f);
            b.paciente = pacientes[i];
        }
    }

    private void Vaciar()
    {
        for (var i = contenido.childCount - 1; i >= 0; i--)
            Destroy(contenido.GetChild(i).gameObject);
    }

    public void Elegir(Paciente paciente)
    {
        GetComponentInParent<NavegacionGeneral>().IniciarSesion(paciente);
    }
}
