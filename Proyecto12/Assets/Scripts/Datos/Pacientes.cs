using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public enum ReaccionPaciente { contento, triste, enojado, distraido, abstraido };

[System.Serializable()]
public class Paciente
{
    [System.Serializable()]
    public class Sesion
    {
        [System.Serializable()]
        public class Reaccion
        {
            public ReaccionPaciente estado;
            public UDateTime hora;

            public Reaccion(ReaccionPaciente estado, System.DateTime hora)
            {
                this.estado = estado;
                this.hora = hora;
            }
        }

        public UDateTime fecha;
        public List<Reaccion> reacciones;
        [TextArea()]
        public string observaciones;

        public Sesion()
        {
            fecha = System.DateTime.Now;
            reacciones = new List<Reaccion>();
        }
    }

    public enum Genero { femenino, masculino, noBinario };

    public string nombre, apellido, padres;
    public int anno, mes, dia;
    [TextArea()]
    public string diagnostico, observaciones;
    public List<Sesion> historiaSesiones;
    public Genero genero;

    public Paciente()
    {

    }

    public System.DateTime fechaNacimiento
    {
        get { return new System.DateTime(anno, mes, dia); }
    }

    public int edad
    {
        get
        {
            var ahora = System.DateTime.Now;
            var r = ahora.Year - fechaNacimiento.Year;
            if (ahora.Month < fechaNacimiento.Month || (ahora.Month == fechaNacimiento.Month && ahora.Day < fechaNacimiento.Day))
                r--;
            return r;
        }
    }

    public string[] StringsParaBusqueda
    {
        get
        {
            return nombre.Split(' ').Concat(apellido.Split(' ')).ToArray();
        }
    }

    public bool ContieneString(string s)
    {
        return StringsParaBusqueda.Any(ss => SimplificarString(ss) == s);
    }

    public string vocalGenero
    {
        get { return new string[] { "a", "o", "e" }[(int)genero]; }
    }

    public static string SimplificarString(string s)
    {
        var r = s.ToUpper();
        foreach(var c in Pacientes.conversiones)
            r = r.Replace(c.car1, c.car2);
        return r;
    }
}

public class Pacientes : MonoBehaviour {

    public class ConversionCaracter
    {
        public char car1, car2;
        public ConversionCaracter(char car1, char car2)
        {
            this.car1 = car1;
            this.car2 = car2;
        }
    }

    public static ConversionCaracter[] conversiones = new ConversionCaracter[]
    {
        new ConversionCaracter('Á', 'A'),
        new ConversionCaracter('É', 'E'),
        new ConversionCaracter('Í', 'I'),
        new ConversionCaracter('Ó', 'O'),
        new ConversionCaracter('Ú', 'U'),
        new ConversionCaracter('A', 'A'),
        new ConversionCaracter('O', 'O'),
        new ConversionCaracter('Ü', 'U'),
        new ConversionCaracter('Ñ', 'N'),
        new ConversionCaracter('Ç', 'C'),
    };


    public List<Paciente> pacientes;

    public Paciente[] BuscarPorString(string s)
    {
        return pacientes.Where(p => p.ContieneString(Paciente.SimplificarString(s))).ToArray();
    }
}
