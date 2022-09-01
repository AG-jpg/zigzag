using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPersonaje : MonoBehaviour
{
    public Transform comienzoRayo;
    public GameObject efectoCristal;
    private Animator animator;
    private Rigidbody rb;
    private bool caminarDerecha = true;
    private GameManager gameManager;
    public AudioSource chimes;
    public AudioSource fall;

    // Start is called before the first frame update
    void Start()
    {
        chimes = GetComponent<AudioSource>();
        fall = GetComponent<AudioSource>();
    }

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
            fall.Play();
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
        if(!gameManager.juegoIniciado)
        {
            return;
        }

        caminarDerecha = !caminarDerecha;

        if(caminarDerecha)
        {
            transform.rotation = Quaternion.Euler(0,45,0);
        } else
        {
            transform.rotation = Quaternion.Euler(0,-45,0);
        }
    }

    private void OnTriggerEnter(Collider other) 
    {
        if(other.tag == "Crystal")
        {
            gameManager.AumentarPuntaje();
            chimes.Play();

            GameObject g = Instantiate(efectoCristal, comienzoRayo.transform.position, Quaternion.identity);
            Destroy(g, 2);
            Destroy(other.gameObject);
        }
    }
}
