using Godot;
using System;

public partial class BackgroundLayer : CanvasLayer
{
	[ExportGroup("Background Theme")]
	[Export] public TextureRect BackgroundTexture;
	[Export] public CompressedTexture2D BackgroundDay;
	[Export] public CompressedTexture2D BackgroundNight;

	public override void _Ready()
	{
		GlobalContext.GlobalUIInstance.BackgroundLayer = this;
	}

	public void RebuildForCurrentTimeType(TimeType timeType)
	{
		switch (timeType)
		{
			case TimeType.DAY:
				BackgroundTexture.Texture = BackgroundDay;
				break;
			case TimeType.NIGHT:
				BackgroundTexture.Texture = BackgroundNight;
				break;
		}
	}
}
