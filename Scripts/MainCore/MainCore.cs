using Godot;

public partial class MainCore : Node2D
{
    [ExportGroup("Sub parameters")]
    [Export] public float InitialScore = 50;
    [Export] public float MinScore = 0;
    [Export] public float MaxScore = 100;
    public float CurrentScore;
    
    [ExportGroup("ProgressBar")]
    [Export] public TextureProgressBar ProgressBar;
    //[Export] public CompressedTexture2D ProgressBarDayUnder;
    [Export] public CompressedTexture2D ProgressBarDayOver;
    [Export] public CompressedTexture2D ProgressBarDayProgress;
    //[Export] public CompressedTexture2D ProgressBarNightUnder;
    [Export] public CompressedTexture2D ProgressBarNightOver;
    [Export] public CompressedTexture2D ProgressBarNightProgress;
    
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

    public override void _ExitTree()
    {
        GlobalContext.MainCoreInstance = null;
    }

    public void UpdateScore(float score)
    {
        CurrentScore += score;
        GD.Print("Score: " + CurrentScore);
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
        else
        {
            UpdateScoreText();
        }
    }

    public void RebuildForCurrentTimeType(TimeType timeType)
    {
        switch (timeType)
        {
            case TimeType.DAY:
                //ProgressBar.TextureUnder = ProgressBarDayUnder;
                ProgressBar.TextureOver = ProgressBarDayOver;
                ProgressBar.TextureProgress = ProgressBarDayProgress;
                MainCoreBatteryParticles.ProcessMaterial = MainCoreBatteryDayParticlesMaterial;
                break;
            case TimeType.NIGHT:
                //ProgressBar.TextureUnder = ProgressBarNightUnder;
                ProgressBar.TextureOver = ProgressBarNightOver;
                ProgressBar.TextureProgress = ProgressBarNightProgress;
                MainCoreBatteryParticles.ProcessMaterial = MainCoreBatteryNightParticlesMaterial;
                break;
        }
    }
    
    private void UpdateScoreText()
    {
        ProgressBar.Value = CurrentScore;
    }

}