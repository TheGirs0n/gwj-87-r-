using Godot;

public partial class GameOverScene : Control
{
	[ExportGroup("Text")] 
	[Export] private RichTextLabel _richTextLabel;
	[Export] private Theme _textDayLabel;
	[Export] private Theme _textNightLabel;
	
	[ExportGroup("DayNightCount")]
	[Export] private RichTextLabel _dayNightCountText;
	[Export] private RichTextLabel _dayNightCount;
	
	[ExportGroup("Modifiers")] 
	[Export] private RichTextLabel _speedMultiplayer;
	[Export] private RichTextLabel _speedMultiplayerValue;
	[Export] private RichTextLabel _spawnTime;
	[Export] private RichTextLabel _spawnTimeValue;
	[Export] private RichTextLabel _positiveScore;
	[Export] private RichTextLabel _positiveScoreValue;
	[Export] private RichTextLabel _negativeScore;
	[Export] private RichTextLabel _negativeScoreValue;
	
	[ExportGroup("Texture")]
	[Export] private TextureRect _textureRect;
	[Export] private CompressedTexture2D _textureDayRect;
	[Export] private CompressedTexture2D _textureNightRect;
	
	[ExportGroup("Button")]
	[Export] private Button _buttonRestartGame;
	[Export] private Button _buttonMainMenu;
	[Export] private Theme _buttonRestartDayTheme;
	[Export] private Theme _buttonRestartNightTheme;
	
	[ExportGroup("Animatable Player")]
	[Export] private AnimationPlayer _animatePlayer;

	
	public void StartNewGame()
	{
		var gameOverScene = ResourceLoader.Load<PackedScene>("res://Scenes/Tutorial/Tutorial.tscn").Instantiate<Tutorial>();
		GetTree().Root.AddChild(gameOverScene);
		GlobalContext.MainSceneInstance.QueueFree();
	}

	public void MainMenu()
	{
		var gameOverScene = ResourceLoader.Load<PackedScene>("res://Scenes/UI/MainMenuUI.tscn").Instantiate<MainMenuUi>();
		GetTree().Root.AddChild(gameOverScene);
		GlobalContext.MainSceneInstance.QueueFree();
	}
	
	public void SetupScreenGameOver(GameOverType gameOverType, TimeType timeType)
	{
		_animatePlayer.Play("showWindow");
		switch (gameOverType)
		{
			case GameOverType.MAX_CHARGE:
				_richTextLabel.Text = Tr("UI_GAME_OVER_DEATH_CAUSE_1");
				break;
			case GameOverType.MIN_CHARGE:
				_richTextLabel.Text = Tr("UI_GAME_OVER_DEATH_CAUSE_2");
				break;
		}

		switch (timeType)
		{
			case TimeType.DAY:
				SetupTexture(_textDayLabel, _textureDayRect);

				SetupButtons(_buttonRestartDayTheme);

				SetupDayNight(_textDayLabel);
				
				SetupModifiers(_textDayLabel);
				break;
			case TimeType.NIGHT:
				SetupTexture(_textNightLabel, _textureNightRect);

				SetupButtons(_buttonRestartNightTheme);
				
				SetupDayNight(_textNightLabel);
				
				SetupModifiers(_textNightLabel);
				break;
		}
		
	}

	private void SetupTexture(Theme theme, CompressedTexture2D texture)
	{
		_richTextLabel.Theme = theme;
		_textureRect.Texture = texture;
	}

	private void SetupButtons(Theme theme)
	{
		_buttonRestartGame.Theme = theme;
		_buttonMainMenu.Theme = theme;
	}

	private void SetupDayNight(Theme theme)
	{
		_dayNightCountText.Theme = theme;
		_dayNightCount.Theme = theme;
		_dayNightCount.Text = $"{GlobalContext.GlobalUIInstance.AfterGameSwitcher.DayCount}/{GlobalContext.GlobalUIInstance.AfterGameSwitcher.NightCount}";
	}

	private void SetupModifiers(Theme theme)
	{
		_speedMultiplayer.Theme = theme;
		_speedMultiplayerValue.Theme = theme;
		_speedMultiplayerValue.Text = GlobalContext.SpawnMiniCoresInstance.MiniCoreSpeedMultiplier.ToString("F2");
		
		_spawnTime.Theme = theme;
		_spawnTimeValue.Theme = theme;
		_spawnTimeValue.Text = GlobalContext.SpawnMiniCoresInstance.SpawnTimer.WaitTime.ToString("F2");
		
		_positiveScore.Theme = theme;
		_positiveScoreValue.Theme = theme;
		_positiveScoreValue.Text = GlobalContext.SpawnMiniCoresInstance.MiniCorePositiveScore.ToString("F2");
		
		_negativeScore.Theme = theme;
		_negativeScoreValue.Theme = theme;
		_negativeScoreValue.Text = GlobalContext.SpawnMiniCoresInstance.MiniCoreNegativeScore.ToString("F2");
	}
}
