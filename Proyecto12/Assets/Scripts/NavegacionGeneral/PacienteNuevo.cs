using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PacienteNuevo : MonoBehaviour
{
    [Header("UI")]
    public InputField nombre, apellido;
    public Dropdown anno, mes, dia, genero;
    public InputField padres, diagnostico, observaciones;
    [Header("Scriptable Object")]
    public Paciente pacienteSO;

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
        NavegacionGeneral.instancia.IniciarSesion(CrearPaciente());
    }
    
    private Paciente CrearPaciente()
    {
        var paciente = Instantiate(pacienteSO);
        paciente.IngresarValores(
            nombre.text,
            apellido.text,
            int.Parse(anno.options[anno.value].text),
            mes.value + 1,
            dia.value + 1,
            genero.value,
            padres.text,
            diagnostico.text,
            observaciones.text
        );

        Paciente.AgregarPaciente(paciente);
        return paciente;
    }

    public void ActualizarMes()
    {
        var cantidadDias = System.DateTime.DaysInMonth(AnnoIndicado, mes.value + 1);
        if (cantidadDias - dia.options.Count != 0)
            CorregirDias(cantidadDias);
    }

    private void CorregirDias(int cantidad)
    {
        dia.ClearOptions();
        var opciones = new List<string>();
        for (var i = 1; i <= cantidad; i++)
            opciones.Add(i.ToString());
        dia.AddOptions(opciones);
        if (dia.value >= opciones.Count)
            dia.value = opciones.Count - 1;
    }

    private int AnnoIndicado { get { return int.Parse(anno.options[anno.value].text); } }
}
