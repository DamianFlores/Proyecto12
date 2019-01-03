﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElegirPaciente2 : MonoBehaviour {

    public BotonElegirPaciente botonPrefab;
    public RectTransform contenido;
    public float separacion;

    public void Abrir(Paciente[] pacientes)
    {
        Vaciar();
        gameObject.SetActive(true);

        foreach (var p in pacientes)
            Instantiate(botonPrefab, contenido.transform).paciente = p;
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
