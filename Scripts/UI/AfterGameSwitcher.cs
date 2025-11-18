using Godot;
using System;

public partial class AfterGameSwitcher : Control
{
	public void SwitchDayTime()
	{
		GlobalContext.TimeRebuilderInstance.RebuildForCurrentTimeType();
	}
}
