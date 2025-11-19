using UnityEngine;

public class Moneda : MonoBehaviour
{
    public int valor = 1;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Entré al trigger con: " + collision.name);
        if (collision.CompareTag("Player"))
        {
            JugadorMovimiento jugador = collision.GetComponent<JugadorMovimiento>();
            if (jugador != null)
            {
                jugador.AgregarMonedas(valor);
            }

            Destroy(gameObject);
        }
    }

}
