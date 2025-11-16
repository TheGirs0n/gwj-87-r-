using Godot;
using System;

public abstract partial class CoreTemplate : Node2D
{
	[ExportGroup("Parameters")]
	[Export] public float CoreSpeed = 300f;
	[Export] public int ScoreFromEntry;
	[Export] public int ScoreFromDestroy;
	
	[ExportGroup("Core Types")]
	[Export] public CoreType CoreType;
	[Export] public CoreEntryAction CoreEntryAction;
	[Export] public CoreDestroyAction CoreDestroyAction;
	[Export] public Sprite2D CoreSprite;
	[Export] public CompressedTexture2D CoreDaySprite;
	[Export] public CompressedTexture2D CoreNightSprite;

	public abstract void RebuildForDay();
	public abstract void RebuildForNight();
	public abstract void SwapPolarityScores();
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
