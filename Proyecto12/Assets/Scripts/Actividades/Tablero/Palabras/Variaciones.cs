using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CreateAssetMenu(fileName = "Variaciones", menuName = "Variaciones", order = 1)]
public class Variaciones : ScriptableObject
{
    public Palabra[] palabras;
}
