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
            _view.BuffsView.GetBuffView(i).Description = Yandexholder.KnowBuffs[i].Description;
            _view.BuffsView.GetBuffView(i).ImageSprite = Yandexholder.KnowBuffs[i].Sprite;
        }
        for (var i = Yandexholder.KnowBuffs.Count(); i < 28; i++)
        {
            _view.BuffsView.GetBuffView(i).Description = new Unknown().Description;
            _view.BuffsView.GetBuffView(i).ImageSprite = new Unknown().Sprite;
        }
    }

    void LoadDebuffs()
    {
        for (var i = 0; i < Yandexholder.KnowDebuffs.Count(); i++)
        {
            _view.DebuffsView.GetBuffView(i).Description = Yandexholder.KnowDebuffs[i].Description;
            _view.DebuffsView.GetBuffView(i).ImageSprite = Yandexholder.KnowDebuffs[i].Sprite;
        }
        for (var i = Yandexholder.KnowDebuffs.Count(); i < 4; i++)
        {
            _view.DebuffsView.GetBuffView(i).Description = new UnknownDebuff().Description;
            _view.DebuffsView.GetBuffView(i).ImageSprite = new UnknownDebuff().Sprite;
        }
    }
}
