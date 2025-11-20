using Godot;

public partial class BackgroundLayer : CanvasLayer
{
	[ExportGroup("Background Theme")]
	[Export] public TextureRect BackgroundTexture;
	[Export] public CompressedTexture2D BackgroundDay;
	[Export] public CompressedTexture2D BackgroundNight;

	[ExportGroup("Core Cage Textures")]
	[Export] public TextureRect CoreCageBack;
	[Export] public TextureRect CoreCageFront;
	[Export] public CompressedTexture2D CoreCageBackDay;
	[Export] public CompressedTexture2D CoreCageBackNight;
	[Export] public CompressedTexture2D CoreCageFrontDay;
	[Export] public CompressedTexture2D CoreCageFrontNight;
	
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
				
				CoreCageBack.Texture = CoreCageBackDay;
				CoreCageFront.Texture = CoreCageFrontDay;
				break;
			case TimeType.NIGHT:
				BackgroundTexture.Texture = BackgroundNight;
				
				CoreCageBack.Texture = CoreCageBackNight;
				CoreCageFront.Texture = CoreCageFrontNight;
				break;
		}
	}
}
