using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuSetup : EditorWindow
{
    [MenuItem("Tools/Setup Main Menu")]
    public static void SetupMainMenu()
    {
        // Obtener la escena activa
        Scene activeScene = SceneManager.GetActiveScene();
        if (!activeScene.name.Contains("MainMenu"))
        {
            Debug.LogWarning("La escena activa no es MainMenu. Configurando de todas formas...");
        }

        // Limpiar objetos existentes si es necesario
        GameObject existingCanvas = GameObject.Find("Canvas");
        if (existingCanvas != null)
        {
            DestroyImmediate(existingCanvas);
        }

        // Crear Canvas
        GameObject canvasObj = new GameObject("Canvas");
        Canvas canvas = canvasObj.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay;
        canvasObj.AddComponent<CanvasScaler>();
        canvasObj.AddComponent<GraphicRaycaster>();

        // Crear EventSystem si no existe
        if (GameObject.Find("EventSystem") == null)
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
        RectTransform titleRect = titleContainer.GetComponent<RectTransform>();
        titleRect.anchorMin = new Vector2(0.5f, 0.8f);
        titleRect.anchorMax = new Vector2(0.5f, 0.8f);
        titleRect.pivot = new Vector2(0.5f, 0.5f);
        titleRect.sizeDelta = new Vector2(800, 200);
        titleRect.anchoredPosition = Vector2.zero;

        // Título principal
        GameObject titleMain = new GameObject("TitleMain");
        titleMain.transform.SetParent(titleContainer.transform, false);
        TextMeshProUGUI titleText = titleMain.AddComponent<TextMeshProUGUI>();
        titleText.text = "CODE FIGHTERS";
        titleText.fontSize = 72;
        titleText.alignment = TextAlignmentOptions.Center;
        titleText.color = new Color(0f, 0.8f, 1f, 1f); // Azul neon
        RectTransform titleMainRect = titleMain.GetComponent<RectTransform>();
        titleMainRect.anchorMin = new Vector2(0.5f, 0.5f);
        titleMainRect.anchorMax = new Vector2(0.5f, 0.5f);
        titleMainRect.pivot = new Vector2(0.5f, 0.5f);
        titleMainRect.sizeDelta = new Vector2(800, 100);
        titleMainRect.anchoredPosition = new Vector2(0, 30);

        // Subtítulo
        GameObject subtitle = new GameObject("Subtitle");
        subtitle.transform.SetParent(titleContainer.transform, false);
        TextMeshProUGUI subtitleText = subtitle.AddComponent<TextMeshProUGUI>();
        subtitleText.text = "BUG WARS";
        subtitleText.fontSize = 48;
        subtitleText.alignment = TextAlignmentOptions.Center;
        subtitleText.color = Color.white;
        RectTransform subtitleRect = subtitle.GetComponent<RectTransform>();
        subtitleRect.anchorMin = new Vector2(0.5f, 0.5f);
        subtitleRect.anchorMax = new Vector2(0.5f, 0.5f);
        subtitleRect.pivot = new Vector2(0.5f, 0.5f);
        subtitleRect.sizeDelta = new Vector2(800, 60);
        subtitleRect.anchoredPosition = new Vector2(0, -40);

        // Crear contenedor de botones
        GameObject buttonsContainer = new GameObject("ButtonsContainer");
        buttonsContainer.transform.SetParent(canvasObj.transform, false);
        RectTransform buttonsRect = buttonsContainer.GetComponent<RectTransform>();
        buttonsRect.anchorMin = new Vector2(0.5f, 0.5f);
        buttonsRect.anchorMax = new Vector2(0.5f, 0.5f);
        buttonsRect.pivot = new Vector2(0.5f, 0.5f);
        buttonsRect.sizeDelta = new Vector2(300, 400);
        buttonsRect.anchoredPosition = new Vector2(0, -50);

        // Crear botones
        string[] buttonNames = { "Iniciar", "Continuar", "Historia", "Tutorial", "Configuración", "Salir" };
        float buttonSpacing = 60f;
        float startY = (buttonNames.Length - 1) * buttonSpacing / 2f;

        for (int i = 0; i < buttonNames.Length; i++)
        {
            GameObject buttonObj = new GameObject($"Button_{buttonNames[i]}");
            buttonObj.transform.SetParent(buttonsContainer.transform, false);

            Image buttonImage = buttonObj.AddComponent<Image>();
            buttonImage.color = new Color(0f, 0f, 0f, 0.3f); // Fondo semi-transparente

            Button button = buttonObj.AddComponent<Button>();
            button.targetGraphic = buttonImage;

            // Agregar componente NeonButton
            buttonObj.AddComponent<NeonButton>();

            RectTransform buttonRect = buttonObj.GetComponent<RectTransform>();
            buttonRect.anchorMin = new Vector2(0.5f, 0.5f);
            buttonRect.anchorMax = new Vector2(0.5f, 0.5f);
            buttonRect.pivot = new Vector2(0.5f, 0.5f);
            buttonRect.sizeDelta = new Vector2(280, 50);
            buttonRect.anchoredPosition = new Vector2(0, startY - i * buttonSpacing);

            // Texto del botón
            GameObject buttonTextObj = new GameObject("Text");
            buttonTextObj.transform.SetParent(buttonObj.transform, false);
            TextMeshProUGUI buttonText = buttonTextObj.AddComponent<TextMeshProUGUI>();
            buttonText.text = buttonNames[i];
            buttonText.fontSize = 24;
            buttonText.alignment = TextAlignmentOptions.Center;
            buttonText.color = Color.white;
            RectTransform buttonTextRect = buttonTextObj.GetComponent<RectTransform>();
            buttonTextRect.anchorMin = Vector2.zero;
            buttonTextRect.anchorMax = Vector2.one;
            buttonTextRect.sizeDelta = Vector2.zero;
            buttonTextRect.anchoredPosition = Vector2.zero;
        }

        // Crear MainMenuController
        GameObject controllerObj = new GameObject("MainMenuController");
        MainMenuController controller = controllerObj.AddComponent<MainMenuController>();

        // Asignar referencias de botones
        Button[] buttons = buttonsContainer.GetComponentsInChildren<Button>();
        if (buttons.Length >= 6)
        {
            SerializedObject serializedController = new SerializedObject(controller);
            serializedController.FindProperty("startButton").objectReferenceValue = buttons[0];
            serializedController.FindProperty("continueButton").objectReferenceValue = buttons[1];
            serializedController.FindProperty("historiaButton").objectReferenceValue = buttons[2];
            serializedController.FindProperty("tutorialButton").objectReferenceValue = buttons[3];
            serializedController.FindProperty("settingsButton").objectReferenceValue = buttons[4];
            serializedController.FindProperty("exitButton").objectReferenceValue = buttons[5];
            serializedController.ApplyModifiedProperties();
        }

        Debug.Log("Main Menu configurado exitosamente!");
    }
}
