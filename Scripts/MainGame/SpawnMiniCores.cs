using Godot;
using System;

public partial class SpawnMiniCores : Node
{
	[ExportGroup("Mini Cores")]
	[Export] public PackedScene PositiveCore;
	[Export] public PackedScene NegativeCore;
	[Export] public Node NodesPool;
	
	[ExportGroup("Parameters")]
	[Export] public Timer SpawnTimer;
	[Export] public float SpawnOffset = 50.0f; 
	
	[ExportGroup("Spawn Area")]
	[Export] public float MinSpawnHeight = 0.05f; 
	[Export] public float MaxSpawnHeight = 0.95f; 
	
	private Random _random = new Random();
	
	public void SpawnRandomMiniCore()
	{
		var coreType = Random.Shared.Next(1, 3);
		PackedScene coreScene = coreType == 1 ? PositiveCore : NegativeCore;
		
		var coreInstance = coreScene.Instantiate<CoreTemplate>();
		NodesPool.AddChild(coreInstance);
		GD.Print(NodesPool.GetChildCount());
		
		coreInstance.GlobalPosition = GetRandomPositionOffScreen();
		GD.Print("Spawn Core");
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
