using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuPrincipal : MonoBehaviour
{
    // Llama a esta función para iniciar el juego
    public void IniciarJuego()
    {
        // Carga la escena SampleScene
        SceneManager.LoadScene("SampleScene");
    }


    // Llama a esta función para salir del juego
    public void SalirJuego()
    {
        Debug.Log("Saliendo del juego...");
        Application.Quit(); // Solo funciona en build, en editor solo mostrará el debug
    }
}
