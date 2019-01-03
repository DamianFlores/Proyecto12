using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Palabras : MonoBehaviour
{
    public Cumulo[] cumulos;
    public Palabra[] palabras;

    private bool inicializado;

    private void Inicializar()
    {
        cumulos = GetComponentsInChildren<MB_Cumulo>().Select(c => c.cumulo).ToArray();
        palabras = GetComponentsInChildren<MB_Palabra>().Select(p => p.palabra).ToArray();
        inicializado = true;
    }

    public Palabra[] FiltrarPalabras(params System.Func<Palabra, bool>[] filtros)
    {
        var resultado = palabras.Where(t => true);
        foreach (var f in filtros)
            resultado = palabras.Where(f);
        return resultado.ToArray();
    }

    public void AbrirPalabra()
    {
        if (!inicializado)
            Inicializar();

        Debug.Log(palabras.Length);
        var disponibles = palabras.Where(p => Tablero.instancia.estado.CondicionLongitud(p.palabra)).ToArray();
        Debug.Log(disponibles.Length);
        //Debug.Log(disponibles[Random.Range(0, disponibles.Length)]);
    }
}
