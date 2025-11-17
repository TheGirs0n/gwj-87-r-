using Godot;
using System;

public partial class ShopUi : Control
{
	[Export] public RichTextLabel ScoreText;

	public void UpdateScoreText(int newValueScore)
	{
		ScoreText.Text = newValueScore.ToString();
	}
}
