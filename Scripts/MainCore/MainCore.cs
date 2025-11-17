
using System.Linq;
using Godot;

public partial class MainCore : Node2D
{
    [ExportGroup("Sub parameters")]
    [Export] private MainCoreTurretPool _mainCoreTurretPool;
    [Export] public int Score = 50;

    [ExportGroup("SpriteSetting")]
    [Export] public Sprite2D MainCoreSprite;
    [Export] public CompressedTexture2D MainCoreDaySprite;
    [Export] public CompressedTexture2D MainCoreNightSprite;
    
    [ExportGroup("Text")]
    [Export] public RichTextLabel ScoreLabel;
    [Export] public Theme ScoreDayLabelTheme;
    [Export] public Theme ScoreNightLabelTheme;
    
    [ExportGroup("Particles")]
    [Export] private GpuParticles2D MainCoreParticles;
    [Export] private ParticleProcessMaterial MainCoreDayParticlesMaterial;
    [Export] private ParticleProcessMaterial MainCoreNightParticlesMaterial;
    
    public override void _EnterTree()
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

        UpdateScoreText();
        GD.Print("Score: " + Score);
    }

    private void UpdateScoreText()
    {
        ScoreLabel.Text = Score.ToString();
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
                MainCoreParticles.ProcessMaterial = MainCoreDayParticlesMaterial;
                break;
            case TimeType.NIGHT:
                MainCoreSprite.Texture = MainCoreNightSprite;
                ScoreLabel.Theme = ScoreNightLabelTheme;
                MainCoreParticles.ProcessMaterial = MainCoreNightParticlesMaterial;
                break;
        }

        _mainCoreTurretPool.RebuildTurrets(timeType);
    }
}