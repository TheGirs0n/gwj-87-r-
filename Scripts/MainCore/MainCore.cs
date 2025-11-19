
using System.Linq;
using Godot;

public partial class MainCore : Node2D
{
    [ExportGroup("Sub parameters")]
    [Export] public float InitialScore = 50;
    [Export] public float MinScore = 0;
    [Export] public float MaxScore = 100;
    public float CurrentScore;

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
    
    [ExportGroup("Particles Main")]
    [Export] private GpuParticles2D MainCoreParticles;
    [Export] private ParticleProcessMaterial MainCoreDayParticlesMaterial;
    [Export] private ParticleProcessMaterial MainCoreNightParticlesMaterial;
    
    [ExportGroup("Particles Battery")]
    [Export] private GpuParticles2D MainCoreBatteryParticles;
    [Export] private ParticleProcessMaterial MainCoreBatteryDayParticlesMaterial;
    [Export] private ParticleProcessMaterial MainCoreBatteryNightParticlesMaterial;
    
    public override void _EnterTree()
    {
        GlobalContext.MainCoreInstance = this;
        CurrentScore = InitialScore;
        UpdateScoreText();
        
        ProgressBar.MinValue = MinScore;
        ProgressBar.MaxValue = MaxScore;
    }

    public void UpdateScore(float score)
    {
        CurrentScore += score;
        if (CurrentScore <= MinScore)
        {
            CurrentScore = MinScore;
            GlobalContext.MainGameInstance.GameOver(GameOverType.MIN_CHARGE);
        }
        else if (CurrentScore >= MaxScore)
        {
            CurrentScore = MaxScore;
            GlobalContext.MainGameInstance.GameOver(GameOverType.MAX_CHARGE);
        }
        
        UpdateScoreText();
    }

    public void ResetBatteryCharge()
    {
        CurrentScore = InitialScore;
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
                MainCoreBatteryParticles.ProcessMaterial = MainCoreBatteryDayParticlesMaterial;
                break;
            case TimeType.NIGHT:
                MainCoreSprite.Texture = MainCoreNightSprite;
                ProgressBar.TextureUnder = ProgressBarNightUnder;
                ProgressBar.TextureProgress = ProgressBarNightProgress;
                MainCoreParticles.ProcessMaterial = MainCoreNightParticlesMaterial;
                MainCoreBatteryParticles.ProcessMaterial = MainCoreBatteryNightParticlesMaterial;
                break;
        }
    }
    
    private void UpdateScoreText()
    {
        ProgressBar.Value = CurrentScore;
    }

}