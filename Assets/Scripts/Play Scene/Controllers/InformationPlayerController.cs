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

            view.NameBlind = DefaultLevels.Levels.FirstOrDefault(level => level.NumberLevel == DataHolder.CurrentLevel).Name;
            view.CurrentLevelPoints = "Минимум очков\n" + DataHolder.CurrentLevelPoints;
            view.NumberLevel = DataHolder.CurrentLevel + "/" + DataHolder.MaxLevel;
            view.AmountHands = informationPlayer.AmountHands + "/" + DataHolder.MaxAmountHands;
            view.AmountResets = informationPlayer.AmountResets + "/" + DataHolder.MaxAmountResets;
            view.PointsPlayer = informationPlayer.PointsPlayer.ToString();

            _currentCombinationController = new CurrentCombinationController(currentCombination, view.CurrentCombinationView);
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