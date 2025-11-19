using Godot;
using System;

public partial class GameOverScene : Control
{
	[ExportGroup("Text")] 
	[Export] private RichTextLabel _richTextLabel;
	[Export] private string _minChargeText;
	[Export] private string _maxChargeText;
	[Export] private Theme _textDayLabel;
	[Export] private Theme _textNightLabel;
	
	[ExportGroup("Texture")]
	[Export] private TextureRect _textureRect;
	[Export] private CompressedTexture2D _textureDayRect;
	[Export] private CompressedTexture2D _textureNightRect;
	
	[ExportGroup("Button")]
	[Export] private Button _buttonRestartGame;
	[Export] private Button _buttonMainMenu;
	[Export] private Theme _buttonRestartDayTheme;
	[Export] private Theme _buttonRestartNightTheme;
	
	[ExportGroup("AnimatePlayer")]
	[Export] private AnimationPlayer _animatePlayer;
	
	[ExportGroup("Packed Scene")]
	[Export] private PackedScene _tutorial;
	[Export] private PackedScene _mainMenu;
	
	public void StartNewGame()
	{
		var tutor = _tutorial.Instantiate<Tutorial>();
		tutor.SetupTutorial();
		
		GetTree().Root.AddChild(tutor);
		this.QueueFree();
	}

	public void MainMenu()
	{
		var menu = _mainMenu.Instantiate<MainMenuUi>();
		GetTree().Root.AddChild(menu);
		this.QueueFree();
	}
	
	public void SetupScreenGameOver(GameOverType gameOverType, TimeType timeType)
	{
		switch (gameOverType)
		{
			case GameOverType.MAX_CHARGE:
				_richTextLabel.Text = _minChargeText;
				break;
			case GameOverType.MIN_CHARGE:
				_richTextLabel.Text = _maxChargeText;
				break;
		}

		switch (timeType)
		{
			case TimeType.DAY:
				_richTextLabel.Theme = _textDayLabel;
				_textureRect.Texture = _textureDayRect;
				_buttonRestartGame.Theme = _buttonRestartDayTheme;
				_buttonMainMenu.Theme = _buttonRestartDayTheme;
				break;
			case TimeType.NIGHT:
				_richTextLabel.Theme = _textNightLabel;
				_textureRect.Texture = _textureNightRect;
				_buttonRestartGame.Theme = _buttonRestartNightTheme;
				_buttonMainMenu.Theme = _buttonRestartNightTheme;
				break;
		}
		
		_animatePlayer.Play("playOver");
	}
}
