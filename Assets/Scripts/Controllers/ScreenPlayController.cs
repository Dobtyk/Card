namespace Deck
{
    public class ScreenPlayController
    {
        readonly PlayerHandController _playerHandController;
        readonly ScreenPlayView _view;
        readonly CurrentCombinationController _currentCombinationController;
        readonly InformationPlayerController _informationPlayerController;

        public ScreenPlayController(ScreenPlayView view, IReadOnlyPlayerHand playerHand, CurrentCombination currentCombination, InformationPlayer informationPlayer)
        {
            _view = view;
            _informationPlayerController = new InformationPlayerController(view.InformationPlayerView, currentCombination, informationPlayer);
            _playerHandController = new PlayerHandController(playerHand, _view.PlayerHandView);
        }
    }
}