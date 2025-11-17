using Godot;
using System;

public abstract partial class CoreTemplate : CharacterBody2D
{
	[ExportGroup("Parameters")]
	[Export] public float CoreSpeed = 300f;
	[Export] public float SpeedMultiplier = 1f;
	[Export] public int PositiveScore;
	[Export] public int NegativeScore;
	public int ScoreFromDestroy;
	public int ScoreFromEntry;
	
	[ExportGroup("Core Types")]
	[Export] public CoreType CoreType;
	[Export] public CoreEntryAction CoreEntryAction;
	[Export] public CoreDestroyAction CoreDestroyAction;
	[Export] public Sprite2D CoreSprite;
	[Export] public CompressedTexture2D CoreDaySprite;
	[Export] public CompressedTexture2D CoreNightSprite;

	protected MainCore _targetMainCore;

	public override void _Ready()
	{
		GlobalContext.CoreInstance = this;
	}

	public abstract void RebuildForCurrentTimeType(TimeType timeType);
	public abstract void SwapPolarityScores(TimeType timeType);
	public abstract void MoveToMainCore(float delta);

	public void EnterCore(Node2D mainCore)
	{
		if (mainCore == _targetMainCore)
		{
			GD.Print("EnterCore SSS");
			this.QueueFree();
		}
	}

	public void DestroyCore()
	{
		_targetMainCore.UpdateScore(ScoreFromDestroy);
		this.QueueFree();
	}

	public int GetPointsFromEntry()
	{
		return ScoreFromEntry;
	}

	public int GetPointsFromDestroy()
	{
		return ScoreFromDestroy;
	}

}

public enum CoreType
{
	POSITIVE,
	NEGATIVE
}

public enum CoreEntryAction
{
	POSITIVE,
	NEGATIVE,
}

public enum CoreDestroyAction
{
	POSITIVE,
	NEGATIVE,
}
