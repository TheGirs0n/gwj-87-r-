
using Godot;

public partial class MainGame : Node
{
    [Export] private Timer _timer;

    public override void _Ready()
    {
        GlobalContext.MainGameInstance = this;
    }

    public override void _Process(double delta)
    {
        GlobalContext.GlobalUIInstance.MainGameUi.UpdateScoreText((int)_timer.TimeLeft);
    }

    public void TimeIsOver()
    {
        // переход в магазин
    }
}
