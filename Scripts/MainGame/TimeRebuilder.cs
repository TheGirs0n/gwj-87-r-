
using Godot;

public partial class TimeRebuilder : Node
{
    public TimeType TimeType;

    public override void _EnterTree()
    {
        GlobalContext.TimeRebuilderInstance = this;
    }
    
    public void RebuildForCurrentTimeType()
    {
        ChangeTimeType();
        GlobalContext.GlobalUIInstance.MainSceneUIOpen();
        GlobalContext.GlobalUIInstance.MainGameUi.RebuildForCurrentTime(TimeType);
        GlobalContext.GlobalUIInstance.BackgroundLayer.RebuildForCurrentTimeType(TimeType);
        GlobalContext.MainCoreInstance.RebuildForCurrentTimeType(TimeType);
        GlobalContext.MainGameInstance.ResetGame();
    }
    
    public void RebuildForCurrentTimeType(TimeType timeType)
    {
        GlobalContext.GlobalUIInstance.MainSceneUIOpen();
        GlobalContext.MainCoreInstance.RebuildForCurrentTimeType(TimeType);
        GlobalContext.GlobalUIInstance.MainGameUi.RebuildForCurrentTime(TimeType);
        GlobalContext.GlobalUIInstance.BackgroundLayer.RebuildForCurrentTimeType(TimeType);
        GlobalContext.MainGameInstance.ResetGame();
    }

    private void ChangeTimeType()
    {
        TimeType = TimeType == TimeType.DAY ? TimeType.NIGHT : TimeType.DAY;
    }
}


public enum TimeType
{
    DAY,
    NIGHT
}