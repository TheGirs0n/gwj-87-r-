using Godot;
using System;

public partial class Tutorial : Node
{
	private int _currentState = 0;
	
	[Export] private PackedScene _mainScene;
	
	[ExportGroup("Button")] 
	[Export] private Button Button;
	[Export] private Theme ButtonDayTheme;
	[Export] private Theme ButtonNightTheme;
	
	[ExportGroup("Background Text")]
	[Export] private TextureRect Background;
	[Export] private CompressedTexture2D BackgroundDay;
	[Export] private CompressedTexture2D BackgroundNight;
	
	[ExportGroup("Main Texture")]
	[Export] private TextureRect Main;
	[Export] private CompressedTexture2D MainDay;
	[Export] private CompressedTexture2D MainNight;
	
	[ExportGroup("Texts")]
	[Export] private RichTextLabel _textFirst;
	[Export] private RichTextLabel _textSecond;
	[Export] private RichTextLabel _textThird;
	[Export] private Theme _textDayTheme;
	[Export] private Theme _textNightTheme;

	public void SwitchState()
	{
		_currentState++;
		switch (_currentState)
		{
			case 1:
				Button.Theme = ButtonNightTheme;
				Background.Texture = BackgroundNight;
				Main.Texture = MainNight;
				
				_textFirst.Theme = _textNightTheme;
				_textSecond.Theme = _textNightTheme;
				_textThird.Theme = _textNightTheme;
				break;
			case 2:
				var scene = _mainScene.Instantiate<MainGame>();
				GetTree().Root.AddChild(scene);
		
				GlobalContext.TimeRebuilderInstance.RebuildForCurrentTimeType(TimeType.DAY);
				this.QueueFree();
				break;
		}
	}

	public void SetupTutorial()
	{
		_currentState = 0;
		Button.Theme = ButtonDayTheme;
		
		Background.Texture = BackgroundDay;
		Main.Texture = MainDay;
				
		_textFirst.Theme = _textDayTheme;
		_textSecond.Theme = _textDayTheme;
		_textThird.Theme = _textDayTheme;
	}
}
