
using System.Linq;
using Godot;

public partial class MainCore : Node2D
{
    [ExportGroup("Sub parameters")]
    [Export] private MainCoreTurretPool _mainCoreTurretPool;
    [Export] private RichTextLabel _scoreLabel;
    [Export] public int Score;

    [ExportGroup("SpriteSetting")]
    [Export] public Sprite2D MainCoreSprite;
    [Export] public CompressedTexture2D MainCoreDaySprite;
    [Export] public CompressedTexture2D MainCoreNightSprite;
    
    [ExportGroup("Text")]
    [Export] public RichTextLabel ScoreLabel;
    [Export] public Theme ScoreDayLabelTheme;
    [Export] public Theme ScoreNightLabelTheme;
    
    
    public override void _Ready()
    {
        GlobalContext.MainCoreInstance = this;
    }

    public void UpdateScore(int score)
    {
        Score += score;

        if (Score < 0)
        {
            Score = 0;
        }
    }

    public void AddTurretFromPool()
    {
        _mainCoreTurretPool.GetNewTurret();
    }

    public void RebuildForCurrentTimeType(TimeType timeType)
    {
        switch (timeType)
        {
            case TimeType.DAY:
                MainCoreSprite.Texture = MainCoreDaySprite;
                ScoreLabel.Theme = ScoreDayLabelTheme;
                break;
            case TimeType.NIGHT:
                MainCoreSprite.Texture = MainCoreNightSprite;
                ScoreLabel.Theme = ScoreNightLabelTheme;
                break;
        }

        _mainCoreTurretPool.RebuildTurrets(timeType);
    }
}