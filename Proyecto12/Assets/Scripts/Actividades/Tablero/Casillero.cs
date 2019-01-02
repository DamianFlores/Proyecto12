using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casillero : MonoBehaviour {

    public int indice;
    public System.Action accion;
    
    public void Accionar()
    {
        accion();
    }
}
