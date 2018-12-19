using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dado : MonoBehaviour {

    public int valor;
    public int lados = 6;
    public Tablero tablero;

    public Text texto;

    public void Lanzar()
    {
        valor = Random.Range(0, lados) + 1;
        texto.text = valor.ToString();
        tablero.ResultadoDado(valor);
    }
}
