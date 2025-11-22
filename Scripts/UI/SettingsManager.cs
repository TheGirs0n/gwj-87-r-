using Godot;
using System;

public partial class SettingsManager : Node
{
	private ConfigFile _configFile;
	private readonly string _configPath = "user://settings.cfg";
	
	public override void _EnterTree()
	{
		GlobalContext.SettingsManagerInstance = this;
		LoadSettingsAtStartup();
	}

	private void LoadSettingsAtStartup()
	{
		_configFile = new ConfigFile();
		Error error = _configFile.Load(_configPath);
        
		if (error != Error.Ok)
		{
			ApplyDefaultSettings();
			return;
		}

		ApplySettingsFromConfig();
	}
	
	private void ApplySettingsFromConfig()
	{
		float masterVolume = (float)_configFile.GetValue("audio", "master_volume", 1.0f);
		float sfxVolume = (float)_configFile.GetValue("audio", "sfx_volume", 1.0f);
		float musicVolume = (float)_configFile.GetValue("audio", "music_volume", 1.0f);
		int windowMode = (int)_configFile.GetValue("video", "window_mode", 0);
		int resolutionIndex = (int)_configFile.GetValue("video", "resolution", 0);
		string language = (string)_configFile.GetValue("gameplay", "language", "en");

		ApplySettings(masterVolume, sfxVolume, musicVolume, windowMode, resolutionIndex, language);
	}
	
	private void ApplyDefaultSettings()
	{
		ApplySettings(1.0f, 1.0f, 1.0f, 0, 0, "en");
	}
	
	public void ApplySettings(float masterVolume, float sfxVolume, float musicVolume, 
		int windowMode, int resolution, string language)
	{
		AudioServer.SetBusVolumeDb(0, Mathf.LinearToDb(masterVolume));
		AudioServer.SetBusVolumeDb(1, Mathf.LinearToDb(sfxVolume));
		AudioServer.SetBusVolumeDb(2, Mathf.LinearToDb(musicVolume));
		
		ApplyWindowMode(windowMode);
		ApplyResolution(resolution);
		
		TranslationServer.SetLocale(language);
	}
	
	private void ApplyWindowMode(int modeIndex)
	{
		switch (modeIndex)
		{
			case 0:
				DisplayServer.WindowSetMode(DisplayServer.WindowMode.Fullscreen);
				DisplayServer.WindowSetFlag(DisplayServer.WindowFlags.Borderless, false);
				break;
			case 1:
				DisplayServer.WindowSetMode(DisplayServer.WindowMode.Windowed);
				DisplayServer.WindowSetFlag(DisplayServer.WindowFlags.Borderless, false);
				break;
			case 2:
				DisplayServer.WindowSetMode(DisplayServer.WindowMode.Windowed);
				DisplayServer.WindowSetFlag(DisplayServer.WindowFlags.Borderless, true);
				break;
			case 3:
				DisplayServer.WindowSetMode(DisplayServer.WindowMode.Fullscreen);
				DisplayServer.WindowSetFlag(DisplayServer.WindowFlags.Borderless, true);
				break;
		}
	}
	
	private void ApplyResolution(int index)
	{
		Vector2I[] resolutions = {
			new Vector2I(1280, 720),
			new Vector2I(1600, 900),
			new Vector2I(1920, 1080)
		};

		if (index >= 0 && index < resolutions.Length)
		{
			DisplayServer.WindowSetSize(resolutions[index]);
		}
	}
	
	public float GetMasterVolume()
	{
		return (float)_configFile.GetValue("audio", "master_volume", 1.0f);
	}

	public float GetSfxVolume()
	{
		return (float)_configFile.GetValue("audio", "sfx_volume", 1.0f);
	}

	public float GetMusicVolume()
	{
		return (float)_configFile.GetValue("audio", "music_volume", 1.0f);
	}

	public int GetWindowMode()
	{
		return (int)_configFile.GetValue("video", "window_mode", 0);
	}

	public int GetResolution()
	{
		return (int)_configFile.GetValue("video", "resolution", 0);
	}

	public string GetLanguage()
	{
		return (string)_configFile.GetValue("gameplay", "language", "en");
	}

	public void SaveSettings(float masterVolume, float sfxVolume, float musicVolume,
		int windowMode, int resolution, string language)
	{
		_configFile.SetValue("audio", "master_volume", masterVolume);
		_configFile.SetValue("audio", "sfx_volume", sfxVolume);
		_configFile.SetValue("audio", "music_volume", musicVolume);

		_configFile.SetValue("video", "window_mode", windowMode);
		_configFile.SetValue("video", "resolution", resolution);

		_configFile.SetValue("gameplay", "language", language);

		Error error = _configFile.Save(_configPath);
		if (error == Error.Ok)
		{
			ApplySettings(masterVolume, sfxVolume, musicVolume, windowMode, resolution, language);
		}
		else
		{
			GD.PrintErr($"Failed to save settings: {error}");
		}
	}
}
