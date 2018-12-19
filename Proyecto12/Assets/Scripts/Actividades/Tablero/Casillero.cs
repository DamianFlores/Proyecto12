using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Casillero : MonoBehaviour {

    public int indice;
    public UnityEvent accion;

    public void Accionar()
    {
        accion.Invoke();
    }
}
