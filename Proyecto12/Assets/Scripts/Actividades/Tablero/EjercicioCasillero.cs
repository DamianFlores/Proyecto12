using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EjercicioCasillero : MonoBehaviour {

    private List<RectTransform> origen, destino;
    public RectTransform slotPrefab;
    public float separacionSlots;
    public float yOrigen, yDestino;
    public string palabra;

    private void Start()
    {
        Iniciar(palabra);
    }

    public void Iniciar(string p)
    {
        Limpiar();

        CrearLinea(yOrigen, p.Length, out origen);
        CrearLinea(yDestino, p.Length, out destino);
        CrearArrastrables(p);
    }

    private void Limpiar()
    {
        for (var i = transform.childCount - 1; i >= 0; i--)
            Destroy(transform.GetChild(i).gameObject);
    }

    public void CrearLinea(float y, int largo, out List<RectTransform> lista)
    {
        lista = new List<RectTransform>();
        var x0 = -.5f * separacionSlots * (largo - 1);
        for(var i = 0; i < largo; i++)
        {
            var slot = Instantiate(slotPrefab, transform);
            slot.localPosition = new Vector3(x0 + separacionSlots * i, y, 0f);
            lista.Add(slot);
        }
    }

    private void CrearArrastrables(string p)
    {

    }
}
