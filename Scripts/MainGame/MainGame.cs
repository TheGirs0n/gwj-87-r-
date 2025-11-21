using Godot;

public partial class MainGame : Node
{
    [ExportGroup("Timer")]
    [Export] private Timer _timer;
    
    [ExportGroup("Mini Cores")]
    [Export] private Node _miniCoresPool;
    [Export] private SpawnMiniCores _spawnMiniCores;
    
    [ExportGroup("Environment")]
    [Export] private WorldEnvironment _worldEnvironment;
        
    [ExportGroup("Particles Main")]
    [Export] private GpuParticles2D MainCoreParticles;
    [Export] private ParticleProcessMaterial MainCoreDayParticlesMaterial;
    [Export] private ParticleProcessMaterial MainCoreNightParticlesMaterial;
    
    [ExportGroup("Particles Back")]
    [Export] private GpuParticles2D MainCoreBaackParticles;
    [Export] private ParticleProcessMaterial MainCoreBackDayParticlesMaterial;
    [Export] private ParticleProcessMaterial MainCoreBackNightParticlesMaterial;
    
    public bool IsSwitcherOpened = false;
    
    public override void _EnterTree()
    {
        GlobalContext.MainGameInstance = this;
    }
    
    public override void _ExitTree()
    {
        GlobalContext.MainGameInstance = null;
    }

    public void ResetGame()
    {
        _timer.Start();
    }

    
    public override void _Process(double delta)
    {
        if (Input.IsKeyPressed(Key.Escape))
        {
            StopGame();
        }
        
        GlobalContext.GlobalUIInstance.MainGameUi.UpdateScoreText((int)_timer.TimeLeft);

        if (_timer.TimeLeft <= 0)
        {
            if (_miniCoresPool.GetChildCount() <= 0)
            {
                if(IsSwitcherOpened == false)
                    TimeIsOver();
            }
        }
    }

    public void TimeIsOver()
    {
        GlobalContext.GlobalUIInstance.AfterGameSwitcher.SetupSwitcherScene((int)GlobalContext.TimeRebuilderInstance.TimeType);
        GlobalContext.GlobalUIInstance.TimeSwitcherUIOpen();
        IsSwitcherOpened = true;
    }

    public void StopGame()
    {
        GlobalContext.GlobalUIInstance.OpenPause();
    }
    
    public void ContinueGame()
    {
        this.ProcessMode = ProcessModeEnum.Inherit;
    }

    public void GameOver(GameOverType gameOverType)
    {
        GlobalContext.GlobalUIInstance.GameOverUI.SetupScreenGameOver(gameOverType, GlobalContext.TimeRebuilderInstance.TimeType);
        GlobalContext.GlobalUIInstance.OpenGameOverUI();
        GlobalContext.MainGameInstance.QueueFree();
    }

    public void RebuildForCurrentTimeType(TimeType timeType)
    {
        switch (timeType)
        {
            case TimeType.DAY:
                ApplyLightSceneSettings();
                break;
            case TimeType.NIGHT:
                ApplyNightSceneSettings();
                break;
        }
    }
    
    #region Environment
    
    private GlowSettings _darkSceneGlow = new GlowSettings {
        Enabled = true,
        Intensity = 1.2f,
        Strength = 1.2f,
        Bloom = 0.4f,
        BlendMode = Environment.GlowBlendModeEnum.Softlight, 
        HdrThreshold = 0.8f,
        HdrScale = 1.2f
    };
    
    private GlowSettings _lightSceneGlow = new GlowSettings {
        Enabled = true,
        Intensity = 0.6f,
        Strength = 0.8f,
        Bloom = 0.3f,
        BlendMode = Environment.GlowBlendModeEnum.Screen, 
        HdrThreshold = 0.9f,
        HdrScale = 1.2f
    };
    
    private AdjustmentSettings _darkSceneAdjustments = new AdjustmentSettings {
        Enabled = true,
        Brightness = 1.0f,
        Contrast = 1.3f,
        Saturation = 1.1f
    };
    
    private AdjustmentSettings _lightSceneAdjustments = new AdjustmentSettings {
        Enabled = true,
        Brightness = 1.0f,
        Contrast = 1.0f,
        Saturation = 1.0f
    };
    
    public void ApplyNightSceneSettings()
    {
        if (_worldEnvironment?.Environment == null) return;
                
        MainCoreParticles.ProcessMaterial = MainCoreNightParticlesMaterial;
        MainCoreBaackParticles.ProcessMaterial = MainCoreBackNightParticlesMaterial;
        MainCoreBaackParticles.Restart();
        
        var env = _worldEnvironment.Environment;
        
        env.GlowEnabled = _darkSceneGlow.Enabled;
        env.GlowIntensity = _darkSceneGlow.Intensity;
        env.GlowStrength = _darkSceneGlow.Strength;
        env.GlowBloom = _darkSceneGlow.Bloom;
        env.GlowBlendMode = _darkSceneGlow.BlendMode;
        env.GlowHdrThreshold = _darkSceneGlow.HdrThreshold;
        env.GlowHdrScale = _darkSceneGlow.HdrScale;
        
        env.AdjustmentEnabled = _darkSceneAdjustments.Enabled;
        env.AdjustmentBrightness = _darkSceneAdjustments.Brightness;
        env.AdjustmentContrast = _darkSceneAdjustments.Contrast;
        env.AdjustmentSaturation = _darkSceneAdjustments.Saturation;
    }
    
    public void ApplyLightSceneSettings()
    {
        if (_worldEnvironment?.Environment == null) return;
        
        MainCoreParticles.ProcessMaterial = MainCoreDayParticlesMaterial;
        MainCoreBaackParticles.ProcessMaterial = MainCoreBackDayParticlesMaterial;
        MainCoreBaackParticles.Restart();
        
        var env = _worldEnvironment.Environment;
        
        env.GlowEnabled = _lightSceneGlow.Enabled;
        env.GlowIntensity = _lightSceneGlow.Intensity;
        env.GlowStrength = _lightSceneGlow.Strength;
        env.GlowBloom = _lightSceneGlow.Bloom;
        env.GlowBlendMode = _lightSceneGlow.BlendMode;
        env.GlowHdrThreshold = _lightSceneGlow.HdrThreshold;
        env.GlowHdrScale = _lightSceneGlow.HdrScale;
        
        env.AdjustmentEnabled = _lightSceneAdjustments.Enabled;
        env.AdjustmentBrightness = _lightSceneAdjustments.Brightness;
        env.AdjustmentContrast = _lightSceneAdjustments.Contrast;
        env.AdjustmentSaturation = _lightSceneAdjustments.Saturation;
    }

    public struct GlowSettings
    {
        public bool Enabled;
        public float Intensity;
        public float Strength;
        public float Bloom;
        public Environment.GlowBlendModeEnum BlendMode;
        public float HdrThreshold;
        public float HdrScale;
    }

    public struct AdjustmentSettings
    {
        public bool Enabled;
        public float Brightness;
        public float Contrast;
        public float Saturation;
    }
    
    #endregion
}

public enum GameOverType
{
    MAX_CHARGE,
    MIN_CHARGE,
}