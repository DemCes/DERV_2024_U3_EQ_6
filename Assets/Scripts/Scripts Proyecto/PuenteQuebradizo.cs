using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuenteQuebradizo : MonoBehaviour
{
    public float tiempoParaDesaparecer = 2.0f; // Tiempo antes de que el puente desaparezca
    public float transparencia = 0.5f; // Nivel de transparencia al tocar el puente
    public float tiempoParaReaparecer = 5.0f; // Tiempo para que el puente reaparezca después de desaparecer

    private bool tocado = false;
    private Renderer puenteRenderer;
    private Collider puenteCollider;
    private Color colorOriginal;
    private float tiempoTranscurrido = 0.0f;
    private bool puenteDesaparecido = false;

    void Start()
    {
        puenteRenderer = GetComponent<Renderer>();
        puenteCollider = GetComponent<Collider>();
        colorOriginal = puenteRenderer.material.color; // Guardamos el color original del puente
    }

    void OnCollisionEnter(Collision other)
    {
        // Comprobamos si es el jugador quien toca el puente
        if (other.gameObject.CompareTag("Player") && !tocado)
        {
            tocado = true;
            // Cambiamos la transparencia del material del puente
            Color colorTransparente = new Color(colorOriginal.r, colorOriginal.g, colorOriginal.b, transparencia);
            puenteRenderer.material.color = colorTransparente;
        }
    }

    void Update()
    {
        // Si el puente ha sido tocado, empezamos a contar el tiempo
        if (tocado && !puenteDesaparecido)
        {
            tiempoTranscurrido += Time.deltaTime;

            // Después de que pase el tiempo especificado, desactivamos el puente
            if (tiempoTranscurrido >= tiempoParaDesaparecer)
            {
                DesaparecerPuente();
            }
        }

        // Si el puente ha desaparecido, contamos el tiempo para que reaparezca
        if (puenteDesaparecido)
        {
            tiempoTranscurrido += Time.deltaTime;

            // Después de que pase el tiempo para reaparecer, activamos nuevamente el puente
            if (tiempoTranscurrido >= tiempoParaReaparecer)
            {
                ReaparecerPuente();
            }
        }
    }

    void DesaparecerPuente()
    {
        // Desactivamos el renderizador y el collider, pero dejamos el objeto activo
        puenteRenderer.enabled = false;
        puenteCollider.enabled = false;
        tiempoTranscurrido = 0.0f;
        puenteDesaparecido = true;
    }

    void ReaparecerPuente()
    {
        // Reaparecemos el puente, restauramos el color original y reseteamos las variables
        puenteRenderer.enabled = true;
        puenteCollider.enabled = true;
        puenteRenderer.material.color = colorOriginal;
        tocado = false;
        tiempoTranscurrido = 0.0f;
        puenteDesaparecido = false;
    }
}
