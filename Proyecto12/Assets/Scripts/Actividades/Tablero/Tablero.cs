using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Tablero : MonoBehaviour
{
    [System.Serializable()]
    public class Estado
    {
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

        public bool EstaEnTema(Palabra2 palabra)
        {
            return palabra.temas.Any(t => temas.Any(tt => tt.Equals(t)));
        }

        public SO_Tema[] temas;

        public Longitud[] longitudes = new Longitud[]
        {
            new Longitud("3&4", p => p.Length == 3 || p.Length == 4),
            new Longitud("4&5", p => p.Length == 4 || p.Length == 5),
            new Longitud("5&+", p => p.Length >= 5),
            new Longitud("345...", p => true)
        };

        public int
            indiceCasilleroPersonaje,
            indiceVisibilidad,
            indiceLongitud,
            casilleroActual;
        public bool[] temasActivos;

        public System.Func<string, bool> CondicionLongitud
        {
            get { return longitudes[indiceLongitud].filtro; }
        }

        public Visibilidad visibilidad
        {
            get { return visibilidades[indiceVisibilidad]; }
        }

        public bool PalabraCumpleCondiciones(Palabra2 palabra)
        {
            return CondicionLongitud(palabra.name) && EstaEnTema(palabra);
        }
    }

    public static Tablero instancia;
    public Estado estado;
    public List<Casillero> casilleros;
    public Personaje personaje;

    [Header("Formas y tamaños")]
    public int cantidadALoAncho;
    public float radio, deltaX, deltaAngulo;

    [Space(10f)]
    public Casillero prefabCasillero;
    public CasilleroGrande casilleroGrande;

    private int ciclos = 0;
    private float x0;

    private void Awake()
    {
        instancia = this;

        x0 = -deltaX * .5f * (cantidadALoAncho - 1);
        transform.position = new Vector3(transform.position.x, transform.position.y, radio);

        for (var i = 0; i < 3; i++)
            AgregarCiclo();
    }

    public void ResultadoDado(int dado)
    {
        if (personaje.estado == Personaje.Estado.caminando
            || estado.indiceCasilleroPersonaje + dado >= casilleros.Count)
            return;

        personaje.AgregarPasos(
            casilleros.GetRange(estado.indiceCasilleroPersonaje + 1, dado));
        estado.indiceCasilleroPersonaje += dado;
    }

    private void AgregarCiclo()
    {
        var e = ciclos * CasillerosPorCiclo;

        System.Action<int, int> agregarCasillero = (x, y) =>
        {
            var c = Instantiate(prefabCasillero);
            c.transform.parent = transform;
            c.transform.localEulerAngles = new Vector3(-deltaAngulo * (ciclos * 4 + y), 0f, 0f);
            c.transform.localPosition = new Vector3(x0, 0, 0) + Vector3.right * deltaX * x + c.transform.localRotation * Vector3.back * radio;

            casilleros.Add(c);
            e++;
        };

        for(var i = 0; i < cantidadALoAncho; i++)
            agregarCasillero(i, 0);

        agregarCasillero(cantidadALoAncho - 1, 1);

        for (var i = cantidadALoAncho - 1; i >= 0; i--)
            agregarCasillero(i, 2);

        agregarCasillero(0, 3);
        
        ciclos++;
    }

    private int CasillerosPorCiclo { get { return 2 * (cantidadALoAncho + 1); } }

    private void QuitarCiclo()
    {
        for (var i = cantidadALoAncho; i >= 0; i--, estado.indiceCasilleroPersonaje--)
            Destroy(casilleros[i].gameObject);

        casilleros.RemoveRange(0, cantidadALoAncho + 1);
    }

    public void FinalizarMovimiento()
    {
        casilleroGrande.Abrir(PalabraAlAzar(), estado.visibilidad);
    }

    private Palabra2 PalabraAlAzar()
    {
        var lista = UtilsSO.ListarEnCarpeta<Palabra2>("Assets/Prefabs/ScriptableObjects/Tablero/Palabras").Where(AplicarFiltro).ToList();
        return lista[Random.Range(0, lista.Count)];
    }

    private bool AplicarFiltro(Palabra2 palabra)
    {
        return estado.CondicionLongitud(palabra.name) && estado.EstaEnTema(palabra);
    }

    private void RotacionFinal()
    {

    }

    public void ElegirVisibilidad(int indice)
    {
        estado.indiceVisibilidad = indice;
    }

    public void ElegirLongitud(int indice)
    {
        estado.indiceLongitud = indice;
    }

    public void ActualizarTemas(SelectorOr selector)
    {
        estado.temasActivos = selector.toggles.Select(t => t.isOn).ToArray();
    }

    public void Cerrar()
    {
        Actividades.instancia.CerrarActividad();
    }
}
