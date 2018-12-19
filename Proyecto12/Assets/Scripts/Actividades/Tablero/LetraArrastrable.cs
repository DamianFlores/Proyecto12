using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LetraArrastrable : MonoBehaviour
    //, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public char letra;
    public bool arrastrando;
    public Vector3 posicionOriginal;

    private void Awake()
    {
        posicionOriginal = transform.position;
    }

    private void Start()
    {
        GetComponentInChildren<Text>().text = letra.ToString();
    }

    //public void OnBeginDrag(PointerEventData data)
    //{

    //}

    //public void OnDrag(PointerEventData data)
    //{

    //}

    //public void OnEndDrag(PointerEventData data)
    //{

    //}

    private void Update()
    {
        if (arrastrando)
            if (Soltando)
                Soltar();
            else
                Arrastrar();
        else if (Apretando)
            Agarrar();
        else
            Volver();
    }

    private void Volver()
    {
        transform.Translate(.3f * 
            (Input.mousePosition - transform.position), Space.World);
    }

    private void Arrastrar()
    {
        transform.position = Input.mousePosition;
    }

    private void Agarrar()
    {
        arrastrando = true;
    }

    private void Soltar()
    {
        arrastrando = false;
        //
    }

    private bool Apretando
    {
        get
        {
            //y el mouse está sobre la letra.
            return Input.GetMouseButtonDown(0);
        }
    }

    private bool Soltando
    {
        get
        {
            return arrastrando && Input.GetMouseButtonUp(0);
        }
    }
}
