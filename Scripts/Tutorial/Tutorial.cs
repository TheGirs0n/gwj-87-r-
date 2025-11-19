using Godot;
using System;

public partial class Tutorial : Node
{
	private int _currentState = 0;
	
	[Export] private PackedScene _mainScene;
	
	[ExportGroup("Button")] 
	[Export] private Button _button;
	[Export] private Theme _buttonDayTheme;
	[Export] private Theme _buttonNightTheme;
	
	[ExportGroup("Background Text")]
	[Export] private TextureRect _background;
	[Export] private CompressedTexture2D _backgroundDay;
	[Export] private CompressedTexture2D _backgroundNight;
	
	[ExportGroup("Main Texture")]
	[Export] private TextureRect _main;
	[Export] private CompressedTexture2D _mainDay;
	[Export] private CompressedTexture2D _mainNight;
	
	[ExportGroup("Texts")]
	[Export] private RichTextLabel _textFirst;
	[Export] private RichTextLabel _textSecond;
	[Export] private RichTextLabel _textThird;
	[Export] private Theme _textDayTheme;
	[Export] private Theme _textNightTheme;

	[ExportGroup("Textures Tutor")]
	[Export] private TextureRect _texture1;
	[Export] private TextureRect _texture2;
	[Export] private TextureRect _texture3;
	[Export] private CompressedTexture2D _texture1Day;
	[Export] private CompressedTexture2D _texture2Day;
	[Export] private CompressedTexture2D _texture3Day;
	[Export] private CompressedTexture2D _texture1Night;
	[Export] private CompressedTexture2D _texture2Night;
	[Export] private CompressedTexture2D _texture3Night;
	
	public void SwitchState()
	{
		_currentState++;
		switch (_currentState)
		{
			case 1:
				_button.Theme = _buttonNightTheme;
				
				_background.Texture = _backgroundNight;
				_main.Texture = _mainNight;
				
				_textFirst.Theme = _textNightTheme;
				_textSecond.Theme = _textNightTheme;
				_textThird.Theme = _textNightTheme;

				_texture1.Texture = _texture1Night;
				_texture2.Texture = _texture2Night;
				_texture3.Texture = _texture3Night;
				break;
			case 2:
				var scene = _mainScene.Instantiate<MainScene>();
				GetTree().Root.AddChild(scene);
				
				this.QueueFree();
				break;
		}
	}

	public void SetupTutorial()
	{
		_currentState = 0;
		_button.Theme = _buttonDayTheme;
		
		_background.Texture = _backgroundDay;
		_main.Texture = _mainDay;
				
		_textFirst.Theme = _textDayTheme;
		_textSecond.Theme = _textDayTheme;
		_textThird.Theme = _textDayTheme;
		
		_texture1.Texture = _texture1Day;
		_texture2.Texture = _texture2Day;
		_texture3.Texture = _texture3Day;
	}
}
