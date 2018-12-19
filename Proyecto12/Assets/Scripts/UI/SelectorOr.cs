using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class SelectorOr : MonoBehaviour {

    public Toggle[] toggles;

	public void CambiarValor(Toggle t)
    {
        if(toggles.All(tt => !tt.isOn))
        {
            t.isOn = true;
            return;
        }


    }
}
