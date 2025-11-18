using Godot;

public partial class MainGameUI : Control
{
    [ExportGroup("Texts")]
    [Export] public RichTextLabel PlayerLeftTime;
    [Export] public RichTextLabel PlayerLabelTime;

    [ExportGroup("Text Themes")]
    [Export] public Theme LabelsDayTheme;
    [Export] public Theme LabelsNightTheme;
    
    
    
    public void UpdateScoreText(int newTimeValue)
    {
        PlayerLeftTime.Text = newTimeValue.ToString();
    }

    public void RebuildForCurrentTime(TimeType timeType)
    {
        switch (timeType)
        {
            case TimeType.DAY:
                PlayerLeftTime.Theme = LabelsDayTheme;
                PlayerLabelTime.Theme = LabelsDayTheme;
                break;
            case TimeType.NIGHT:
                PlayerLeftTime.Theme = LabelsNightTheme;
                PlayerLabelTime.Theme = LabelsNightTheme;
                break;
        }
    }
}