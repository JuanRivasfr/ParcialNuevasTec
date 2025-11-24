using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

[ExecuteInEditMode]
public class MainMenuInitializer : MonoBehaviour
{
    [Header("Auto Setup")]
    [SerializeField] private bool autoSetupOnStart = true;
    [SerializeField] private bool setupComplete = false;

    private void Start()
    {
        if (autoSetupOnStart && !setupComplete)
        {
            SetupMainMenu();
            setupComplete = true;
        }
    }

    [ContextMenu("Setup Main Menu")]
    public void SetupMainMenu()
    {
        // Verificar si ya existe un Canvas
        Canvas existingCanvas = FindObjectOfType<Canvas>();
        if (existingCanvas != null && existingCanvas.name == "Canvas")
        {
            Debug.Log("Main Menu ya está configurado.");
            return;
        }

        // Crear Canvas
        GameObject canvasObj = new GameObject("Canvas");
        Canvas canvas = canvasObj.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        CanvasScaler scaler = canvasObj.AddComponent<CanvasScaler>();
        scaler.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
        scaler.referenceResolution = new Vector2(1920, 1080);
        canvasObj.AddComponent<GraphicRaycaster>();

        // Crear EventSystem si no existe
        if (FindObjectOfType<UnityEngine.EventSystems.EventSystem>() == null)
        {
            GameObject eventSystemObj = new GameObject("EventSystem");
            eventSystemObj.AddComponent<UnityEngine.EventSystems.EventSystem>();
            eventSystemObj.AddComponent<UnityEngine.EventSystems.StandaloneInputModule>();
        }

        // Crear fondo
        GameObject backgroundObj = new GameObject("Background");
        backgroundObj.transform.SetParent(canvasObj.transform, false);
        Image bgImage = backgroundObj.AddComponent<Image>();
        bgImage.color = new Color(0f, 0.1f, 0.2f, 1f); // Azul oscuro
        RectTransform bgRect = backgroundObj.GetComponent<RectTransform>();
        bgRect.anchorMin = Vector2.zero;
        bgRect.anchorMax = Vector2.one;
        bgRect.sizeDelta = Vector2.zero;
        bgRect.anchoredPosition = Vector2.zero;
        backgroundObj.AddComponent<CircuitBackground>();

        // Crear contenedor del título
        GameObject titleContainer = new GameObject("TitleContainer");
        titleContainer.transform.SetParent(canvasObj.transform, false);
        RectTransform titleRect = titleContainer.AddComponent<RectTransform>();
        titleRect.anchorMin = new Vector2(0.5f, 0.8f);
        titleRect.anchorMax = new Vector2(0.5f, 0.8f);
        titleRect.pivot = new Vector2(0.5f, 0.5f);
        titleRect.sizeDelta = new Vector2(800, 200);
        titleRect.anchoredPosition = Vector2.zero;

        // Título principal
        GameObject titleMain = new GameObject("TitleMain");
        titleMain.transform.SetParent(titleContainer.transform, false);
        RectTransform titleMainRect = titleMain.AddComponent<RectTransform>();
        TextMeshProUGUI titleText = titleMain.AddComponent<TextMeshProUGUI>();
        titleText.text = "CODE FIGHTERS";
        titleText.fontSize = 72;
        titleText.alignment = TextAlignmentOptions.Center;
        titleText.color = new Color(0f, 0.8f, 1f, 1f); // Azul neon
        titleMainRect.anchorMin = new Vector2(0.5f, 0.5f);
        titleMainRect.anchorMax = new Vector2(0.5f, 0.5f);
        titleMainRect.pivot = new Vector2(0.5f, 0.5f);
        titleMainRect.sizeDelta = new Vector2(800, 100);
        titleMainRect.anchoredPosition = new Vector2(0, 30);

        // Subtítulo
        GameObject subtitle = new GameObject("Subtitle");
        subtitle.transform.SetParent(titleContainer.transform, false);
        RectTransform subtitleRect = subtitle.AddComponent<RectTransform>();
        TextMeshProUGUI subtitleText = subtitle.AddComponent<TextMeshProUGUI>();
        subtitleText.text = "BUG WARS";
        subtitleText.fontSize = 48;
        subtitleText.alignment = TextAlignmentOptions.Center;
        subtitleText.color = Color.white;
        subtitleRect.anchorMin = new Vector2(0.5f, 0.5f);
        subtitleRect.anchorMax = new Vector2(0.5f, 0.5f);
        subtitleRect.pivot = new Vector2(0.5f, 0.5f);
        subtitleRect.sizeDelta = new Vector2(800, 60);
        subtitleRect.anchoredPosition = new Vector2(0, -40);

        // Crear contenedor de botones
        GameObject buttonsContainer = new GameObject("ButtonsContainer");
        buttonsContainer.transform.SetParent(canvasObj.transform, false);
        RectTransform buttonsRect = buttonsContainer.AddComponent<RectTransform>();
        buttonsRect.anchorMin = new Vector2(0.5f, 0.5f);
        buttonsRect.anchorMax = new Vector2(0.5f, 0.5f);
        buttonsRect.pivot = new Vector2(0.5f, 0.5f);
        buttonsRect.sizeDelta = new Vector2(300, 400);
        buttonsRect.anchoredPosition = new Vector2(0, -50);

        // Crear botones
        string[] buttonNames = { "Iniciar", "Continuar", "Historia", "Tutorial", "Configuración", "Salir" };
        float buttonSpacing = 60f;
        float startY = (buttonNames.Length - 1) * buttonSpacing / 2f;

        Button[] createdButtons = new Button[buttonNames.Length];

        for (int i = 0; i < buttonNames.Length; i++)
        {
            GameObject buttonObj = new GameObject($"Button_{buttonNames[i]}");
            buttonObj.transform.SetParent(buttonsContainer.transform, false);

            RectTransform buttonRect = buttonObj.AddComponent<RectTransform>();
            buttonRect.anchorMin = new Vector2(0.5f, 0.5f);
            buttonRect.anchorMax = new Vector2(0.5f, 0.5f);
            buttonRect.pivot = new Vector2(0.5f, 0.5f);
            buttonRect.sizeDelta = new Vector2(280, 50);
            buttonRect.anchoredPosition = new Vector2(0, startY - i * buttonSpacing);

            Image buttonImage = buttonObj.AddComponent<Image>();
            buttonImage.color = new Color(0f, 0f, 0f, 0.5f); // Fondo más visible

            Button button = buttonObj.AddComponent<Button>();
            button.targetGraphic = buttonImage;

            // Agregar componente NeonButton
            buttonObj.AddComponent<NeonButton>();

            // Texto del botón
            GameObject buttonTextObj = new GameObject("Text");
            buttonTextObj.transform.SetParent(buttonObj.transform, false);
            RectTransform buttonTextRect = buttonTextObj.AddComponent<RectTransform>();
            buttonTextRect.anchorMin = Vector2.zero;
            buttonTextRect.anchorMax = Vector2.one;
            buttonTextRect.sizeDelta = Vector2.zero;
            buttonTextRect.anchoredPosition = Vector2.zero;
            
            TextMeshProUGUI buttonText = buttonTextObj.AddComponent<TextMeshProUGUI>();
            buttonText.text = buttonNames[i];
            buttonText.fontSize = 24;
            buttonText.alignment = TextAlignmentOptions.Center;
            buttonText.color = Color.white;
            buttonText.raycastTarget = false;

            createdButtons[i] = button;
        }

        // Crear o encontrar MainMenuController
        MainMenuController controller = FindObjectOfType<MainMenuController>();
        if (controller == null)
        {
            GameObject controllerObj = new GameObject("MainMenuController");
            controller = controllerObj.AddComponent<MainMenuController>();
        }

        // Asignar referencias de botones usando SerializedObject
        #if UNITY_EDITOR
        SerializedObject serializedController = new SerializedObject(controller);
        serializedController.FindProperty("startButton").objectReferenceValue = createdButtons[0];
        serializedController.FindProperty("continueButton").objectReferenceValue = createdButtons[1];
        serializedController.FindProperty("historiaButton").objectReferenceValue = createdButtons[2];
        serializedController.FindProperty("tutorialButton").objectReferenceValue = createdButtons[3];
        serializedController.FindProperty("settingsButton").objectReferenceValue = createdButtons[4];
        serializedController.FindProperty("exitButton").objectReferenceValue = createdButtons[5];
        serializedController.ApplyModifiedProperties();
        #else
        // En runtime, asignar directamente
        controller.startButton = createdButtons[0];
        controller.continueButton = createdButtons[1];
        controller.historiaButton = createdButtons[2];
        controller.tutorialButton = createdButtons[3];
        controller.settingsButton = createdButtons[4];
        controller.exitButton = createdButtons[5];
        #endif

        Debug.Log("Main Menu configurado exitosamente!");
    }
}
