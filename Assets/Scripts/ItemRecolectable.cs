using UnityEngine;
using UnityEngine.SceneManagement;

public class ItemRecolectable : MonoBehaviour
{
    private bool puedeRecoger = false;

    void Start()
    {
        ItemEmergente anim = GetComponent<ItemEmergente>();
        
        // Escuchar el evento cuando termine la animación
        anim.OnEmergerTerminado += ActivarRecoleccion;

        // Desactivar el trigger hasta que la animación termine
        GetComponent<Collider2D>().enabled = false;
    }

    void ActivarRecoleccion()
    {
        puedeRecoger = true;
        GetComponent<Collider2D>().enabled = true;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (puedeRecoger && collision.CompareTag("Player"))
        {
            // Cambiar a la escena que quieras
            SceneManager.LoadScene("DescripcionItem");
        }
    }
}
