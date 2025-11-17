using Godot;

public partial class MainGameUI : Control
{
    [Export] public RichTextLabel PlayerLeftTime;

    public void UpdateScoreText(int newTimeValue)
    {
        PlayerLeftTime.Text = newTimeValue.ToString();
    }
}