using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace Deck
{
    public class ScreenVictoryController
    {
        readonly ScreenVictoryView _view;
        readonly InformationPlayer _informationPlayer;
        readonly List<Effect> _buffs;

        public ScreenVictoryController(ScreenVictoryView view, InformationPlayer informationPlayer, List<Effect> buffs)
        {
            _view = view;
            _informationPlayer = informationPlayer;
            _buffs = buffs;

            informationPlayer.PointsPlayerChanged += OnPointsPlayerChanged;
            for (var i = 0; i < 3; i++)
            {
                buffs[i].IsSelected += OnIsSelected;
            }
        }

        private void OnIsSelected(bool obj)
        {
            _view.BuffsView.gameObject.SetActive(false);
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
            if (_informationPlayer.PointsPlayer >= DefaultLevels.Levels.FirstOrDefault(level => level.NumberLevel == DataHolder.CurrentLevel).Points && DataHolder.CurrentLevel <= 7)
            {
                _view.AmountPoints = _informationPlayer.PointsPlayer + " " + ChooseWord(_informationPlayer.PointsPlayer.ToString());
                _view.NameBlind = DefaultLevels.Levels.FirstOrDefault(level => level.NumberLevel == DataHolder.CurrentLevel).Name;

                if (DataHolder.CurrentLevel <= 2)
                {
                    _view.BuffsView.gameObject.SetActive(false);
                }
                for (var i  = 0; i < 3; i++)
                {     
                    _view.BuffsView.GetBuffView(i).Description = _buffs[i].Description;
                    _view.BuffsView.GetBuffView(i).ImageSprite = _buffs[i].Sprite;
                }
               
                _view.gameObject.SetActive(true);
                DataHolder.TotalNumberPointsScored += _informationPlayer.PointsPlayer;
                if (DataHolder.CurrentLevel == 7)
                {
                    var debuffs = new List<Effect> { new Heart(), new Diamond(), new Club(), new Spade() };
                    var random = new Random();
                    DataHolder.Debuff = debuffs[random.Next(0, debuffs.Count)];
                }
            }
        }
    }
}