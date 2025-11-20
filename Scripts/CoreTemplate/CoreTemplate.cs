using Godot;

public abstract partial class CoreTemplate : CharacterBody2D
{
	[ExportGroup("Parameters")]
	[Export] public float CoreSpeed = 300f;
	[Export] public float PositiveScore;
	[Export] public float NegativeScore;
	
	[ExportGroup("Core Types")]
	[Export] public Sprite2D CoreSprite;
	[Export] public CompressedTexture2D CoreDaySprite;
	[Export] public CompressedTexture2D CoreNightSprite;

	[ExportGroup("Particles")]
	[Export] public GpuParticles2D CoreParticles;
	[Export] public ParticleProcessMaterial CoreParticleDayProcessMaterial;
	[Export] public ParticleProcessMaterial CoreParticleNightProcessMaterial;
	
	protected MainCore _targetMainCore;
	public float SpeedMultiplier = 1f;
	public float ScoreFromDestroy;
	public float ScoreFromEntry;

	public abstract void RebuildForCurrentTimeType(TimeType timeType);
	public abstract void SwapPolarityScores(TimeType timeType);
	public abstract void MoveToMainCore(float delta);
	
	public void MouseInputEvent(Node viewport, InputEvent @event, int shapeIdx)
	{
		if (@event is InputEventMouseButton mouseEvent && 
		    mouseEvent.ButtonIndex == MouseButton.Left && 
		    mouseEvent.Pressed)
		{
			DestroyCore();
		}
	}
	
	public void EnterCore(Node2D mainCore)
	{
		if (mainCore == _targetMainCore)
		{
			_targetMainCore.UpdateScore(ScoreFromEntry);
			this.QueueFree();
		}
	}

	public void DestroyCore()
	{
		_targetMainCore.UpdateScore(ScoreFromDestroy);
		this.QueueFree();
	}

	public void UpdateSpeedMultiplier(float newSpeedMultiplier)
	{
		SpeedMultiplier = newSpeedMultiplier;
	}

	public void UpdatePositiveScore(float newPositiveScore)
	{
		PositiveScore = newPositiveScore;
	}

	public void UpdateNegativeScore(float newNegativeScore)
	{
		NegativeScore = newNegativeScore;
	}
}

