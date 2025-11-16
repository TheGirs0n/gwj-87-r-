using Godot;
using System;

public partial class SpawnMiniCores : Area2D
{
	[ExportGroup("Mini Cores")]
	[Export] public PackedScene PositiveCore;
	[Export] public PackedScene NegativeCore;
	
	[ExportGroup("Parameters")]
	[Export] public CollisionShape2D SpawnZone;
	[Export] public Timer SpawnTimer;
	
	public void SpawnRandomMiniCore()
	{
		var coreType = Random.Shared.Next(1, 3);
		PackedScene coreScene = coreType == 1 ? PositiveCore : NegativeCore;
		
		var coreInstance = coreScene.Instantiate<Node2D>();
		GetTree().CurrentScene.AddChild(coreInstance);
		
		coreInstance.GlobalPosition = GetRandomPositionOnEdge();
	}

	private Vector2 GetRandomPositionOnEdge()
	{
		var rectSize = GetViewportRect().Size;
		var side = Random.Shared.Next(0, 4);
		
		var localPosition = Vector2.Zero;

		switch (side)
		{
			case 0:
				localPosition = new Vector2(
					Random.Shared.NextSingle() * rectSize.X - rectSize.X / 2,
					-rectSize.Y / 2
				);
				break;
			case 1:
				localPosition = new Vector2(
					rectSize.X / 2,
					Random.Shared.NextSingle() * rectSize.Y - rectSize.Y / 2
				);
				break;
			case 2:
				localPosition = new Vector2(
					Random.Shared.NextSingle() * rectSize.X - rectSize.X / 2,
					rectSize.Y / 2
				);
				break;
			case 3:
				localPosition = new Vector2(
					-rectSize.X / 2,
					Random.Shared.NextSingle() * rectSize.Y - rectSize.Y / 2
				);
				break;
		}
		
		return SpawnZone.GlobalPosition + localPosition;
	}
}
