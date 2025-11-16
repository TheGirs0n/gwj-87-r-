
public partial class NegativeCore : CoreTemplate
{
    public override void RebuildForDay()
    {
        CoreEntryAction = CoreEntryAction.NEGATIVE;
        CoreDestroyAction = CoreDestroyAction.POSITIVE;

        CoreSprite.Texture = CoreDaySprite;
        SwapPolarityScores();
    }

    public override void RebuildForNight()
    {
        CoreEntryAction = CoreEntryAction.POSITIVE;
        CoreDestroyAction = CoreDestroyAction.NEGATIVE;
        
        CoreSprite.Texture = CoreNightSprite;
        SwapPolarityScores();
    }

    public override void SwapPolarityScores()
    {
        (ScoreFromEntry, ScoreFromDestroy) = (ScoreFromDestroy, ScoreFromEntry);
    }
}