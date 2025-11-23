using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class CircuitBackground : MonoBehaviour
{
    [Header("Circuit Pattern Settings")]
    [SerializeField] private Color gridColor = new Color(0f, 0.3f, 0.6f, 0.3f);
    [SerializeField] private Color lineColor = new Color(0f, 0.5f, 1f, 0.5f);
    [SerializeField] private float gridSize = 50f;
    [SerializeField] private float lineThickness = 2f;
    [SerializeField] private float animationSpeed = 0.5f;

    private Image backgroundImage;
    private Texture2D circuitTexture;
    private Material circuitMaterial;
    private float animationTime = 0f;

    private void Start()
    {
        backgroundImage = GetComponent<Image>();
        CreateCircuitTexture();
        SetupMaterial();
    }

    private void CreateCircuitTexture()
    {
        // Crear una textura para el patrón de circuito
        int textureSize = 512;
        circuitTexture = new Texture2D(textureSize, textureSize, TextureFormat.RGBA32, false);
        
        Color[] pixels = new Color[textureSize * textureSize];
        
        // Crear patrón de cuadrícula
        for (int y = 0; y < textureSize; y++)
        {
            for (int x = 0; x < textureSize; x++)
            {
                float gridX = x % gridSize;
                float gridY = y % gridSize;
                
                // Líneas de cuadrícula
                if (gridX < lineThickness || gridX > gridSize - lineThickness ||
                    gridY < lineThickness || gridY > gridSize - lineThickness)
                {
                    pixels[y * textureSize + x] = gridColor;
                }
                else
                {
                    pixels[y * textureSize + x] = new Color(0f, 0.05f, 0.15f, 1f); // Fondo azul oscuro
                }
            }
        }
        
        circuitTexture.SetPixels(pixels);
        circuitTexture.Apply();
        circuitTexture.wrapMode = TextureWrapMode.Repeat;
    }

    private void SetupMaterial()
    {
        // Crear un material con shader estándar para UI
        circuitMaterial = new Material(Shader.Find("UI/Default"));
        circuitMaterial.mainTexture = circuitTexture;
        circuitMaterial.color = new Color(0f, 0.1f, 0.2f, 1f); // Color base azul oscuro
        
        if (backgroundImage != null)
        {
            backgroundImage.material = circuitMaterial;
            backgroundImage.color = Color.white;
        }
    }

    private void Update()
    {
        // Animar el patrón si es necesario
        animationTime += Time.deltaTime * animationSpeed;
        
        if (circuitMaterial != null && circuitTexture != null)
        {
            // Puedes agregar animación de offset aquí si lo deseas
            // circuitMaterial.mainTextureOffset = new Vector2(animationTime * 0.1f, animationTime * 0.1f);
        }
    }

    private void OnDestroy()
    {
        if (circuitTexture != null)
        {
            Destroy(circuitTexture);
        }
        if (circuitMaterial != null)
        {
            Destroy(circuitMaterial);
        }
    }
}
