using Godot;
using System;

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
		
	}
	
	public void ExitGame()
	{
		
	}
}
