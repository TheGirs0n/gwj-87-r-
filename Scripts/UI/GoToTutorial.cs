using Godot;
using System;

public partial class GoToTutorial : Control
{
	[Export] private PackedScene _mainScene;

	public void GoToMain()
	{
		var scene = _mainScene.Instantiate<MainGame>();
		GetTree().Root.AddChild(scene);
		
		GlobalContext.TimeRebuilderInstance.RebuildForCurrentTimeType(TimeType.DAY);
		this.QueueFree();
	}
}
