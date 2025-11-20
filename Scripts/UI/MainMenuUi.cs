using Godot;

public partial class MainMenuUi : Control
{
	[Export] private PackedScene _gameStory;
	[Export] private PackedScene _gameSettings;
	
	public void StartGame()
	{
		var scene = _gameStory.Instantiate();
		GetTree().Root.AddChild(scene);
		this.QueueFree();
	}

	public void Settings()
	{
		var setting = _gameSettings.Instantiate<SettingsUi>();
		setting.LoadUserSettings();
		GetTree().Root.AddChild(setting);
		//GlobalContext.SettingsUiInstance.Visible = true;
		//GD.Print(GlobalContext.SettingsUiInstance.Visible);
	}
	
	public void ExitGame()
	{
		GetTree().Quit();
	}
}
