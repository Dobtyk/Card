namespace Deck
{
    public class ScreenTournamentStatisticsController
    {
        readonly ScreenTournamentStatisticsView _view;
        readonly InformationPlayer _informationPlayer;

        public ScreenTournamentStatisticsController(ScreenTournamentStatisticsView view, InformationPlayer informationPlayer)
        {
            _view = view;
            _informationPlayer = informationPlayer;

            informationPlayer.PointsPlayerChanged += OnPointsPlayerChanged;
        }

        void OnPointsPlayerChanged(int points)
        {
                _view.LastCombination = DataHolder.LastCombination;
                _view.NumberPointsScored = DataHolder.TotalNumberPointsScored.ToString();
                _view.NumberResetsUsed = DataHolder.NumberResetsUsed.ToString();
                _view.NumberCardsPlayed = DataHolder.NumberCardsPlayed.ToString();
        }
    }
}