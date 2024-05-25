namespace Deck
{
    public class ScreenPlayController
    {
        readonly PlayerHandController _playerHandController;
        readonly ScreenPlayView _view;
        readonly InformationPlayerController _informationPlayerController;

        public ScreenPlayController(ScreenPlayView view, IReadOnlyPlayerHand playerHand, IReadOnlyCurrentCombination currentCombination, IReadOnlyInformationPlayer informationPlayer)
        {
            _view = view;

            _informationPlayerController = new InformationPlayerController(view.InformationPlayerView, currentCombination, informationPlayer);
            _playerHandController = new PlayerHandController(playerHand, _view.PlayerHandView);
        }
    }
}