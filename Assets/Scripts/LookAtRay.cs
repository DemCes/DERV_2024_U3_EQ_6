using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtRay : MonoBehaviour
{
    [SerializeField] Transform ubi_obj_a_mirar; // Jugador
    P2_CalcularDistancia auxComponenteDistance;

    void Awake()
    {
        ubi_obj_a_mirar = GameObject.Find("Jugador").GetComponent<Transform>();
    }

    void Start()
    {
        auxComponenteDistance = GetComponent<P2_CalcularDistancia>();
    }

    void Update()
    {
        float distanciaAlEnemigo = auxComponenteDistance.getDistance();

        // Comprobamos si está dentro del rango para "mirar" (3.5f) y hacemos Raycast
        if (distanciaAlEnemigo < 8.5f)
        {
            // Realizamos Raycast para comprobar si hay algo bloqueando la vista
            Vector3 direccion = ubi_obj_a_mirar.position - transform.position;
            direccion = direccion.normalized;
            RaycastHit hit;

            if (Physics.Raycast(transform.position, direccion, out hit, distanciaAlEnemigo))
            {
                Debug.DrawRay(transform.position, direccion * hit.distance, Color.green, 0.1f);

                // Si el Raycast detecta al jugador sin obstáculos
                if (hit.transform == ubi_obj_a_mirar)
                {
                    Debug.Log("El enemigo ve al jugador y está dentro del rango.");

                    // Comprobamos si el valor en Y del jugador está por encima de 3.0 para ajustar la altura
                    float valY = ubi_obj_a_mirar.position.y;
                    if (valY > 3.0f)
                    {
                        transform.LookAt(new Vector3(
                            ubi_obj_a_mirar.position.x,
                            3.0f,  // Limitamos la altura de "mirar"
                            ubi_obj_a_mirar.position.z));
                    }
                    else
                    {
                        transform.LookAt(ubi_obj_a_mirar.position); // Mirar directamente al jugador
                    }
                }
                else
                {
                    Debug.Log("El enemigo no ve al jugador (hay algo bloqueando la visión).");
                }
            }
        }
        else
        {

            Debug.Log("El jugador está fuera del rango.");
        }
    }
}