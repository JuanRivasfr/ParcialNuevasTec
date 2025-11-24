using UnityEngine;

public class Cofre : MonoBehaviour
{
    public Sprite cofreCerrado;
    public Sprite cofreAbierto;
    public GameObject itemPrefab; // Prefab del ítem que saldrá del cofre
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

                jugador.tieneLlave = false;

                // 🔥 Destruir la llave visual si existe
                LlaveMascota llaveVisual = FindObjectOfType<LlaveMascota>();
                if (llaveVisual != null)
                {
                    Destroy(llaveVisual.gameObject);
                }

                // Instanciar item
                SpawnItem();
            }
        }
    }

    private void SpawnItem()
    {
        GameObject item = Instantiate(itemPrefab, transform.position + new Vector3(0, 0.5f, 0), Quaternion.identity);

        // Comienza pequeño
        item.transform.localScale = Vector3.zero;

        StartCoroutine(AnimarItem(item));
    }

    private System.Collections.IEnumerator AnimarItem(GameObject item)
    {
        float tiempo = 0f;
        float duracion = 0.5f;
        Vector3 escalaFinal = new Vector3(1f, 1f, 1f);

        while (tiempo < duracion)
        {
            tiempo += Time.deltaTime;
            float t = tiempo / duracion;

            item.transform.localScale = Vector3.Lerp(Vector3.zero, escalaFinal, t);

            item.transform.position += Vector3.up * Time.deltaTime * 0.5f;

            yield return null;
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
