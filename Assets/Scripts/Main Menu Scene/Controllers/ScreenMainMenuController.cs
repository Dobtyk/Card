using Deck;
using System.Collections.Generic;
using System.Linq;

public class ScreenMainMenuController
{
    readonly ScreenMainMenuView _view;
    List<Effect> _knowBuffs;

    public ScreenMainMenuController(ScreenMainMenuView view)
    {
        _view = view;

        LoadBuffs();
        LoadDebuffs();
        LoadPlayers();
    }

    void LoadPlayers()
    {
        if (Yandexholder.Players == null)
        {
            return;
        }
        for (var i = 0; i < Yandexholder.Players.Count(); i++)
        {

            _view.FieldsRatingView.GetFieldRatingView(i).TextName = Yandexholder.Players[i].name;
            _view.FieldsRatingView.GetFieldRatingView(i).TextPoints = Yandexholder.Players[i].score.ToString();
        }
    }

    void LoadBuffs()
    {
        for (var i = 0; i < Yandexholder.KnowBuffs.Count(); i++)
        {
            _view.BuffsView.GetEffectView(i).Description = Yandexholder.KnowBuffs[i].Description;
            _view.BuffsView.GetEffectView(i).ImageSprite = Yandexholder.KnowBuffs[i].Sprite;
        }
        for (var i = Yandexholder.KnowBuffs.Count(); i < 28; i++)
        {
            _view.BuffsView.GetEffectView(i).Description = new UnknownBuff().Description;
            _view.BuffsView.GetEffectView(i).ImageSprite = new UnknownBuff().Sprite;
        }
    }

    void LoadDebuffs()
    {
        for (var i = 0; i < Yandexholder.KnowDebuffs.Count(); i++)
        {
            _view.DebuffsView.GetEffectView(i).Description = Yandexholder.KnowDebuffs[i].Description;
            _view.DebuffsView.GetEffectView(i).ImageSprite = Yandexholder.KnowDebuffs[i].Sprite;
        }
        for (var i = Yandexholder.KnowDebuffs.Count(); i < 4; i++)
        {
            _view.DebuffsView.GetEffectView(i).Description = new UnknownDebuff().Description;
            _view.DebuffsView.GetEffectView(i).ImageSprite = new UnknownDebuff().Sprite;
        }
    }
}
