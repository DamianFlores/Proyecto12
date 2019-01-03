using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Actividades : MonoBehaviour {

    public static Actividades instancia;
    public string actividadActual;

    private void Awake()
    {
        instancia = this;
    }

    private void AbrirActividad(string nombre)
    {
        actividadActual = nombre;
        SceneManager.LoadSceneAsync(nombre, LoadSceneMode.Additive);
        EnHub = false;
    }

    public void AbrirTablero()
    {
        AbrirActividad("Tablero");
    }

    public void CerrarActividad()
    {
        SceneManager.UnloadSceneAsync(actividadActual);
        EnHub = true;
    }

    private bool EnHub
    {
        set
        {
            NavegacionGeneral.instancia.gameObject.SetActive(value);
        }
    }
}
