using System;

namespace Deck
{
    public class InformationPlayerController
    {
        readonly PlayerHandController _playerHandController;
        readonly InformationPlayerView _view;
        readonly CurrentCombinationController _currentCombinationController;

        public InformationPlayerController(InformationPlayerView view, CurrentCombination currentCombination, InformationPlayer informationPlayer)
        {
            _view = view;

            informationPlayer.AmountResetsChanged += OnAmountResetsChanged;
            informationPlayer.AmountHandsChanged += OnAmountHandsChanged;
            informationPlayer.PointsPlayerChanged += OnPointsPlayerChanged;

            view.AmountHands = informationPlayer.AmountHands + "/3";
            view.AmountResets = informationPlayer.AmountResets + "/3";
            view.PointsPlayer = informationPlayer.PointsPlayer.ToString();

            _currentCombinationController = new CurrentCombinationController(currentCombination, view.CurrentCombinationView);
        }

        private void OnPointsPlayerChanged(int points)
        {
            _view.PointsPlayer = points.ToString();
        }

        private void OnAmountHandsChanged(int amount)
        {
            _view.AmountHands = amount + "/3";
        }

        private void OnAmountResetsChanged(int amount)
        {
            _view.AmountResets = amount + "/3";
        }
    }
}