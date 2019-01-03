using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Palabra", menuName = "Datos/Palabra", order = 1)]
public class Palabra2 : ScriptableObject
{
    public Sprite imagen;
    public List<Variaciones> grupos;
    public List<SO_Tema> temas;
}
