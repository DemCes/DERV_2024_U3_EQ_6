using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{

    [SerializeField] Transform Jugador;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direccion = Jugador.position - transform.position;
        direccion = direccion.normalized; // normalizamos la dirección
        RaycastHit hit;
        if (Physics.Raycast(transform.position, direccion, out hit, 10f))
        {
            Debug.Log("Collisiona con un objeto");
            Debug.DrawRay(transform.position, direccion * hit.distance, Color.green);
        }
        else
        {
            Debug.Log("No colisiona");
            Debug.DrawRay(transform.position, direccion * 10f, Color.red);
        }
    }
}
