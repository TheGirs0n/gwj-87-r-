using System;
using Godot;

public partial class SettingsBarUi : Control
{
    [ExportGroup("Sound Sliders")]
    [Export] private HSlider _masterSlider;
    [Export] private HSlider _sfxSlider;
    [Export] private HSlider _musicSlider;
    
    [ExportGroup("Text Numbers")] 
    [Export] private RichTextLabel _masterVolumeText;
    [Export] private RichTextLabel _sfxVolumeText;
    [Export] private RichTextLabel _musicVolumeText;
    
    [ExportGroup("Options Button")]
    [Export] private OptionButton _windowButton;
    [Export] private OptionButton _resolutionButton;
    
    [ExportGroup("Language")]
    [Export] private CheckButton _languageButton;
    
    [ExportGroup("Control Buttons")]
    [Export] private Button _applyButton;
    [Export] private Button _restoreDefaultsButton;

    public override void _Ready()
    {
        LoadAllUserSettings();
    }
    
    private void ApplyAndSaveSettings()
    {
        GlobalContext.SettingsManagerInstance.SaveSettings(
            (float)_masterSlider.Value,
            (float)_sfxSlider.Value,
            (float)_musicSlider.Value,
            _windowButton.Selected,
            _resolutionButton.Selected,
            _languageButton.ButtonPressed ? "en" : "ru"
        );
    }
    
    public void RestoreDefaults()
    {
        float defaultMasterVolume = 50f;
        float defaultSfxVolume = 50f;
        float defaultMusicVolume = 50f;
        int defaultWindowMode = 1;
        int defaultResolution = 0;
        string defaultLanguage = "en";
        
        _masterSlider.Value = defaultMasterVolume;
        _sfxSlider.Value = defaultSfxVolume;
        _musicSlider.Value = defaultMusicVolume;
        _windowButton.Select(defaultWindowMode);
        _resolutionButton.Select(defaultResolution);
        _languageButton.ButtonPressed = (defaultLanguage == "en");
        
        UpdateVolumeTexts();
        
        ApplyAndSaveSettings();
    }
    
    public void LoadAllUserSettings()
    {
        LoadAudioSettings();
        LoadDisplaySettings();
        LoadLanguage();
        UpdateVolumeTexts();
    }
    
    #region Audio

    private void LoadAudioSettings()
    {
        float masterVolume = GlobalContext.SettingsManagerInstance.GetMasterVolume();
        float sfxVolume = GlobalContext.SettingsManagerInstance.GetSfxVolume();
        float musicVolume = GlobalContext.SettingsManagerInstance.GetMusicVolume();

        _masterSlider.Value = masterVolume;
        _sfxSlider.Value = sfxVolume;
        _musicSlider.Value = musicVolume;
    }

    private void UpdateVolumeTexts()
    {
        _masterVolumeText.Text = $"{Math.Round(_masterSlider.Value)}%";
        _sfxVolumeText.Text = $"{Math.Round(_sfxSlider.Value)}%";
        _musicVolumeText.Text = $"{Math.Round(_musicSlider.Value)}%";
    }
    
    private void OnVolumeTextUpdate(double volume)
    {
        UpdateVolumeTexts();
    }
    
    #endregion

    #region Display

    private void LoadDisplaySettings()
    {
        int windowMode = GlobalContext.SettingsManagerInstance.GetWindowMode();
        int resolution = GlobalContext.SettingsManagerInstance.GetResolution();

        _windowButton.Select(windowMode);
        _resolutionButton.Select(resolution);
    }

    #endregion

    #region Language

    private void LoadLanguage()
    {
        string language = GlobalContext.SettingsManagerInstance.GetLanguage();
        _languageButton.ButtonPressed = (language == "en");
    }

    #endregion
    
    private void SaveAllSettings()
    {
        GlobalContext.SettingsManagerInstance.SaveSettings(
            (float)_masterSlider.Value,
            (float)_sfxSlider.Value,
            (float)_musicSlider.Value,
            _windowButton.Selected,
            _resolutionButton.Selected,
            _languageButton.ButtonPressed ? "en" : "ru"
        );
    }
}