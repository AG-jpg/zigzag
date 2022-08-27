using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public void FinalizarJuego()
    {
        SceneManager.LoadScene(0);
    }
}
