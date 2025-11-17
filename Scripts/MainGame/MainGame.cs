
using Godot;

public partial class MainGame : Node
{
    [Export] private Timer _timer;

    public TimeType TimeType;

    public void SetDay()
    {
        TimeType = TimeType.DAY;
    }

    public void SetNight()
    {
        TimeType = TimeType.NIGHT;
    }

    public void TimeIsOver()
    {
        
    }
}

public enum TimeType
{
    DAY,
    NIGHT
}