using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPersonaje : MonoBehaviour
{
    private Rigidbody rb;
    private bool caminarDerecha = true;

    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            CambiarDireccion();
        }
    }

    private void FixedUpdate()
    {
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
