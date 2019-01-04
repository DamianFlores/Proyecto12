using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum ModoUso { paciente, profesional };
public class NavegacionGeneral : MonoBehaviour {

    public static NavegacionGeneral instancia;

    public ModoUso modo;
    public Sesion sesionActual;
    public GameObject elegirModo;
    public ElegirPaciente elegirPaciente;
    public ElegirPaciente2 elegirPaciente2;
    public PacienteNuevo pacienteNuevo;
    public Actividades actividades;
    public GameObject animoPaciente;
    public Sesion sesionSO;

    private GameObject[] pantallas;

    private void Awake()
    {
        instancia = this;
        pantallas = new GameObject[] {
            elegirModo,
            elegirPaciente.gameObject,
            elegirPaciente2.gameObject,
            pacienteNuevo.gameObject,
            actividades.gameObject };

        AbrirElegirModo();
    }

    private void ElegirModo(ModoUso m)
    {
        modo = m;
        AbrirElegirPaciente();
    }

    public void ModoProfesional() { ElegirModo(ModoUso.profesional); }
    public void ModoPaciente()    { ElegirModo(ModoUso.paciente); }

    public void IniciarSesion(Paciente paciente)
    {
        sesionActual = Instantiate(sesionSO);
        sesionActual.Iniciar(paciente);
        AbrirActividades();
        animoPaciente.SetActive(true);
    }

    public void RegistrarReaccion(int estado)
    {
        sesionActual.RegistrarReaccion(estado);
    }

    public void CerrarSesion()
    {
        sesionActual.Cerrar();

        AbrirElegirModo();
        animoPaciente.SetActive(false);
    }

    public void AbrirElegirModo()       { AbrirPantalla(elegirModo); }
    public void AbrirElegirPaciente()   { AbrirPantalla(elegirPaciente.gameObject); }
    public void AbrirElegirPaciente2(Paciente[] pacientes)
    {
        AbrirPantalla(elegirPaciente2.gameObject);
        elegirPaciente2.Abrir(pacientes);
    }
    public void AbrirPacienteNuevo()    { AbrirPantalla(pacienteNuevo.gameObject); }
    public void AbrirActividades()      { AbrirPantalla(actividades.gameObject); }

    private void AbrirPantalla(GameObject g)
    {
        foreach (var gg in pantallas.Where(ggg => ggg != g))
            gg.SetActive(false);
        g.SetActive(true);
    }
}
