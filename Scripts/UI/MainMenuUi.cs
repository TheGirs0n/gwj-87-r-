using Godot;

public partial class MainMenuUi : Control
{
	[Export] private PackedScene _gameStory;
	
	public void StartGame()
	{
		var scene = _gameStory.Instantiate();
		GetTree().Root.AddChild(scene);
		this.QueueFree();
	}

	public void Settings()
	{
		GlobalContext.SettingsUiInstance.Visible = true;
		GD.Print(GlobalContext.SettingsUiInstance.Visible);
	}
	
	public void ExitGame()
	{
		GetTree().Quit();
	}
}
