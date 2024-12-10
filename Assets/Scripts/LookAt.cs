using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAt : MonoBehaviour
{
    Transform ubi_obj_a_mirar;

    P2_CalcularDistancia auxComponenteDistance;


    private void Awake()
    {
        ubi_obj_a_mirar = GameObject.Find("Jugador").GetComponent<Transform>();
    }

    // Start is called before the first frame update
    void Start()
    {
        auxComponenteDistance = GetComponent<P2_CalcularDistancia>();
    }

    // Update is called once per frame
    void Update()
    {
        //transform.LookAt(ubi_obj_a_mirar.position);
        float distanciaAlEnemigo = auxComponenteDistance.getDistance();
        if (distanciaAlEnemigo < 3.5f)
        {


            float valY = ubi_obj_a_mirar.position.y;

            if (valY > 3.0)
            {
                transform.LookAt(new Vector3(
                    ubi_obj_a_mirar.position.x,
                    3.0f,
                    ubi_obj_a_mirar.position.z));
            }
        }
        else
        {
            transform.LookAt(ubi_obj_a_mirar.position);
        }
    }
}
