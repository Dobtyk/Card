namespace Deck
{
    public class ScreenVictoryController
    {
        readonly ScreenVictoryView _view;
        readonly InformationPlayer _informationPlayer;

        public ScreenVictoryController(ScreenVictoryView view, InformationPlayer informationPlayer)
        {
            _view = view;
            _informationPlayer = informationPlayer;

            informationPlayer.PointsPlayerChanged += OnPointsPlayerChanged;
        }

        void OnPointsPlayerChanged(int points)
        {
            if (_informationPlayer.PointsPlayer >= DataHolder.CurrentLevelPoints)
            {
                _view.gameObject.SetActive(true);
                DataHolder.TotalNumberPointsScored += _informationPlayer.PointsPlayer;
            }
        }
    }
}