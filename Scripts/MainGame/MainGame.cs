
using Godot;

public partial class MainGame : Node
{
    [Export] private Timer _timer;
    [Export] private Node _miniCoresPool;

    public override void _EnterTree()
    {
        GlobalContext.MainGameInstance = this;
    }

    public override void _Process(double delta)
    {
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
        GlobalContext.GlobalUIInstance.TimeSwitcherUIOpen();
        //this.ProcessMode = ProcessModeEnum.Disabled;
    }
}
