using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ruta : MonoBehaviour
{
    public GameObject prefabRuta;
    public Vector3 ultimaPosicion;
    public float diferencia = 0.7071066f;

    public void CrearNuevaRuta()
    {
        print("Crear Ruta Nueva");

        Vector3 nuevaPosicion = Vector3.zero;
        float opcion = Random.Range(0, 100);

        if(opcion < 50)
        {
            nuevaPosicion = new Vector3(ultimaPosicion.x + diferencia, ultimaPosicion.y, ultimaPosicion.z + diferencia);
        }
        else
        {
            nuevaPosicion = new Vector3(ultimaPosicion.x - diferencia, ultimaPosicion.y, ultimaPosicion.z + diferencia);
        }

        GameObject g = Instantiate(prefabRuta, nuevaPosicion, Quaternion.Euler(0, 45, 0));
        ultimaPosicion = g.transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            CrearNuevaRuta();
        }
    }
}
