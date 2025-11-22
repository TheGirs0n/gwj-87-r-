using Godot;

public partial class AudioManager : Node
{
	[ExportGroup("Audio")]
	[Export] private AudioStreamPlayer _miniCoreEntrySound;
	[Export] private AudioStreamPlayer _miniCoreDestroySound;
	
	public override void _EnterTree()
	{
		GlobalContext.AudioManagerInstance = this;
	}
	
	public void PlayCoreEntrySound()
	{
		_miniCoreEntrySound.Play();
	}

	public void PlayCoreDestroySound()
	{
		_miniCoreDestroySound.Play();
	}
}
