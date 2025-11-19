using Godot;
using System;

public partial class PauseMenu : Control
{
	[Export] private PackedScene _mainMenuScene;
	
	public void ContinueGame()
	{
		GlobalContext.MainGameInstance.StartGame();	
		this.Visible = false;
	}

	public void Settings()
	{
		GlobalContext.SettingsUiInstance.Visible = true;
		GD.Print(GlobalContext.SettingsUiInstance.Visible);
	}

	public void ExitGame()
	{
		var scene = _mainMenuScene.Instantiate<MainMenuUi>();
		GlobalContext.MainSceneInstance.QueueFree();
	}
}
