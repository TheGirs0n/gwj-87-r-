using Godot;

public partial class GoToTutorial : Control
{
	[Export] public PackedScene Tutorial;

	public void GoToMain()
	{
		var scene = Tutorial.Instantiate<Tutorial>();
		scene.SetupTutorial();
		GetTree().Root.AddChild(scene);
		
		this.QueueFree();
	}
}
