using Godot;

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
				SetupButton(_buttonNightTheme, false);

				SetupTextureBack(_backgroundNight, _mainNight);
				
				SetupTextTheme(_textNightTheme);
				SetupTextDescription(false);
				
				SetupTextureMain(_texture1Night, _texture2Night, _texture3Night);
				_background.FlipH = true;
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
		SetupButton(_buttonDayTheme, true);

		SetupTextureBack(_backgroundDay, _mainDay);

		SetupTextTheme(_textDayTheme);
		SetupTextDescription(true);
		
		SetupTextureMain(_texture1Day, _texture2Day, _texture3Day);
	}

	private void SetupButton(Theme theme, bool IsDay)
	{
		_button.Theme = theme;

		if (IsDay == true)
		{
			_button.Text = Tr("TUTORIAL_BUTTON_1");
		}
		else
		{
			_button.Text = Tr("TUTORIAL_BUTTON_2");
		}
	}
	
	private void SetupTextureBack(CompressedTexture2D backgroundDay, CompressedTexture2D mainDay)
	{
		_background.Texture = backgroundDay;
		_main.Texture = mainDay;
	}

	private void SetupTextTheme(Theme theme)
	{
		_textFirst.Theme = theme;
		_textSecond.Theme = theme;
		_textThird.Theme = theme;
	}

	private void SetupTextDescription(bool IsDay)
	{
		if (IsDay == true)
		{
			_textFirst.Text = Tr("TUTORIAL_CASE_1_1");
			_textSecond.Text = Tr("TUTORIAL_CASE_1_2");
			_textThird.Text = Tr("TUTORIAL_CASE_1_3");
		}
		else
		{
			_textFirst.Text = Tr("TUTORIAL_CASE_2_1");
			_textSecond.Text = Tr("TUTORIAL_CASE_2_2");
			_textThird.Text = Tr("TUTORIAL_CASE_2_3");
		}
	}

	private void SetupTextureMain(CompressedTexture2D mainTexture1, CompressedTexture2D mainTexture2, CompressedTexture2D mainTexture3)
	{
		_texture1.Texture = mainTexture1;
		_texture2.Texture = mainTexture2;
		_texture3.Texture = mainTexture3;
	}
}
