using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Tablero : MonoBehaviour {

    [System.Serializable()]
    public class Segmento
    {
        public enum Direccion { derecha, abajo, izquierda, arriba };
        public static Vector3[] direccionAVector3 = new Vector3[]
        {
            Vector3.right, Vector3.down, Vector3.left, Vector3.up
        };

        public int longitud;
        public Direccion direccion;
    }

    public Segmento[] segmentos;
    public float separacion = 1f;
    public Vector2 origenPrimerCasillero;
    private Casillero primerCasillero;
    public List<Casillero> casilleros;
    public Personaje personaje;

    private void Awake()
    {
        primerCasillero = GetComponentInChildren<Casillero>();
        primerCasillero.transform.position = origenPrimerCasillero * separacion;

        var posicionAnterior = primerCasillero.transform.position;
        foreach(var s in segmentos)
            for(var i = 0; i < s.longitud; i++)
            {
                var c = Instantiate(primerCasillero);
                posicionAnterior = c.transform.position =
                    posicionAnterior + separacion * Segmento.direccionAVector3[(int)s.direccion];
                c.transform.parent = transform;
            }
        casilleros = GetComponentsInChildren<Casillero>().ToList();
        for (var i = 0; i < casilleros.Count; i++)
            casilleros[i].indice = i;
    }

    public void ResultadoDado(int dado)
    {
        if (personaje.estado == Personaje.Estado.caminando)
            return;

        if (personaje.indiceActual + dado >= casilleros.Count)
            return;

        var casillerosAMover = casilleros.GetRange(personaje.indiceActual + 1, dado);
        personaje.AgregarPasos(casillerosAMover);
    }
}
