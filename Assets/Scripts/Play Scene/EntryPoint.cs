using System.Collections.Generic;
using System.Linq;
using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Deck
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] ScreenPlayView _screenPlayView;
        [SerializeField] ScreenDefeatView _screenDefeatView;
        [SerializeField] ScreenTournamentStatisticsView _screenTournamentStatisticsView;
        [SerializeField] ScreenVictoryView _screenVictoryView;
        [SerializeField] ScreenVictoryTournamentView _screenVictoryTournamentView;
        [SerializeField] GameObject _screenCardCombo;
        [SerializeField] GameObject _screenSettings;

        DeckRound _deckRound = new DeckRound(new DeckRoundData());
        PlayerHand _playerHand = new PlayerHand(new PlayerHandData());
        CurrentCombination _currentCombination = new CurrentCombination(new CombinationData());
        InformationPlayer _informationPlayer;
        List<Buff> _buffs;

        ScreenPlayController _screenPlayController;
        ScreenDefeatController _screenDefeatController;
        ScreenVictoryController _screenVictoryController;
        ScreenTournamentStatisticsController _screenTournamentStatisticsController;
        ScreenVictoryTournamentController _screenVictoryTournamentController;

        List<int> _selected�ardsIndex = new();

        void Awake()
        {
            LoadLevel();
        }

        private void LoadLevel()
        {
            foreach (var item in DataHolder.Deck.CardsDeck)
            {
                _deckRound.CardsDeckRound.Add(new SlotCard(new CardData { Suit = item.Suit, CardValue = item.CardValue, Points = item.Points, Sprite = item.Sprite }));
            }
            _playerHand.CardsPlayerHand = _deckRound.TakeRandomCards(8);
            _informationPlayer = new InformationPlayer(new InformationPlayerData { AmountHands = DataHolder.MaxAmountHands, AmountResets = DataHolder.MaxAmountResets, NumberCardsDeckRound = 44 });
            _buffs = GetBuffs();

            _screenPlayController = new ScreenPlayController(_screenPlayView, _playerHand, _currentCombination, _informationPlayer);
            _screenDefeatController = new ScreenDefeatController(_screenDefeatView, _informationPlayer);
            _screenTournamentStatisticsController = new ScreenTournamentStatisticsController(_screenTournamentStatisticsView, _informationPlayer);
            _screenVictoryController = new ScreenVictoryController(_screenVictoryView, _informationPlayer, _buffs);
            _screenVictoryTournamentController = new ScreenVictoryTournamentController(_screenVictoryTournamentView, _informationPlayer);
        }

        public void ClickOnCard(int index)
        {
            if (_selected�ardsIndex.Contains(index))
            {
                _playerHand.CardsPlayerHand[index].IsSelected = false;
                _selected�ardsIndex.Remove(index);
            }
            else if (_selected�ardsIndex.Count < 5)
            {
                _selected�ardsIndex.Add(index);
                _playerHand.CardsPlayerHand[index].IsSelected = true;
            }
            FindCurrentCombination();
        }

        void UpdateCurrentHand()
        {
            var randomCards = _deckRound.TakeRandomCards(_selected�ardsIndex.Count);
            for (var i = 0; i < _selected�ardsIndex.Count; i++)
            {
                _playerHand.CardsPlayerHand[_selected�ardsIndex[i]].IsSelected = false;
                _playerHand.CardsPlayerHand[_selected�ardsIndex[i]].Suit = randomCards[i].Suit;
                _playerHand.CardsPlayerHand[_selected�ardsIndex[i]].CardValue = randomCards[i].CardValue;
                _playerHand.CardsPlayerHand[_selected�ardsIndex[i]].Points = randomCards[i].Points;
                _playerHand.CardsPlayerHand[_selected�ardsIndex[i]].Sprite = randomCards[i].Sprite;
            }
            _selected�ardsIndex.Clear();
            FindCurrentCombination();
        }

        void FindCurrentCombination()
        {
            var selected�ards = new List<SlotCard>();
            foreach (var item in _selected�ardsIndex)
            {
                if (DataHolder.CurrentLevel == 8 && _playerHand.CardsPlayerHand[item].Suit == SuitType.Club)
                    continue;
                selected�ards.Add(_playerHand.CardsPlayerHand[item]);
            }
            var result = FindPokerHand.AnalyzeCombinations.Check(selected�ards);
            (_currentCombination.Name, _currentCombination.Chips, _currentCombination.Factor, _currentCombination.Cards) = (result.Item1, result.Item2, result.Item3, result.Item4);
        }

        int CountPlayerPoints()
        {
            var chips = _currentCombination.Chips;
            double factor = _currentCombination.Factor;
            var points = 0;
            for (var i = 0; i < DataHolder.Buffs.Count(); i++ )
            {
                var buff = DataHolder.Buffs[i];
                var selected�ards = new List<SlotCard>();
                foreach (var item in _selected�ardsIndex)
                    selected�ards.Add(_playerHand.CardsPlayerHand[item]);

                if (buff.Type == BuffType.BeforeCountingBuff)
                {       
                    (var extraChips, var extraFactor) = buff.EnableEffectBuff(selected�ards);
                    (chips, factor) = (chips + extraChips, factor + extraFactor);
                }
                else if (buff.Type == BuffType.AfterCountingBuff)
                {
                    points += buff.EnableEffectBuff(selected�ards).Item1;
                }
            }

            foreach (var item in _currentCombination.Cards)
                chips += item.Points;
            return (int)(chips * factor + points);
        }

        Buff GetBuff(Buffs buffs)
        {
            var random = new System.Random();
            BuffDifficulty difficulty;
            var number = random.Next(0, 100);
            if (number >= 0 && number < DefaultLevels.Levels.FirstOrDefault(level => level.NumberLevel == DataHolder.CurrentLevel).ChanceLightBuff)
            {
                difficulty = BuffDifficulty.Light;
            }
            else if (number >= DefaultLevels.Levels.FirstOrDefault(level => level.NumberLevel == DataHolder.CurrentLevel).ChanceLightBuff && number < DefaultLevels.Levels.FirstOrDefault(level => level.NumberLevel == DataHolder.CurrentLevel).ChanceLightBuff + DefaultLevels.Levels.FirstOrDefault(level => level.NumberLevel == DataHolder.CurrentLevel).ChanceMediumBuff)
            {
                difficulty = BuffDifficulty.Medium;
            }
            else
            {
                difficulty = BuffDifficulty.Great;
            }
            var list = buffs.List.FindAll(b => b.Difficulty == difficulty);
            var index = random.Next(0, list.Count());
            var result = list[index];
            return result;
        }

        List<Buff> GetBuffs()
        {
            var result = new List<Buff>();
            var buffs = new Buffs();
            for (var i = 0; i < 3; i++)
            {
                result.Add(GetBuff(buffs));
            }
            return result;
        }

        public void ClickOnBuff(int index)
        {
            DataHolder.Buffs.Add(_buffs[index]);
            _buffs[index].IsSelect = true;
            if (_buffs[index].Type == BuffType.StaticBuff )
            {
                _buffs[index].EnableEffectBuff();
            }
        }

        public void ClickOnButtonPlayHand()
        {
            if (_selected�ardsIndex.Count == 0)
                return;
            if (_informationPlayer.AmountHands > 0)
            {
                DataHolder.NumberCardsPlayed += _selected�ardsIndex.Count;
                DataHolder.LastCombination = _screenPlayView.InformationPlayerView.CurrentCombinationView.NameCombination;
                _informationPlayer.NumberCardsDeckRound -= _selected�ardsIndex.Count;
                _informationPlayer.AmountHands -= 1;
                _informationPlayer.PointsPlayer += CountPlayerPoints();
                UpdateCurrentHand();
            }
        }

        public void ClickOnButtonReset()
        {
            if (_selected�ardsIndex.Count == 0)
                return;
            if (_informationPlayer.AmountResets > 0)
            {
                DataHolder.NumberResetsUsed += 1;
                _informationPlayer.AmountResets -= 1;
                _informationPlayer.NumberCardsDeckRound -= _selected�ardsIndex.Count;
                UpdateCurrentHand();
            }
        }

        public void ClickOnButtonCardCombo()
        {
            if (_screenCardCombo.activeSelf)
            {
                _screenCardCombo.SetActive(false);
            }
            else
            {
                _screenCardCombo.SetActive(true);
            }
            
        }

        public void ClickOnButtonNext()
        {
            _screenVictoryTournamentView.gameObject.SetActive(false);
            _screenTournamentStatisticsView.gameObject.SetActive(true);
        }

        public void ClickOnButtonSettings()
        {
            _screenSettings.SetActive(true);
        }

        public void ClickOnButtonReturnGame()
        {
            _screenSettings.SetActive(false);
            _screenSettings.transform.Find("Background").gameObject.SetActive(false);
        }

        public void ClickOnButtonSettingsMainMenu()
        {
            _screenSettings.transform.Find("Background").gameObject.SetActive(true);
        }

        public void ClickOnButtonStay()
        {
            _screenSettings.transform.Find("Background").gameObject.SetActive(false);
        }

        public void ClickOnButtonExit(int numberScene)
        {
            SceneManager.LoadScene(numberScene);
        }

        public void ClickOnButtonMainMenu(int numberScene)
        {
            SceneManager.LoadScene(numberScene);
        }

        public void ClickOnButtonPlayAgain(int numberScene)
        {
            DataHolder.CurrentLevel = 1;
            DataHolder.TotalNumberPointsScored = 0;
            DataHolder.MaxAmountHands = 3;
            DataHolder.MaxAmountResets = 3;
            DataHolder.CurrentLevelPoints = DefaultLevels.Levels.FirstOrDefault(level => level.NumberLevel == DataHolder.CurrentLevel).Points;
            DataHolder.Buffs = new List<Buff>();
            SceneManager.LoadScene(numberScene);
        }

        public void ClickOnButtonNext(int numberScene)
        {
            DataHolder.CurrentLevel += 1;
            DataHolder.CurrentLevelPoints = DefaultLevels.Levels.FirstOrDefault(level => level.NumberLevel == DataHolder.CurrentLevel).Points;
            SceneManager.LoadScene(numberScene);
        }
    }
}