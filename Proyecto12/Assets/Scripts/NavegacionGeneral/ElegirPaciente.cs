using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ElegirPaciente : MonoBehaviour {

    public Pacientes pacientes;
    public InputField nombre;

    public void Aceptar()
    {
        var p = pacientes.BuscarPorString(nombre.text);

        switch(p.Length)
        {
            case 0:
                Debug.Log("No hay pacientes con ese nombre.");
                break;
            case 1:
                GetComponentInParent<NavegacionGeneral>().IniciarSesion(p[0]);
                break;
            default:
                NavegacionGeneral.instancia.AbrirElegirPaciente2(p);
                break;
        }
    }
}
