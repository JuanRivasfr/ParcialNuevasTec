using UnityEngine;
using TMPro;
using System.Collections;

public class TextoEscritura : MonoBehaviour
{
    public TMP_Text textoUI;
    [TextArea]
    public string textoMostrar;

    public float velocidad = 0.03f; // tiempo entre letras

    void Start()
    {
        StartCoroutine(Escribir());
    }

    IEnumerator Escribir()
    {
        textoUI.text = "";

        foreach (char letra in textoMostrar)
        {
            textoUI.text += letra;
            yield return new WaitForSeconds(velocidad);
        }
    }
}
