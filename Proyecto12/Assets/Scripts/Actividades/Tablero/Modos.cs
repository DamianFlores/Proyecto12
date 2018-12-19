using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Modos : MonoBehaviour {

    public class Visibilidad
    {
        public string cartel;
        public System.Func<string, string> efecto;
        
        public Visibilidad(string cartel, System.Func<string, string> efecto)
        {
            this.cartel = cartel;
            this.efecto = efecto;
        }
    }

    public class Longitud
    {
        public string cartel;
        public System.Func<string, bool> filtro;

        public Longitud(string cartel, System.Func<string, bool> filtro)
        {
            this.cartel = cartel;
            this.filtro = filtro;
        }
    }

    public class Tema
    {
        public Tema()
        {

        }
    }

    public Visibilidad[] visibilidades = new Visibilidad[]
    {
        new Visibilidad("ABC", s => s),
        new Visibilidad("A<color=#888888>B</color>C",
            s =>
                {
                    string r = "";
                    for(var i = 1; i < r.Length; i++)
                        r += i % 2 == 0 ? s[i] : '_';
                    return r;
                }
            ),
        new Visibilidad("<color=#888888>ABC</color>",
            s =>
                {
                    string r = "";
                    for(var i = 1; i < r.Length; i++)
                        r += '_';
                    return r;
                }
            )
    };

    public Tema[] temas = new Tema[]
    {
        new Tema(),
        new Tema(),
        new Tema(),
        new Tema(),
        new Tema(),
        new Tema(),
        new Tema()
    };

    public Longitud[] longitudes = new Longitud[]
    {
        new Longitud("3&4", p => p.Length == 3 || p.Length == 4),
        new Longitud("4&5", p => p.Length == 4 || p.Length == 5),
        new Longitud("5&+", p => p.Length >= 5),
        new Longitud("345...", p => true)
    };

    public SelectorOr selectorTemas;

    public bool[] temasActivos = new bool[7];
    public int indiceVisibilidad;
    public int indiceLongitud;

    void Start () {
		
	}

    public void ElegirVisibilidad(int indice)
    {
        indiceVisibilidad = indice;
    }

    public void ElegirLongitud(int indice)
    {
        indiceLongitud = indice;
    }

    public void ElegirTema(int indice)
    {
        temasActivos[indice] = selectorTemas.toggles[indice].isOn;
    }

    public System.Func<string, bool> condicionLongitud
    {
        get
        {
            return longitudes[indiceLongitud].filtro;
        }
    }
}
