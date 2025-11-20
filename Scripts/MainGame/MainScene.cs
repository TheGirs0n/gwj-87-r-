using Godot;

public partial class MainScene : Node
{
	public override void _Ready()
	{
		GlobalContext.MainSceneInstance = this;
		GlobalContext.TimeRebuilderInstance.RebuildForCurrentTimeType(TimeType.DAY);
	}
}
