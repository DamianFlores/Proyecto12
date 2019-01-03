using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BotonElegirPaciente : MonoBehaviour {

    public Paciente paciente;

	void Start ()
    {
        GetComponentInChildren<Text>().text = string.Format("{0} {1}", paciente.nombre, paciente.apellido);
	}

    public void Click()
    {
        NavegacionGeneral.instancia.IniciarSesion(paciente);
    }
}
