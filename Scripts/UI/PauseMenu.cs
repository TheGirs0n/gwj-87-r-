using Godot;
using System;

public partial class PauseMenu : Control
{
	public void ContinueGame()
	{
		GlobalContext.MainGameInstance.StartGame();	
		this.Visible = false;
	}

	public void Setting()
	{
		
	}

	public void ExitGame()
	{
		
	}
}
