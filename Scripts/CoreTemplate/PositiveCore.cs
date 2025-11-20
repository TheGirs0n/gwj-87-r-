
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
                CoreSprite.Texture = CoreDaySprite;
                CoreParticles.ProcessMaterial = CoreParticleDayProcessMaterial;
                break;
            case TimeType.NIGHT:
                CoreSprite.Texture = CoreNightSprite;
                CoreParticles.ProcessMaterial = CoreParticleNightProcessMaterial;
                break;
        }
        
        SwapPolarityScores(timeType);
    }

    public override void SwapPolarityScores(TimeType timeType)
    {
        switch (timeType)
        {
            case TimeType.DAY:
                ScoreFromEntry = PositiveScore;
                ScoreFromDestroy = NegativeScore;
                break;
            case TimeType.NIGHT:
                ScoreFromEntry = NegativeScore;
                ScoreFromDestroy = PositiveScore;
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