
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
    
    [ExportGroup("ProgressBar")]
    [Export] public TextureProgressBar ProgressBar;
    [Export] public CompressedTexture2D ProgressBarDayUnder;
    [Export] public CompressedTexture2D ProgressBarDayProgress;
    [Export] public CompressedTexture2D ProgressBarNightUnder;
    [Export] public CompressedTexture2D ProgressBarNightProgress;
    
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
        ProgressBar.Value = Score;
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
                ProgressBar.TextureUnder = ProgressBarDayUnder;
                ProgressBar.TextureProgress = ProgressBarDayProgress;
                MainCoreParticles.ProcessMaterial = MainCoreDayParticlesMaterial;
                break;
            case TimeType.NIGHT:
                MainCoreSprite.Texture = MainCoreNightSprite;
                ProgressBar.TextureUnder = ProgressBarNightUnder;
                ProgressBar.TextureProgress = ProgressBarNightProgress;
                MainCoreParticles.ProcessMaterial = MainCoreNightParticlesMaterial;
                break;
        }

        _mainCoreTurretPool.RebuildTurrets(timeType);
    }
}