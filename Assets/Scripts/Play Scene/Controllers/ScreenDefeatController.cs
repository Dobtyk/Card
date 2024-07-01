using System.Linq;
using UnityEngine;

namespace Deck
{
    public class ScreenDefeatController
    {
        readonly ScreenDefeatView _view;
        readonly InformationPlayer _informationPlayer;

        public ScreenDefeatController(ScreenDefeatView view, InformationPlayer informationPlayer)
        {
            _view = view;
            _informationPlayer = informationPlayer;

            informationPlayer.PointsPlayerChanged += OnPointsPlayerChanged;
        }

        void OnPointsPlayerChanged(int points)
        {
            if (_informationPlayer.PointsPlayer < DefaultLevels.Levels.FirstOrDefault(level => level.NumberLevel == DataHolder.CurrentLevel).Points && _informationPlayer.AmountHands == 0)
            {
                _view.gameObject.SetActive(true);

                _view.LastCombination = DataHolder.LastCombination;
                _view.NumberPointsScored = DataHolder.TotalNumberPointsScored.ToString();
                _view.NumberResetsUsed = DataHolder.NumberResetsUsed.ToString();
                _view.NumberCardsPlayed = DataHolder.NumberCardsPlayed.ToString();

                if (DefaultLevels.Levels.FirstOrDefault(level => level.NumberLevel == DataHolder.CurrentLevel).IsDebuff)
                {
                    AudioManager.Instance.ToggleMusic(Resources.Load<AudioClip>("Sound/Alternate_Card_Playing_Music"));
                }

                Yandexholder.SaveScore();
            }
        }
    }
}