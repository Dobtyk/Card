using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Deck
{
    public class ScreenVictoryTournamentController
    {
        readonly ScreenVictoryTournamentView _view;
        readonly InformationPlayer _informationPlayer;

        public ScreenVictoryTournamentController(ScreenVictoryTournamentView view, InformationPlayer informationPlayer)
        {
            _view = view;
            _informationPlayer = informationPlayer;

            informationPlayer.PointsPlayerChanged += OnPointsPlayerChanged;

            FillBuffs();
        }

        string ChooseWord(string points)
        {
            var numbersTwo = new List<string> { "11", "12", "13", "14" };
            var numbersOne = new List<string> { "5", "6", "7", "8", "9", "0" };
            if ((points.Length >= 2 && numbersTwo.Any(item => item.Equals(points[^2..]))) || numbersOne.Any(item => item.Equals(points[^1..])))
            {
                return "�����";
            }
            else if ("1".Equals(points[^1..]))
            {
                return "����";
            }
            else
            {
                return "����";
            }
        }

        void OnPointsPlayerChanged(int points)
        {
            if (_informationPlayer.PointsPlayer >= DefaultLevels.Levels.FirstOrDefault(level => level.NumberLevel == DataHolder.CurrentLevel).Points && DataHolder.CurrentLevel == 8)
            {
                _view.AmountPoints = _informationPlayer.PointsPlayer + " " + ChooseWord(_informationPlayer.PointsPlayer.ToString());
                _view.NameBlind = DefaultLevels.Levels.FirstOrDefault(level => level.NumberLevel == DataHolder.CurrentLevel).Name;
                AudioManager.Instance.ToggleMusic(Resources.Load<AudioClip>("Sound/Alternate_Card_Playing_Music"));

                _view.gameObject.SetActive(true);

                Yandexholder.SaveScore();
                Yandexholder.SaveDebuffs(new List<Effect> { DataHolder.Debuff });
            }
        }

        void FillBuffs()
        {
            for (var i = 0; i < DataHolder.Buffs.Count; i++)
            {
                _view.Buffs.GetEffectView(i).Description = DataHolder.Buffs[i].Description;
                _view.Buffs.GetEffectView(i).ImageSprite = DataHolder.Buffs[i].Sprite;
            }
            for (var i = 4; i >= DataHolder.Buffs.Count; i--)
            {
                _view.Buffs.GetEffectView(i).gameObject.SetActive(false);
            }
        }
    }
}