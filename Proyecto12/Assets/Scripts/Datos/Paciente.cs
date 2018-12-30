using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(fileName = "Paciente", menuName = "Datos/Paciente")]
public class Paciente : ScriptableObject
{
    public enum Genero { femenino, masculino, noBinario };

    public const string PATH = "Assets/Prefabs/ScriptableObjects/Pacientes";
    public string nombre, apellido, padres;
    public int anno, mes, dia;
    [TextArea()]
    public string diagnostico, observaciones;
    public List<Sesion> historiaSesiones;
    public Genero genero;
    
    public System.DateTime fechaNacimiento { get { return new System.DateTime(anno, mes, dia); } }

    public int Edad
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
        get { return nombre.Split(' ').Concat(apellido.Split(' ')).ToArray(); }
    }

    public bool ContieneString(string s)
    {
        return StringsParaBusqueda.Any(ss => SimplificarString(ss) == s);
    }

    public string VocalGenero { get { return new string[] { "a", "o", "e" }[(int)genero]; } }

    public static string SimplificarString(string s)
    {
        var r = s.ToUpper();
        foreach (var c in Busqueda.Conversiones)
            r = r.Replace(c.car1, c.car2);
        return r;
    }

    public static void AgregarPaciente(Paciente paciente)
    {
        AssetDatabase.CreateAsset(paciente, string.Format("{0}/{1}, {2}.asset",
            PATH,
            paciente.apellido.ToUpper(),
            paciente.nombre));
    }

    public class Busqueda
    {
        public class ConversionCaracter
        {
            public char car1, car2;
            public ConversionCaracter(char car1, char car2)
            {
                this.car1 = car1;
                this.car2 = car2;
            }
        }

        public static ConversionCaracter[] Conversiones = new ConversionCaracter[]
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

        public static List<Paciente> Lista
        {
            get
            {
                var r = new List<Paciente>();
                var paths = Directory.GetFiles("Assets/Prefabs/ScriptableObjects/Pacientes", "*.asset");
                foreach(string p in paths)
                    r.Add(AssetDatabase.LoadAssetAtPath<Paciente>(p));

                return r;
            }
        }

        public static Paciente[] BuscarPorString(string s)
        {
            return Lista.Where(p => p.ContieneString(SimplificarString(s))).ToArray();
        }
    }
}
