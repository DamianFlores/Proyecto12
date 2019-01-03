using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Tema", menuName = "Datos/Tema", order = 1)]
public class SO_Tema : ScriptableObject
{
    public List<Palabra2> palabras;
}
