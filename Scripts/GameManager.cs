using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool juegoIniciado;

    public void IniciarJuego()
    {
        juegoIniciado = true;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return))
        {
            IniciarJuego();
        }    
    }
}
