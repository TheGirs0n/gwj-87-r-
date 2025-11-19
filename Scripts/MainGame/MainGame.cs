
using Godot;

public partial class MainGame : Node
{
    [ExportGroup("GameOverScene")]
    [Export] private PackedScene _gameOverScene;
    
    [ExportGroup("Timer")]
    [Export] private Timer _timer;
    
    [ExportGroup("Mini Cores")]
    [Export] private Node _miniCoresPool;
    [Export] private SpawnMiniCores _spawnMiniCores;

    public override void _EnterTree()
    {
        GlobalContext.MainGameInstance = this;
    }

    public void ResetGame()
    {
        _timer.Start();
    }

    public void IncreaseDifficulty()
    {
        CoreTemplate.IncreaseSpeedMultiplier();
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
                TimeIsOver();
            }
        }
    }

    public void TimeIsOver()
    {
        GlobalContext.GlobalUIInstance.AfterGameSwitcher.SetupSwitcherScene((int)GlobalContext.TimeRebuilderInstance.TimeType);
        GlobalContext.GlobalUIInstance.TimeSwitcherUIOpen();
    }

    public void StopGame()
    {
        this.ProcessMode = ProcessModeEnum.Disabled;
        GlobalContext.GlobalUIInstance.PauseMenuUi.Visible = true;
    }

    public void StartGame()
    {
        this.ProcessMode = ProcessModeEnum.Inherit;
    }

    public void GameOver(GameOverType gameOverType)
    {
        var scene = _gameOverScene.Instantiate<GameOverScene>();
        scene.SetupScreenGameOver(gameOverType, GlobalContext.TimeRebuilderInstance.TimeType);
        GlobalContext.MainSceneInstance.QueueFree();
    }
}

public enum GameOverType
{
    MAX_CHARGE,
    MIN_CHARGE,
}
