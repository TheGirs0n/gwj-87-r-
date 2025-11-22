using Godot;
using System;

public partial class Intro : Control
{
	public void EndIntroAnimation(StringName animationName)
	{
		if (animationName == "first_intro")
		{
			var gameOverScene = ResourceLoader.Load<PackedScene>("res://Scenes/UI/MainMenuUI.tscn").Instantiate<MainMenuUi>();
			GetTree().Root.AddChild(gameOverScene);
			this.QueueFree();
		}
	}
}
