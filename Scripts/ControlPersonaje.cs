using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPersonaje : MonoBehaviour
{
    public Transform comienzoRayo;
    private Animator animator;
    private Rigidbody rb;
    private bool caminarDerecha = true;
    private GameManager gameManager;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        gameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            CambiarDireccion();
        }

        RaycastHit contacto;

        if(!Physics.Raycast(comienzoRayo.position, -transform.up, out contacto, Mathf.Infinity))
        {
            animator.SetTrigger("Cayendo");
        }

        if(transform.position.y < -2)
        {
            gameManager.FinalizarJuego();
        }
    }

    private void FixedUpdate()
    {
        if(!gameManager.juegoIniciado)
        {
            return;
        }else
        {
            animator.SetTrigger("ComienzaJuego");
        }

        rb.transform.position = transform.position + transform.forward * 2 * Time.deltaTime;
    }

    private void CambiarDireccion()
    {
        caminarDerecha = !caminarDerecha;

        if(caminarDerecha)
        {
            transform.rotation = Quaternion.Euler(0,45,0);
        } else
        {
            transform.rotation = Quaternion.Euler(0,-45,0);
        }
    }
}
