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

            FillBuffs();
        }

        void FillBuffs()
        {
            for (var i = 0; i < DataHolder.Buffs.Count; i++)
            {
                _view.BuffsView.GetBuffView(i).Description = DataHolder.Buffs[i].Description;
                _view.BuffsView.GetBuffView(i).ImageSprite = DataHolder.Buffs[i].Sprite;
            }
            for (var i = 4; i >= DataHolder.Buffs.Count; i--)
            {
                _view.BuffsView.GetBuffView(i).gameObject.SetActive(false);
            }
        }
    }
}