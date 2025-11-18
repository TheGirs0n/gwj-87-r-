using Godot;
using System;

public partial class SettingsBarUi : Control
{
	#region Audio

	public void UpdateMasterVolume(float volume)
	{
		
	}

	public void UpdateSoundEffectVolume(float volume)
	{
		
	}
	
	public void UpdateMusicVolume(float volume)
	{
		
	}
	
	#endregion

	#region Display

	public void SetWindowMode(int index)
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

	public void SetResolutionMode(int index)
	{
		DisplayServer.WindowSetSize(_windowSizes[index]);
	}

	#endregion
}
