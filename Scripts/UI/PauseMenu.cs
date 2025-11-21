using Godot;

public partial class PauseMenu : Control
{
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
	}

	public void ExitGame()
	{
		var gameOverScene = ResourceLoader.Load<PackedScene>("res://Scenes/UI/MainMenuUI.tscn").Instantiate<MainMenuUi>();
		GetTree().Root.AddChild(gameOverScene);
		GlobalContext.MainSceneInstance.QueueFree();
	}
}
