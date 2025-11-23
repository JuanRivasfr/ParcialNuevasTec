using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

[RequireComponent(typeof(Button))]
public class NeonButton : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [Header("Neon Effect Settings")]
    [SerializeField] private Color normalColor = new Color(0f, 0.5f, 1f, 1f); // Azul neon
    [SerializeField] private Color hoverColor = new Color(0f, 0.8f, 1f, 1f); // Azul brillante
    [SerializeField] private float glowIntensity = 2f;
    [SerializeField] private float transitionSpeed = 5f;

    private Button button;
    private Image buttonImage;
    private TextMeshProUGUI buttonText;
    private Outline outline;
    private Shadow shadow;
    private bool isHovering = false;
    private float currentGlow = 0f;

    private void Awake()
    {
        button = GetComponent<Button>();
        buttonImage = GetComponent<Image>();
        buttonText = GetComponentInChildren<TextMeshProUGUI>();
        
        // Asegurar que hay un Outline
        outline = GetComponent<Outline>();
        if (outline == null)
        {
            outline = gameObject.AddComponent<Outline>();
        }
        
        // Asegurar que hay un Shadow para el efecto glow
        shadow = GetComponent<Shadow>();
        if (shadow == null)
        {
            shadow = gameObject.AddComponent<Shadow>();
        }
        
        SetupNeonStyle();
    }

    private void SetupNeonStyle()
    {
        // Configurar el botón con estilo neon
        if (buttonImage != null)
        {
            buttonImage.color = new Color(0f, 0f, 0f, 0.3f); // Fondo semi-transparente oscuro
        }

        // Configurar Outline
        outline.effectColor = normalColor;
        outline.effectDistance = new Vector2(2f, -2f);
        outline.useGraphicAlpha = true;

        // Configurar Shadow para efecto glow
        if (shadow != null)
        {
            shadow.effectColor = normalColor;
            shadow.effectDistance = new Vector2(0f, 0f);
            shadow.useGraphicAlpha = true;
        }

        // Configurar texto
        if (buttonText != null)
        {
            buttonText.color = Color.white;
        }
    }

    private void Update()
    {
        // Animar el efecto glow
        float targetGlow = isHovering ? glowIntensity : 0f;
        currentGlow = Mathf.Lerp(currentGlow, targetGlow, Time.deltaTime * transitionSpeed);

        // Aplicar el glow
        if (outline != null)
        {
            Color glowColor = Color.Lerp(normalColor, hoverColor, currentGlow / glowIntensity);
            outline.effectColor = glowColor;
            outline.effectDistance = new Vector2(2f + currentGlow, -2f - currentGlow);
        }

        if (shadow != null)
        {
            shadow.effectColor = Color.Lerp(normalColor, hoverColor, currentGlow / glowIntensity) * currentGlow;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovering = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        isHovering = false;
    }
}
