using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenuController : MonoBehaviour
{
    [Header("Scene Names")]
    [SerializeField] private string startSceneName = "BattleScene";
    [SerializeField] private string continueSceneName = "BattleScene";
    [SerializeField] private string historiaSceneName = "IntroNarrativa";
    [SerializeField] private string tutorialSceneName = "TrainingProtocol";
    [SerializeField] private string settingsSceneName = "Settings";

    [Header("UI Buttons")]
    public Button startButton;
    public Button continueButton;
    public Button historiaButton;
    public Button tutorialButton;
    public Button settingsButton;
    public Button exitButton;

    private void Start()
    {
        // Asignar listeners a los botones
        if (startButton != null)
            startButton.onClick.AddListener(OnStartClicked);
        
        if (continueButton != null)
            continueButton.onClick.AddListener(OnContinueClicked);
        
        if (historiaButton != null)
            historiaButton.onClick.AddListener(OnHistoriaClicked);
        
        if (tutorialButton != null)
            tutorialButton.onClick.AddListener(OnTutorialClicked);
        
        if (settingsButton != null)
            settingsButton.onClick.AddListener(OnSettingsClicked);
        
        if (exitButton != null)
            exitButton.onClick.AddListener(OnExitClicked);
    }

    public void OnStartClicked()
    {
        Debug.Log("Iniciar juego");
        if (SceneRouter.Instance != null)
        {
            SceneRouter.Instance.StartNewGame();
        }
        else
        {
            LoadScene(startSceneName);
        }
    }

    public void OnContinueClicked()
    {
        Debug.Log("Continuar partida");
        // Cargar el último checkpoint guardado (CiberDojo)
        if (SceneRouter.Instance != null)
        {
            SceneRouter.Instance.LoadCiberDojo();
        }
        else
        {
            LoadScene(continueSceneName);
        }
    }

    public void OnHistoriaClicked()
    {
        Debug.Log("Abrir historia");
        if (SceneRouter.Instance != null)
        {
            SceneRouter.Instance.LoadIntroNarrativa();
        }
        else
        {
            LoadScene(historiaSceneName);
        }
    }

    public void OnTutorialClicked()
    {
        Debug.Log("Abrir tutorial");
        if (SceneRouter.Instance != null)
        {
            SceneRouter.Instance.LoadTrainingProtocol();
        }
        else
        {
            LoadScene(tutorialSceneName);
        }
    }

    public void OnSettingsClicked()
    {
        Debug.Log("Abrir configuración");
        if (SceneRouter.Instance != null)
        {
            SceneRouter.Instance.LoadSettings();
        }
        else
        {
            LoadScene(settingsSceneName);
        }
    }

    public void OnExitClicked()
    {
        Debug.Log("Salir del juego");
        
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    private void LoadScene(string sceneName)
    {
        if (!string.IsNullOrEmpty(sceneName))
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            Debug.LogWarning($"Nombre de escena no válido: {sceneName}");
        }
    }

    private void OnDestroy()
    {
        // Limpiar listeners
        if (startButton != null)
            startButton.onClick.RemoveAllListeners();
        
        if (continueButton != null)
            continueButton.onClick.RemoveAllListeners();
        
        if (historiaButton != null)
            historiaButton.onClick.RemoveAllListeners();
        
        if (tutorialButton != null)
            tutorialButton.onClick.RemoveAllListeners();
        
        if (settingsButton != null)
            settingsButton.onClick.RemoveAllListeners();
        
        if (exitButton != null)
            exitButton.onClick.RemoveAllListeners();
    }
}
