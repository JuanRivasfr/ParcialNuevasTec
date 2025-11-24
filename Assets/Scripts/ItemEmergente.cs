using UnityEngine;
using System;

public class ItemEmergente : MonoBehaviour
{
    public float duracionEmerger = 0.5f; // Tiempo para salir del cofre
    public float altura = 1f;            // Qué tanto sube
    public float escalaInicial = 1f;     // Escala al inicio
    public float escalaFinal = 3f;       // Escala final
    public float velocidadFlotacion = 2f;
    public float amplitudFlotacion = 0.1f;

    private Vector3 posicionInicial;
    private float t = 0;
    private bool terminadoEmerger = false;

    // 🔹Evento para avisar cuando la animación termina
    public event Action OnEmergerTerminado;

    void Start()
    {
        // Empieza pequeño
        transform.localScale = Vector3.one * escalaInicial;

        // Guardamos posición inicial
        posicionInicial = transform.position;
    }

    void Update()
    {
        if (!terminadoEmerger)
        {
            // Animación de salida
            t += Time.deltaTime / duracionEmerger;

            float factor = Mathf.SmoothStep(0, 1, t); // Animación suave

            // Escala de 1 → 3
            transform.localScale = Vector3.one * Mathf.Lerp(escalaInicial, escalaFinal, factor);

            // Posición subiendo
            transform.position = Vector3.Lerp(posicionInicial, posicionInicial + Vector3.up * altura, factor);

            // Cuando termina de subir → activar flotación
            if (factor >= 1f)
            {
                terminadoEmerger = true;
                t = 0; // Reset para flotación

                // 🔥 Lanzar el evento para avisar al script de recoger
                OnEmergerTerminado?.Invoke();
            }
        }
        else
        {
            // Movimiento flotante (rebote)
            float offsetY = Mathf.Sin(Time.time * velocidadFlotacion) * amplitudFlotacion;

            transform.position = new Vector3(
                transform.position.x,
                posicionInicial.y + altura + offsetY,
                transform.position.z
            );
        }
    }
}
    