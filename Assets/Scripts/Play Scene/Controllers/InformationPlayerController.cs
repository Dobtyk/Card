using System.Linq;

namespace Deck
{
    public class InformationPlayerController
    {
        readonly PlayerHandController _playerHandController;
        readonly InformationPlayerView _view;
        readonly CurrentCombinationController _currentCombinationController;

        public InformationPlayerController(InformationPlayerView view, IReadOnlyCurrentCombination currentCombination, IReadOnlyInformationPlayer informationPlayer)
        {
            _view = view;

            informationPlayer.AmountResetsChanged += OnAmountResetsChanged;
            informationPlayer.AmountHandsChanged += OnAmountHandsChanged;
            informationPlayer.PointsPlayerChanged += OnPointsPlayerChanged;
            informationPlayer.NumberCardsDeckRoundChanged += OnNumberCardsDeckRoundChanged;

            view.NameBlind = DefaultLevels.Levels.FirstOrDefault(level => level.NumberLevel == DataHolder.CurrentLevel).Name;
            view.CurrentLevelPoints = DataHolder.CurrentLevelPoints.ToString();
            view.NumberLevel = DataHolder.CurrentLevel + "/" + DataHolder.MaxLevel;
            view.AmountHands = informationPlayer.AmountHands + "/" + DataHolder.MaxAmountHands;
            view.AmountResets = informationPlayer.AmountResets + "/" + DataHolder.MaxAmountResets;
            view.PointsPlayer = informationPlayer.PointsPlayer.ToString();
            view.NumberCardsDeckRound = informationPlayer.NumberCardsDeckRound + "/52";

            _currentCombinationController = new CurrentCombinationController(currentCombination, view.CurrentCombinationView);
        }

        private void OnNumberCardsDeckRoundChanged(int amount)
        {
            _view.NumberCardsDeckRound = amount + "/52";
        }

        private void OnPointsPlayerChanged(int points)
        {
            _view.PointsPlayer = points.ToString();
        }

        private void OnAmountHandsChanged(int amount)
        {
            _view.AmountHands = amount + "/" + DataHolder.MaxAmountHands;
        }

        private void OnAmountResetsChanged(int amount)
        {
            _view.AmountResets = amount + "/" + DataHolder.MaxAmountResets;
        }
    }
}