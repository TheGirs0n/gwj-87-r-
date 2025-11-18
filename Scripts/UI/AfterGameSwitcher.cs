using Godot;
using System;

public partial class AfterGameSwitcher : Control
{
	[Export] private RichTextLabel DifficultyLabel { get; set; }

	public override void _EnterTree()
	{
		GlobalContext.GlobalUIInstance.AfterGameSwitcher = this;
	}

	public void SwitchDayTime()
	{
		GlobalContext.TimeRebuilderInstance.RebuildForCurrentTimeType();
	}
}
