using UnityEngine;

public class LlaveMascota : MonoBehaviour
{
    public Transform jugador;             // referencia al jugador
    public float margenCabeza = 0.5f;     // cuánto por encima de la cabeza
    public float suavizado = 5f;          // suavidad para seguir al jugador
    public float amplitudFlotante = 0.2f; // movimiento vertical
    public float velocidadFlotante = 2f;  // velocidad del movimiento vertical
    public float velocidadRotacion = 180f; // grados por segundo

    private SpriteRenderer srJugador;

    void Start()
    {
        if (jugador == null)
            jugador = GameObject.FindWithTag("Player").transform;

        srJugador = jugador.GetComponentInChildren<SpriteRenderer>();
    }

    void Update()
    {
        if (jugador == null || srJugador == null) return;

        // Rotación continua
        transform.Rotate(0, 0, velocidadRotacion * Time.deltaTime);

        // Movimiento vertical flotante
        float offsetY = Mathf.Sin(Time.time * velocidadFlotante) * amplitudFlotante;

        // Altura dinámica: top del sprite + margen
        float alturaCabeza = srJugador.bounds.max.y + margenCabeza;

        // Posición objetivo
        Vector3 objetivo = new Vector3(jugador.position.x, alturaCabeza + offsetY, jugador.position.z);

        // Seguir suavemente al jugador
        transform.position = Vector3.Lerp(transform.position, objetivo, Time.deltaTime * suavizado);
    }
}
