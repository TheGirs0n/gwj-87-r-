
using Godot;

public partial class TimeRebuilder : Node
{
    public TimeType TimeType;

    public override void _Ready()
    {
        GlobalContext.TimeRebuilderInstance = this;
    }
    
    public void RebuildForCurrentTimeType(TimeType timeType)
    {
        GlobalContext.CoreInstance.RebuildForCurrentTimeType(TimeType);
        GlobalContext.MainCoreInstance.RebuildForCurrentTimeType(TimeType);
    }

    public void ChangeTimeType()
    {
        TimeType = TimeType == TimeType.DAY ? TimeType.NIGHT : TimeType.DAY;
    }
}


public enum TimeType
{
    DAY,
    NIGHT
}