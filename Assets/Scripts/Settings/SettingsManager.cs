using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsManager : MonoBehaviour
{
    [Header("Audio Settings")]
    [SerializeField] private Slider masterVolumeSlider;
    [SerializeField] private Slider musicVolumeSlider;
    [SerializeField] private Slider effectsVolumeSlider;

    [Header("Player Settings")]
    [SerializeField] private TMP_InputField playerNameInput;

    [Header("Language Settings")]
    [SerializeField] private TMP_Dropdown languageDropdown;

    [Header("Accessibility")]
    [SerializeField] private Toggle accessibilityModeToggle;

    [Header("Buttons")]
    [SerializeField] private Button saveButton;
    [SerializeField] private Button backButton;

    private void Start()
    {
        LoadSettings();
        InitializeButtons();
    }

    private void InitializeButtons()
    {
        if (saveButton != null)
        {
            saveButton.onClick.AddListener(OnSaveSettings);
        }

        if (backButton != null)
        {
            backButton.onClick.AddListener(OnBack);
        }

        // Add listeners to sliders for real-time updates
        if (masterVolumeSlider != null)
        {
            masterVolumeSlider.onValueChanged.AddListener(OnMasterVolumeChanged);
        }

        if (musicVolumeSlider != null)
        {
            musicVolumeSlider.onValueChanged.AddListener(OnMusicVolumeChanged);
        }

        if (effectsVolumeSlider != null)
        {
            effectsVolumeSlider.onValueChanged.AddListener(OnEffectsVolumeChanged);
        }
    }

    private void LoadSettings()
    {
        // Load audio settings
        float masterVolume = PlayerPrefs.GetFloat("MasterVolume", 1f);
        float musicVolume = PlayerPrefs.GetFloat("MusicVolume", 0.5f);
        float effectsVolume = PlayerPrefs.GetFloat("EffectsVolume", 1f);

        if (masterVolumeSlider != null)
        {
            masterVolumeSlider.value = masterVolume;
        }

        if (musicVolumeSlider != null)
        {
            musicVolumeSlider.value = musicVolume;
        }

        if (effectsVolumeSlider != null)
        {
            effectsVolumeSlider.value = effectsVolume;
        }

        // Load player name
        string playerName = PlayerPrefs.GetString("PlayerName", "Zeven");
        if (playerNameInput != null)
        {
            playerNameInput.text = playerName;
        }

        // Load language
        int languageIndex = PlayerPrefs.GetInt("Language", 0);
        if (languageDropdown != null)
        {
            languageDropdown.value = languageIndex;
        }

        // Load accessibility mode
        bool accessibilityMode = PlayerPrefs.GetInt("AccessibilityMode", 0) == 1;
        if (accessibilityModeToggle != null)
        {
            accessibilityModeToggle.isOn = accessibilityMode;
        }

        ApplySettings();
    }

    private void OnSaveSettings()
    {
        SaveSettings();
        OnBack();
    }

    private void SaveSettings()
    {
        // Save audio settings
        if (masterVolumeSlider != null)
        {
            PlayerPrefs.SetFloat("MasterVolume", masterVolumeSlider.value);
        }

        if (musicVolumeSlider != null)
        {
            PlayerPrefs.SetFloat("MusicVolume", musicVolumeSlider.value);
        }

        if (effectsVolumeSlider != null)
        {
            PlayerPrefs.SetFloat("EffectsVolume", effectsVolumeSlider.value);
        }

        // Save player name
        if (playerNameInput != null)
        {
            PlayerPrefs.SetString("PlayerName", playerNameInput.text);
        }

        // Save language
        if (languageDropdown != null)
        {
            PlayerPrefs.SetInt("Language", languageDropdown.value);
        }

        // Save accessibility mode
        if (accessibilityModeToggle != null)
        {
            PlayerPrefs.SetInt("AccessibilityMode", accessibilityModeToggle.isOn ? 1 : 0);
        }

        PlayerPrefs.Save();
        Debug.Log("Settings saved!");
    }

    private void ApplySettings()
    {
        // Apply audio settings
        if (masterVolumeSlider != null)
        {
            AudioListener.volume = masterVolumeSlider.value;
        }

        // Apply other settings as needed
    }

    private void OnMasterVolumeChanged(float value)
    {
        AudioListener.volume = value;
    }

    private void OnMusicVolumeChanged(float value)
    {
        // Apply music volume to music audio source
        // AudioManager.Instance?.SetMusicVolume(value);
    }

    private void OnEffectsVolumeChanged(float value)
    {
        // Apply effects volume to effects audio source
        // AudioManager.Instance?.SetEffectsVolume(value);
    }

    private void OnBack()
    {
        SceneRouter.Instance?.LoadMainMenu();
    }
}
