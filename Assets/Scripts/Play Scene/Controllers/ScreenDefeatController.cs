namespace Deck
{
    public class ScreenDefeatController
    {
        readonly ScreenDefeatView _view;
        readonly InformationPlayer _informationPlayer;

        public ScreenDefeatController(ScreenDefeatView view, InformationPlayer informationPlayer)
        {
            _view = view;
            _informationPlayer = informationPlayer;

            informationPlayer.PointsPlayerChanged += OnPointsPlayerChanged;
        }

        void OnPointsPlayerChanged(int points)
        {
            if (_informationPlayer.PointsPlayer < DataHolder.CurrentLevelPoints && _informationPlayer.AmountHands == 0)
            {
                _view.gameObject.SetActive(true);
                DataHolder.TotalNumberPointsScored += _informationPlayer.PointsPlayer;

                _view.LastCombination = DataHolder.LastCombination;
                _view.NumberPointsScored = DataHolder.TotalNumberPointsScored.ToString();
                _view.NumberResetsUsed = DataHolder.NumberResetsUsed.ToString();
                _view.NumberCardsPlayed = DataHolder.NumberCardsPlayed.ToString();
            }
        }
    }
}