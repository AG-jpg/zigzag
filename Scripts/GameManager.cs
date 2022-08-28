using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public bool juegoIniciado;
    public int puntaje;
    public Text textoPuntaje;
    public Text puntajeMaximoTexto;

    private void Awake() 
    {
        //Obtener puntaje máximo
        puntajeMaximoTexto.text = "Best: " + ObtenerPuntajeMaximo().ToString();
    }

    public void IniciarJuego()
    {
        juegoIniciado = true;
        FindObjectOfType<Ruta>().IniciarConstruccion();
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

    public void AumentarPuntaje()
    {
        puntaje++;
        textoPuntaje.text = puntaje.ToString();

        if(puntaje > ObtenerPuntajeMaximo())
        {
            PlayerPrefs.SetInt("PuntajeMaximo", puntaje);
            puntajeMaximoTexto.text = "Best: " + puntaje.ToString();
        }
    }

    public int ObtenerPuntajeMaximo()
    {
        int i = PlayerPrefs.GetInt("PuntajeMaximo");
        return i;
    }
}
