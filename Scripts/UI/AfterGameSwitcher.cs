using Godot;
using System;

public partial class AfterGameSwitcher : Control
{
	[ExportGroup("Text")]
	[Export] private RichTextLabel DifficultyLabel;
	[Export] private Theme LabelDayTheme;
	[Export] private Theme LabelNightTheme;

	[ExportGroup("Button")]
	[Export] private Button SwitchTimeButton;
	[Export] private Theme SwitchTimeDayTheme;
	[Export] private Theme SwitchTimeNightTheme;
	
	private static int _currentState = 0;

	public override void _EnterTree()
	{
		GlobalContext.GlobalUIInstance.AfterGameSwitcher = this;
	}

	public void SwitchDayTime()
	{
		GlobalContext.TimeRebuilderInstance.RebuildForCurrentTimeType();
	}

	public void SetupSwitcherScene()
	{
		switch (_currentState)
		{
			case 0:
				_currentState = 1;
				
				DifficultyLabel.Theme = LabelDayTheme;
				SwitchTimeButton.Theme = SwitchTimeDayTheme;
				break;
			case 1:
				SwitchTimeButton.Theme = SwitchTimeNightTheme;
				DifficultyLabel.Theme = LabelNightTheme;
				
				GlobalContext.MainGameInstance.IncreaseDifficulty();
				DifficultyLabel.Text = CoreTemplate.GetSpeedMultiplier().ToString();
				
				_currentState = 0;
				break;
		}
	}
}
