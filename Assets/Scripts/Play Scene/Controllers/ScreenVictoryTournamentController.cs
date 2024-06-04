using System;
using System.Collections.Generic;
using System.Linq;

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
                return "очков";
            }
            else if ("1".Equals(points[^1..]))
            {
                return "очко";
            }
            else
            {
                return "очка";
            }
        }

        void OnPointsPlayerChanged(int points)
        {
            if (_informationPlayer.PointsPlayer >= DefaultLevels.Levels.FirstOrDefault(level => level.NumberLevel == DataHolder.CurrentLevel).Points && DataHolder.CurrentLevel == 8)
            {
                _view.AmountPoints = _informationPlayer.PointsPlayer + " " + ChooseWord(_informationPlayer.PointsPlayer.ToString());
                _view.NameBlind = DefaultLevels.Levels.FirstOrDefault(level => level.NumberLevel == DataHolder.CurrentLevel).Name;

               
                _view.gameObject.SetActive(true);
                DataHolder.TotalNumberPointsScored += _informationPlayer.PointsPlayer;
            }
        }

        void FillBuffs()
        {
            for (var i = 0; i < DataHolder.Buffs.Count; i++)
            {
                _view.Buffs.GetBuffView(i).Description = DataHolder.Buffs[i].Description;
                _view.Buffs.GetBuffView(i).ImageSprite = DataHolder.Buffs[i].Sprite;
            }
            for (var i = 4; i >= DataHolder.Buffs.Count; i--)
            {
                _view.Buffs.GetBuffView(i).gameObject.SetActive(false);
            }
        }
    }
}