using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PacienteNuevo : MonoBehaviour
{
    public InputField nombre, apellido;
    public Dropdown anno, mes, dia, genero;
    public InputField padres, diagnostico, observaciones;
    public Pacientes pacientes;

    private void Awake()
    {
        var annos = new List<string>();
        for (var i = System.DateTime.Now.Year; i >= 1900; i--)
            annos.Add(i.ToString());
        anno.AddOptions(annos);
        ActualizarMes();
    }

    public void Aceptar()
    {
        var paciente = new Paciente();
        paciente.nombre = nombre.text;
        paciente.apellido = apellido.text;
        paciente.anno = int.Parse(anno.options[anno.value].text);
        paciente.mes = mes.value + 1;
        paciente.dia = dia.value + 1;
        paciente.genero = (Paciente.Genero)genero.value;
        paciente.padres = padres.text;
        paciente.diagnostico = diagnostico.text;
        paciente.observaciones = observaciones.text;
        pacientes.pacientes.Add(paciente);

        Debug.Log(paciente.edad);

        GetComponentInParent<NavegacionGeneral>().IniciarSesion(paciente);
    }

    public void ActualizarMes()
    {
        var cantidadDias = System.DateTime.DaysInMonth(annoIndicado, mes.value + 1);
        var diferencia = cantidadDias - dia.options.Count;
        if (diferencia != 0)
        {
            dia.ClearOptions();
            var opciones = new List<string>();
            for (var i = 1; i <= cantidadDias; i++)
                opciones.Add(i.ToString());
            dia.AddOptions(opciones);
            if(dia.value >= opciones.Count)
                dia.value = opciones.Count - 1;
        }
    }

    private int annoIndicado
    {
        get { return int.Parse(anno.options[anno.value].text); }
    }
}
