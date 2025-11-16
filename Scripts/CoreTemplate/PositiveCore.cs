
public partial class PositiveCore : CoreTemplate
{
    public override void RebuildForDay()
    {
        CoreEntryAction = CoreEntryAction.POSITIVE;
        CoreDestroyAction = CoreDestroyAction.NEGATIVE;

        CoreSprite.Texture = CoreDaySprite;
        SwapPolarityScores();
    }

    public override void RebuildForNight()
    {
        CoreEntryAction = CoreEntryAction.NEGATIVE;
        CoreDestroyAction = CoreDestroyAction.POSITIVE;
        
        CoreSprite.Texture = CoreDaySprite;
        SwapPolarityScores();
    }
    
    public override void SwapPolarityScores()
    {
        (ScoreFromEntry, ScoreFromDestroy) = (ScoreFromDestroy, ScoreFromEntry);
    }
}