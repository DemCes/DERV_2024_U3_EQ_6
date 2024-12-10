using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P5_Fuerzas_Intro : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] float velocidadFuerza;

    float tiempo_en_pantalla;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        tiempo_en_pantalla = 0;

        //rb.AddForce(Transform.right * velocidadFuerza, ForceMode.Impulse); Considera masa
        //rb.AddForce(transform.right * velocidadFuerza, ForceMode.VelocityChange); No considera masa
        rb.AddForce(transform.right * velocidadFuerza, ForceMode.VelocityChange);
    }

    private void Update()
    {
        tiempo_en_pantalla += Time.fixedDeltaTime;
        if(tiempo_en_pantalla > 1.5f)
        {
            tiempo_en_pantalla = 0;
            gameObject.SetActive(false);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        rb.AddForce(velocidadFuerza * Time.fixedDeltaTime * transform.forward , ForceMode.Impulse); //Considera la masa
    }
}
