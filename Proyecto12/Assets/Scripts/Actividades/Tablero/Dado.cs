using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dado : MonoBehaviour {

    public int valor;
    public int lados = 6;
    public float incrementoTiempo;
    public float tiempoMaximo;
    public Tablero tablero;

    public Text texto;

    public void Lanzar()
    {
        StartCoroutine(Rodar());
    }

    private IEnumerator Rodar()
    {
        GetComponent<Button>().interactable = false;
        var tiempo = 0f;
        var duracion = 0f;

        while(tiempo < tiempoMaximo)
        {
            valor = ObtenerNumeroAdyacente(valor);
            texto.text = valor.ToString();

            duracion += incrementoTiempo;
            tiempo += duracion;

            yield return new WaitForSeconds(duracion);
        }

        tablero.ResultadoDado(valor);
        GetComponent<Button>().interactable = true;
    }

    private int ObtenerNumeroAdyacente(int numero)
    {
        int r;
        do
        {
            r = Random.Range(0, lados) + 1;
        }
        while (r == numero || r == 7 - numero);
        return r;
    }
}
