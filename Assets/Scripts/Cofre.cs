using UnityEngine;

public class Cofre : MonoBehaviour
{
    public Sprite cofreCerrado;
    public Sprite cofreAbierto;
    private SpriteRenderer sr;

    private bool jugadorCerca = false;
    private bool abierto = false;
    private JugadorMovimiento jugador;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = cofreCerrado;
    }

    void Update()
    {
        if (jugadorCerca && !abierto && Input.GetKeyDown(KeyCode.E))
        {
            if (jugador != null && jugador.tieneLlave)
            {
                sr.sprite = cofreAbierto;
                abierto = true;

                // Opcional: quitar la llave al jugador
                jugador.tieneLlave = false;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            jugadorCerca = true;
            jugador = collision.GetComponent<JugadorMovimiento>();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            jugadorCerca = false;
            jugador = null;
        }
    }
}
