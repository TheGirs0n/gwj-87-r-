
using Godot;

public partial class MainCoreTurret : Node2D
{
    [ExportGroup("Sprite")] 
    [Export] private Sprite2D _turretSprite;
    [Export] private CompressedTexture2D _turretDaySprite;
    [Export] private CompressedTexture2D _turretNightSprite;
    
    private bool _canShoot = true;
    private TimeType _timeType;

    public void DestroyNegativeEntryMiniCore(Node2D target)
    {
        if (_timeType == TimeType.DAY)
        {
            if (target is NegativeCore negativeCore)
            {
                var score = negativeCore.ScoreFromDestroy;
                GlobalContext.MainCoreInstance.UpdateScore(score);
            }
        }
        else
        {
            if (target is PositiveCore positiveCore)
            {
                var score = positiveCore.ScoreFromDestroy;
                GlobalContext.MainCoreInstance.UpdateScore(score);
            } 
        }
    }

    public void RebuildForCurrentTimeType(TimeType timeType)
    {
        switch (timeType)
        {
            case TimeType.DAY:
                _turretSprite.Texture = _turretDaySprite;
                _timeType = TimeType.DAY;
                break;
            case TimeType.NIGHT:
                _turretSprite.Texture = _turretNightSprite;
                _timeType = TimeType.NIGHT;
                break;
        }
    }
}