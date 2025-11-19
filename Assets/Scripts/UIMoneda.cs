using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUDMonedas : MonoBehaviour
{
    public TextMeshProUGUI textoMonedas;

    public void ActualizarMonedas(int cantidad)
    {
        textoMonedas.text = ":" + cantidad;
    }
}
