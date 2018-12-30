using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Sesion", menuName = "Datos/Sesion")]
public class Sesion : ScriptableObject
{
    [System.Serializable()]
    public class Reaccion
    {
        public enum Tipo { contento, triste, enojado, distraido, abstraido };

        public Tipo estado;
        public UDateTime hora;

        public Reaccion(Tipo estado, System.DateTime hora)
        {
            this.estado = estado;
            this.hora = hora;
        }
    }

    public const string PATH = "Assets/Prefabs/ScriptableObjects/Sesiones";
    public UDateTime fecha;
    public List<Reaccion> reacciones;
    public Paciente paciente;
    [TextArea()]
    public string observaciones;

    public void Iniciar(Paciente paciente)
    {
        this.paciente = paciente;
        AssetDatabase.CreateAsset(this, string.Format("{0}/Sesion_{1}, {2}_{3}.asset",
            PATH,
            paciente.apellido.ToUpper(),
            paciente.nombre,
            System.DateTime.Now.ToShortDateString().Replace('/', '-') ) );

        fecha = System.DateTime.Now;
        reacciones = new List<Reaccion>();
    }

    public void RegistrarReaccion(int estado)
    {
        reacciones.Add(new Reaccion((Reaccion.Tipo)estado, System.DateTime.Now));
    }

    public void Cerrar()
    {

    }
}
