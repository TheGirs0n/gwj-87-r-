using Godot;
using System;

public partial class AfterGameSwitcher : Control
{
	[ExportGroup("Text")]
	[Export] private RichTextLabel DifficultyLabel;
	[Export] private RichTextLabel LevelLabel;
	[Export] private RichTextLabel DayNightLabel;
	[Export] private RichTextLabel DayNightLabelCount;
	[Export] private Theme LabelDayTheme;
	[Export] private Theme LabelNightTheme;

	[ExportGroup("Button")]
	[Export] private Button SwitchTimeButton;
	[Export] private Theme SwitchTimeDayTheme;
	[Export] private Theme SwitchTimeNightTheme;

	[ExportGroup("Modifier")]
	[Export] private ModifierDifficulty _modifierDifficulty;

	private int _dayCount = 0;
	private int _nightCount = 0;
	
	public override void _EnterTree()
	{
		GlobalContext.GlobalUIInstance.AfterGameSwitcher = this;
	}

	public void SwitchDayTime()
	{
		GlobalContext.TimeRebuilderInstance.RebuildForCurrentTimeType();
	}

	public void SetupSwitcherScene(int currentState)
	{
		switch (currentState)
		{
			case 0:
				DifficultyLabel.Theme = LabelDayTheme;
				LevelLabel.Theme = LabelDayTheme;
				
				SwitchTimeButton.Theme = SwitchTimeDayTheme;
				
				DayNightLabel.Theme = LabelDayTheme;
				DayNightLabelCount.Theme = LabelDayTheme;
				
				_dayCount++;
				UpdateDayNightCount();
				break;
			case 1:
				DifficultyLabel.Theme = LabelNightTheme;
				LevelLabel.Theme = LabelNightTheme;
				
				SwitchTimeButton.Theme = SwitchTimeNightTheme;
				
				DayNightLabel.Theme = LabelNightTheme;
				DayNightLabelCount.Theme = LabelNightTheme;
				
				_nightCount++;
				UpdateDayNightCount();
				//
				// GlobalContext.MainGameInstance.IncreaseDifficulty();
				// DifficultyLabel.Text = CoreTemplate.GetSpeedMultiplier().ToString();
				break;
		}
	}

	public void SetupModifierScene(string modifierText, float modifierValue)
	{
		LevelLabel.Text = modifierText;
		DifficultyLabel.Text = modifierText;
	}

	public void UpdateDayNightCount()
	{
		DayNightLabelCount.Text = $"{_dayCount}/{_nightCount}";
	}
}
