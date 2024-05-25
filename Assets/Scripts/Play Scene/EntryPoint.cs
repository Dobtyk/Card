using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Deck
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] ScreenPlayView _screenPlayView;
        [SerializeField] ScreenDefeatView _screenDefeatView;
        [SerializeField] ScreenVictoryView _screenVictoryView;

        DeckRound _deckRound = new DeckRound(new DeckRoundData());
        PlayerHand _playerHand = new PlayerHand(new PlayerHandData());
        CurrentCombination _currentCombination = new CurrentCombination(new CombinationData());
        InformationPlayer _informationPlayer;

        ScreenPlayController _screenPlayController;
        ScreenDefeatController _screenDefeatController;
        ScreenVictoryController _screenVictoryController;

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
            _informationPlayer = new InformationPlayer(new InformationPlayerData { AmountHands = DataHolder.MaxAmountHands, AmountResets = DataHolder.MaxAmountResets });

            _screenPlayController = new ScreenPlayController(_screenPlayView, _playerHand, _currentCombination, _informationPlayer);
            _screenDefeatController = new ScreenDefeatController(_screenDefeatView, _informationPlayer);
            _screenVictoryController = new ScreenVictoryController(_screenVictoryView, _informationPlayer);
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

        public void ClickOnButtonPlayHand()
        {
            if (_selected�ardsIndex.Count == 0)
                return;
            if (_informationPlayer.AmountHands > 0)
            {
                DataHolder.NumberCardsPlayed += _selected�ardsIndex.Count;
                DataHolder.LastCombination = _screenPlayView.InformationPlayerView.CurrentCombinationView.NameCombination;
                _informationPlayer.AmountHands -= 1;
                _informationPlayer.PointsPlayer += CountPlayerPoints();
                UpdateCurrentHand();
            }
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
                selected�ards.Add(_playerHand.CardsPlayerHand[item]);
            var result = FindPokerHand.AnalyzeCombinations.Check(selected�ards);
            (_currentCombination.Name, _currentCombination.Chips, _currentCombination.Factor, _currentCombination.Cards) = (result.Item1, result.Item2, result.Item3, result.Item4);
        }

        int CountPlayerPoints()
        {
            var chips = _currentCombination.Chips;
            var factor = _currentCombination.Factor;
            foreach (var item in _currentCombination.Cards)
                chips += item.Points;
            return chips * factor;
        }

        public void ClickOnButtonReset()
        {
            if (_selected�ardsIndex.Count == 0)
                return;
            if (_informationPlayer.AmountResets > 0)
            {
                DataHolder.NumberResetsUsed += 1;
                _informationPlayer.AmountResets -= 1;
                UpdateCurrentHand();
            }
        }

        public void ClickOnButtonMainMenu(int numberScene)
        {
            SceneManager.LoadScene(numberScene);
        }

        public void ClickOnButtonPlayAgain(int numberScene)
        {
            DataHolder.CurrentLevel = 1;
            DataHolder.TotalNumberPointsScored = 0;
            DataHolder.CurrentLevelPoints = DefaultLevels.Levels.FirstOrDefault(level => level.NumberLevel == DataHolder.CurrentLevel).Points;
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