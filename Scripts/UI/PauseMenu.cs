using Godot;

public partial class PauseMenu : Control
{
	[Export] public PackedScene MainMenuScene;
	[Export] public PackedScene SettingsScene;
	
	public void ContinueGame()
	{
		GlobalContext.MainGameInstance.ContinueGame();	
		this.Visible = false;
	}

	public void Settings()
	{
		var scene = SettingsScene.Instantiate<SettingsUi>();
		scene.LoadUserSettings();
		GlobalContext.GlobalUIInstance.AddChild(scene);
		GlobalContext.GlobalUIInstance.SettingsSceneUIOpen();
		//GlobalContext.SettingsUiInstance.Visible = true;
		//GD.Print(GlobalContext.SettingsUiInstance.Visible);
	}

	public void ExitGame()
	{
		var scene = MainMenuScene.Instantiate<MainMenuUi>();
		GlobalContext.MainSceneInstance.QueueFree();
	}
}
