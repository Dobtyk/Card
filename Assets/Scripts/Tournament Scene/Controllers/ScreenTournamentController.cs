using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

namespace Deck
{
    public class ScreenTournamentController
    {
        readonly ScreenTournamentView _view;
        const int extraHeightIndicator = 100;

        public ScreenTournamentController(ScreenTournamentView view)
        {
            _view = view;
            FillBuffs();
            FillItems();
            FillEnemy(_view.EnemyView);
            FillEnemy(_view.EnemyViewDebuff);
            if (DataHolder.CurrentLevel == 8)
            {
                _view.EnemyViewDebuff.gameObject.SetActive(true);
                _view.EnemyView.gameObject.SetActive(false);
            }
            else
            {
                _view.EnemyViewDebuff.gameObject.SetActive(false);
                _view.EnemyView.gameObject.SetActive(true);
            }
        }

        void FillEnemy(EnemyView enemyView)
        {
            enemyView.NumberFight = "Бой " + DataHolder.CurrentLevel + "." + DefaultLevels.Levels.FirstOrDefault(level => level.NumberLevel == DataHolder.CurrentLevel).Name;
            enemyView.MinimumPoints = DefaultLevels.Levels.FirstOrDefault(level => level.NumberLevel == DataHolder.CurrentLevel).Points.ToString();
            enemyView.NumberVictories = "Побед: " + (DataHolder.CurrentLevel - 1);

            if (DataHolder.CurrentLevel == 8)
            {
                enemyView.Description = DataHolder.Debuff.Description;
            }
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

        void FillItems()
        {
            for (var i = 0; i < 8; i++)
            {
                _view.ItemsView.GetItemView(i).ImageSprite.sprite = DefaultLevels.Levels.FirstOrDefault(level => level.NumberLevel == (i + 1)).Icon;
                _view.ItemsView.GetItemView(i).Text.text = DefaultLevels.Levels.FirstOrDefault(level => level.NumberLevel == (i + 1)).Name;
            }
            for (var i = 0; i < DataHolder.CurrentLevel - 1; i++)
            {
                _view.ItemsView.GetItemView(i).ImageSprite.gameObject.SetActive(false);
                _view.ItemsView.GetItemView(i).Field = Resources.Load<Sprite>("SceneTournament/Затемнённая плашка");
                _view.ItemsView.GetItemView(i).Text.color = new Color32(121, 116, 109, 255);
            }

            var x = _view.Indicator.transform.localPosition.x;
            var y = _view.Indicator.transform.localPosition.y;
            var z = _view.Indicator.transform.localPosition.z;
            _view.Indicator.transform.localPosition = new Vector3 { x = x, y = y + (extraHeightIndicator * (DataHolder.CurrentLevel - 1)), z = z };
        }
    }
}
