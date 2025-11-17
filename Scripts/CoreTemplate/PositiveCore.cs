
using Godot;

public partial class PositiveCore : CoreTemplate
{
    public override void _Ready()
    {
        _targetMainCore = GlobalContext.MainCoreInstance;
    }

    public override void _PhysicsProcess(double delta)
    {
        MoveToMainCore((float)delta);
    }
    
    public override void RebuildForCurrentTimeType(TimeType timeType)
    {
        switch (timeType)
        {
            case TimeType.DAY:
                CoreEntryAction = CoreEntryAction.POSITIVE;
                CoreDestroyAction = CoreDestroyAction.NEGATIVE;

                CoreSprite.Texture = CoreDaySprite;
                break;
            case TimeType.NIGHT:
                CoreEntryAction = CoreEntryAction.NEGATIVE;
                CoreDestroyAction = CoreDestroyAction.POSITIVE;
        
                CoreSprite.Texture = CoreNightSprite;
                break;
        }
        
        SwapPolarityScores(timeType);
    }

    public override void SwapPolarityScores(TimeType timeType)
    {
        switch (timeType)
        {
            case TimeType.DAY:
                ScoreFromEntry = NegativeScore;
                ScoreFromDestroy = PositiveScore;
                break;
            case TimeType.NIGHT:
                ScoreFromEntry = PositiveScore;
                ScoreFromDestroy = NegativeScore;
                break;
        }
    }
    
    public override void MoveToMainCore(float delta)
    {
        if (_targetMainCore == null)
            return;
		
        var direction = (_targetMainCore.GlobalPosition - GlobalPosition).Normalized();
		
        Velocity = direction * CoreSpeed * SpeedMultiplier;
		
        MoveAndSlide();
    }
}