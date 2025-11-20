using Godot;

public partial class AudioManager : Node
{
	public override void _EnterTree()
	{
		GlobalContext.AudioManagerInstance = this;
	}
}
