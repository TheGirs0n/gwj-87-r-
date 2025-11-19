using Godot;
using System;

public partial class GoToTutorial : Control
{
	[Export] private PackedScene _tutorial;

	public void GoToMain()
	{
		var scene = _tutorial.Instantiate<Tutorial>();
		scene.SetupTutorial();
		GetTree().Root.AddChild(scene);
		
		this.QueueFree();
	}
}
