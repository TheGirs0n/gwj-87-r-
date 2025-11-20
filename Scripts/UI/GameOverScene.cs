using Godot;

public partial class GameOverScene : Control
{
	[ExportGroup("Text")] 
	[Export] private RichTextLabel _richTextLabel;
	[Export] private string _minChargeText;
	[Export] private string _maxChargeText;
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
		
		_animatePlayer.Play("playOver");
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
		_speedMultiplayerValue.Text = GlobalContext.SpawnMiniCoresInstance.MiniCoreSpeedMultiplier.ToString();
		
		_spawnTime.Theme = theme;
		_spawnTimeValue.Theme = theme;
		_spawnTimeValue.Text = GlobalContext.SpawnMiniCoresInstance.SpawnTimer.WaitTime.ToString();
		
		_positiveScore.Theme = theme;
		_positiveScoreValue.Theme = theme;
		_positiveScoreValue.Text = GlobalContext.SpawnMiniCoresInstance.MiniCorePositiveScore.ToString();
		
		_negativeScore.Theme = theme;
		_negativeScoreValue.Theme = theme;
		_negativeScoreValue.Text = GlobalContext.SpawnMiniCoresInstance.MiniCoreNegativeScore.ToString();
	}
}
