namespace Deck
{
    public class ScreenDefeatController
    {
        public ScreenDefeatController(ScreenDefeatView view)
        {
            view.LastCombination = DataHolder.LastCombination;
            view.NumberPointsScored = DataHolder.NumberPointsScored.ToString();
            view.NumberResetsUsed = DataHolder.NumberResetsUsed.ToString();
            view.NumberCardsPlayed = DataHolder.NumberCardsPlayed.ToString();
            view.NumberLevel = DataHolder.CurrentLevel + "/" + DataHolder.MaxLevel;
        }
    }
}