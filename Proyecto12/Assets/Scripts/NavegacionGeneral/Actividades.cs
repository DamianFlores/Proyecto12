using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Actividades : MonoBehaviour {

    public string nombre;

    private void AbrirActividad(string nombre)
    {
        this.nombre = nombre;
        SceneManager.LoadSceneAsync(nombre, LoadSceneMode.Additive);
        NavegacionGeneral.instancia.gameObject.SetActive(false);
    }

    public void AbrirTablero()
    {
        AbrirActividad("Tablero");
    }

    public void CerrarActividad()
    {
        SceneManager.UnloadSceneAsync(nombre);
    }
}
