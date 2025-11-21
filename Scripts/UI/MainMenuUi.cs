using Godot;

public partial class MainMenuUi : Control
{
	[Export] private PackedScene _gameStory;
	[Export] private PackedScene _gameSettings;

	public override void _EnterTree()
	{
		GlobalContext.MainMenuInstance = this;
	}

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

		SetTransperentMenu();
	}

	public void ExitGame()
	{
		GetTree().Quit();
	}

	public void SetTransperentMenu()
	{
		this.Modulate = new Color(1, 1, 1, 0.75f);
	}

	public void SetUntransperentMenu()
	{
		this.Modulate = new Color(1, 1, 1, 1f);
	}

}
