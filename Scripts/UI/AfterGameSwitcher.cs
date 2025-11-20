using System;
using Godot;

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

	public int DayCount = 0;
	public int NightCount = 0;
	
	public override void _EnterTree()
	{
		GlobalContext.GlobalUIInstance.AfterGameSwitcher = this;
	}

	public void SwitchDayTime()
	{
		GlobalContext.TimeRebuilderInstance.RebuildForCurrentTimeType();
		GlobalContext.MainGameInstance.IsSwitcherOpened = false;
	}

	public void SetupSwitcherScene(int currentState)
	{
		switch (currentState)
		{
			case 0:
				DifficultyLabel.Theme = LabelDayTheme;
				LevelLabel.Theme = LabelDayTheme;
				
				DifficultyLabel.Visible = false;
				LevelLabel.Visible = false;
				
				SwitchTimeButton.Theme = SwitchTimeDayTheme;
				
				DayNightLabel.Theme = LabelDayTheme;
				DayNightLabelCount.Theme = LabelDayTheme;
				
				DayCount++;
				UpdateDayNightCount();
				break;
			case 1:
				_modifierDifficulty.ApplyRandomModifierDifficulty();
				DifficultyLabel.Theme = LabelNightTheme;
				LevelLabel.Theme = LabelNightTheme;
				
				SwitchTimeButton.Theme = SwitchTimeNightTheme;
				
				DayNightLabel.Theme = LabelNightTheme;
				DayNightLabelCount.Theme = LabelNightTheme;
				
				NightCount++;
				UpdateDayNightCount();
				break;
		}
	}

	public void SetupModifierScene(string modifierText, float modifierValue, float newValue)
	{
		LevelLabel.Text = modifierText;
		DifficultyLabel.Text = $"{modifierValue} => {Math.Round(newValue, 2)}";
		
		DifficultyLabel.Visible = true;
		LevelLabel.Visible = true;
	}

	public void UpdateDayNightCount()
	{
		DayNightLabelCount.Text = $"{DayCount}/{NightCount}";
	}
}
