using System;
using Godot;

public partial class SpawnMiniCores : Node
{
	[ExportGroup("Mini Cores")]
	[Export] public PackedScene PositiveCore;
	[Export] public PackedScene NegativeCore;
	[Export] public Node NodesPool;
	
	[ExportGroup("Parameters")]
	[Export] public Timer SpawnTimer;
	[Export] public float InitialWaitTime = 1f;
	[Export] public float SpawnOffset = 50.0f;
	[Export] public Timer MainGameTimer;
	
	[ExportGroup("Spawn Area")]
	[Export] public float MinSpawnHeight = 0.05f; 
	[Export] public float MaxSpawnHeight = 0.95f; 
	
	private Random _random = new Random();

	public float MiniCoreSpeedMultiplier = 1f;
	public float MiniCorePositiveScore = 10f;
	public float MiniCoreNegativeScore = -10f;

	public override void _EnterTree()
	{
		GlobalContext.SpawnMiniCoresInstance = this;
	}
	
	public void ResetToInitial()
	{
		MiniCoreSpeedMultiplier = 1.0f;
		MiniCorePositiveScore = 10f;
		MiniCoreNegativeScore = -10f;
		SpawnTimer.WaitTime = InitialWaitTime;
	}
	
	public void UpdateSpeedMultiplier(float newSpeedMultiplier)
	{
		MiniCoreSpeedMultiplier = newSpeedMultiplier;
	}

	public void UpdatePositiveScore(float newPositiveScore)
	{
		MiniCorePositiveScore = newPositiveScore;
	}

	public void UpdateNegativeScore(float newNegativeScore)
	{
		MiniCoreNegativeScore = newNegativeScore;
	}
	
	public void UpdateSpawnTimer(float newSpawnTimer)
	{
		SpawnTimer.WaitTime = newSpawnTimer;
	}
	
	public void SpawnRandomMiniCore()
	{
		if (MainGameTimer.TimeLeft != 0)
		{
			var coreType = Random.Shared.Next(1, 3);
			PackedScene coreScene = coreType == 1 ? PositiveCore : NegativeCore;
			
			var coreInstance = coreScene.Instantiate<CoreTemplate>();
			
			coreInstance.RebuildForCurrentTimeType(GlobalContext.TimeRebuilderInstance.TimeType);
			coreInstance.UpdateNegativeScore(MiniCoreNegativeScore);
			coreInstance.UpdateNegativeScore(MiniCoreNegativeScore);
			coreInstance.UpdateSpeedMultiplier(MiniCoreSpeedMultiplier);
			
			NodesPool.AddChild(coreInstance);

			coreInstance.GlobalPosition = GetRandomPositionOffScreen();
		}
	}

	private Vector2 GetRandomPositionOffScreen()
	{
		var viewport = GetViewport();
		var viewportSize = viewport.GetVisibleRect().Size;
    
		var camera = viewport.GetCamera2D();
		var cameraCenter = camera?.GlobalPosition ?? Vector2.Zero;
    
		var right = cameraCenter.X + viewportSize.X / 2;
		var top = cameraCenter.Y - viewportSize.Y / 2;
		var bottom = cameraCenter.Y + viewportSize.Y / 2;
		
		var minY = top + viewportSize.Y * MinSpawnHeight;
		var maxY = top + viewportSize.Y * MaxSpawnHeight;
		
		var randomY = minY + _random.NextSingle() * (maxY - minY);
    
		var spawnPosition = new Vector2(
			right + SpawnOffset,
			randomY
		);

		return spawnPosition;
	}

}
