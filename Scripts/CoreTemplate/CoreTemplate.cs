using Godot;
using System;

public abstract partial class CoreTemplate : CharacterBody2D
{
	[ExportGroup("Parameters")]
	[Export] public float CoreSpeed = 300f;
	[Export] public int PositiveScore;
	[Export] public int NegativeScore;
	
	[ExportGroup("Core Types")]
	[Export] public Sprite2D CoreSprite;
	[Export] public CompressedTexture2D CoreDaySprite;
	[Export] public CompressedTexture2D CoreNightSprite;

	[ExportGroup("Particles")]
	[Export] public GpuParticles2D CoreParticles;
	[Export] public ParticleProcessMaterial CoreParticleDayProcessMaterial;
	[Export] public ParticleProcessMaterial CoreParticleNightProcessMaterial;
	
	protected MainCore _targetMainCore;
	public static float SpeedMultiplier = 1f;
	public static float SpeedMultiplierIncreaseStep = 0.05f;
	public int ScoreFromDestroy;
	public int ScoreFromEntry;

	public abstract void RebuildForCurrentTimeType(TimeType timeType);
	public abstract void SwapPolarityScores(TimeType timeType);
	public abstract void MoveToMainCore(float delta);

	public static void IncreaseSpeedMultiplier()
	{
		SpeedMultiplier += SpeedMultiplierIncreaseStep;
	}

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
}

