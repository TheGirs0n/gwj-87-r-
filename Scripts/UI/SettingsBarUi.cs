using System;
using Godot;

public partial class SettingsBarUi : Control
{
	[ExportGroup("Text Numbers")] 
	[Export] private RichTextLabel _masterVolumeText;
	[Export] private RichTextLabel _sfxVolumeText;
	[Export] private RichTextLabel _musicVolumeText;
	
	#region Audio

	private void UpdateMasterVolume(float volume)
	{
		AudioServer.SetBusVolumeLinear(0, volume);
		_masterVolumeText.Text = $"{Math.Round(volume, 1)}%";
	}

	private void UpdateSoundEffectVolume(float volume)
	{
		AudioServer.SetBusVolumeLinear(1, volume);
		_sfxVolumeText.Text = $"{Math.Round(volume, 1)}%";
	}
	
	private void UpdateMusicVolume(float volume)
	{
		AudioServer.SetBusVolumeLinear(2, volume);
		_musicVolumeText.Text = $"{Math.Round(volume, 1)}%";
	}
	
	#endregion

	#region Display

	private void SetWindowMode(int index)
	{
		switch (index)
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

	private static Vector2I[] _windowSizes =
	[
		new Vector2I(1280, 720),
		new Vector2I(1600, 900),
		new Vector2I(1920, 1080)
	];

	private void SetResolutionMode(int index)
	{
		DisplayServer.WindowSetSize(_windowSizes[index]);
	}

	#endregion

	#region Language

	private void UpdateLanguage(bool toggledOn)
	{
		if (toggledOn == true)
		{
			TranslationServer.SetLocale("en");
		}
		else
		{
			TranslationServer.SetLocale("ru");
		}
	}

	#endregion
}
