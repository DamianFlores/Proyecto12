using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour {

    public enum Estado { quieto, caminando };

    public Animator animator;
    private Estado _estado;
    public float velocidad = .05f;
    private Vector2 velocidad2;
    private List<Casillero> casillerosPendientes;
    public Tablero tablero;
    public int indiceActual = 0;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        casillerosPendientes = new List<Casillero>();
    }

    private void Update()
    {
        if (estado == Estado.caminando)
            Caminar();
    }

    private void Caminar()
    {
        if (LlegaACasillero)
            LlegarACasillero();
        else
            transform.Translate(Time.deltaTime * velocidad2);
    }

    private void LlegarACasillero()
    {
        transform.position = casillerosPendientes[0].transform.position;
        indiceActual = casillerosPendientes[0].indice;
        casillerosPendientes.RemoveAt(0);

        if (casillerosPendientes.Count > 1)
            Avanzar();
        else
            FinalizarMovimiento();
    }

    private void FinalizarMovimiento()
    {
        Debug.Log("FinalizarMovimiento");
        estado = Estado.quieto;
        tablero.casilleros[indiceActual].Accionar();
    }

    private bool LlegaACasillero
    {
        get
        {
            return
                Vector2.SqrMagnitude(transform.position - casillerosPendientes[0].transform.position)
                 <
                Vector2.SqrMagnitude(Time.deltaTime * velocidad2);
        }
    }

    public void AgregarPasos(List<Casillero> casilleros)
    {
        casillerosPendientes.AddRange(casilleros);
        Avanzar();
    }

    private void Avanzar()
    {
        velocidad2 = velocidad * (casillerosPendientes[0].transform.position - transform.position).normalized;
        estado = Estado.caminando;
    }

    public Estado estado
    {
        get { return _estado; }
        set
        {
            if (value == estado)
                return;

            _estado = value;
            animator.SetBool("caminando", value == Estado.caminando);
        }
    }
}
