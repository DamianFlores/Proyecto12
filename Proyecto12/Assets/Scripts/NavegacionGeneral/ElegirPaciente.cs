using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class ElegirPaciente : MonoBehaviour {

    public InputField nombre;

    public void Aceptar()
    {
        var p = Paciente.Busqueda.BuscarPorString(nombre.text);

        switch(p.Length)
        {
            case 0:
                Debug.Log("No hay pacientes con ese nombre.");
                break;
            case 1:
                NavegacionGeneral.instancia.IniciarSesion(p[0]);
                break;
            default:
                NavegacionGeneral.instancia.AbrirElegirPaciente2(p);
                break;
        }
    }
}
