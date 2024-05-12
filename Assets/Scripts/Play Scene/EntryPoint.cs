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
        [SerializeField] GameObject _screenDefeat;
        [SerializeField] GameObject _screenVictory;

        DeckRound _deckRound = new DeckRound(new DeckRoundData());
        ScreenPlayController _screenPlayController;
        PlayerHand _playerHand = new PlayerHand(new PlayerHandData());
        CurrentCombination _currentCombination = new CurrentCombination(new CombinationData());
        InformationPlayer _informationPlayer;

        List<int> _selectedÑardsIndex = new();

        void Awake()
        {
            FirstLoadLevel();
        }

        void Start()
        {
            
        }

        private void FirstLoadLevel()
        {
            _deckRound.CardsDeckRound = DataHolder.Deck.CardsDeck.ToList();
            _playerHand.CardsPlayerHand = _deckRound.TakeRandomCards(8);
            _informationPlayer = new InformationPlayer(new InformationPlayerData { AmountHands = DataHolder.MaxAmountHands, AmountResets = DataHolder.MaxAmountResets });
            _screenPlayController = new ScreenPlayController(_screenPlayView, _playerHand, _currentCombination, _informationPlayer);
        }

        private void LoadLevel()
        {
            _deckRound.CardsDeckRound = DataHolder.Deck.CardsDeck.ToList();
            var randomCards = _deckRound.TakeRandomCards(8);
            for (var i = 0; i < 8; i++)
            {
                _playerHand.CardsPlayerHand[i].Suit = randomCards[i].Suit;
                _playerHand.CardsPlayerHand[i].CardValue = randomCards[i].CardValue;
                _playerHand.CardsPlayerHand[i].Points = randomCards[i].Points;
            }
            _informationPlayer.AmountResets = DataHolder.MaxAmountResets;
            _informationPlayer.AmountHands = DataHolder.MaxAmountHands;
        }

        public void ClickOnCard(int index)
        {
            if (_selectedÑardsIndex.Contains(index))
            {
                _playerHand.CardsPlayerHand[index].IsSelected = false;
                _selectedÑardsIndex.Remove(index);
            }
            else if (_selectedÑardsIndex.Count < 5)
            {
                _selectedÑardsIndex.Add(index);
                _playerHand.CardsPlayerHand[index].IsSelected = true;
            }
            FindCurrentCombination();
        }

        public void ClickOnButtonPlayHand()
        {
            if (_selectedÑardsIndex.Count == 0)
                return;
            if (_informationPlayer.AmountHands > 0)
            {
                DataHolder.NumberCardsPlayed += _selectedÑardsIndex.Count;
                DataHolder.LastCombination = _screenPlayView.InformationPlayerView.CurrentCombinationView.NameCombination;
                _informationPlayer.AmountHands -= 1;
                _informationPlayer.PointsPlayer += CountPlayerPoints();
                UpdateCurrentHand();
            }
            if (_informationPlayer.AmountHands == 0 && DataHolder.CurrentLevelPoints > _informationPlayer.PointsPlayer)
            {
                DataHolder.NumberPointsScored = _informationPlayer.PointsPlayer;
                ScreenDefeatController screenDefeatController = new ScreenDefeatController(_screenDefeatView);
                _screenDefeat.SetActive(true);
            }
            if (DataHolder.CurrentLevelPoints <= _informationPlayer.PointsPlayer)
            {
                _screenVictory.SetActive(true);
            }
        }

        public void ClickOnButtonReset()
        {
            if (_selectedÑardsIndex.Count == 0)
                return;
            if (_informationPlayer.AmountResets > 0)
            {
                DataHolder.NumberResetsUsed += 1;
                _informationPlayer.AmountResets -= 1;
                UpdateCurrentHand();
            }
        }

        public void ClickOnLoadScene(int numberScene)
        {
            SceneManager.LoadScene(0);
            SceneManager.LoadScene(numberScene);
        }

        public void ClickOnButtonNext(int numberScene)
        {
            SceneManager.LoadScene(0);
            SceneManager.LoadScene(numberScene);
            DataHolder.CurrentLevel += 1;
        }

        void UpdateCurrentHand()
        {
            var randomCards = _deckRound.TakeRandomCards(_selectedÑardsIndex.Count);
            for (var i = 0; i < _selectedÑardsIndex.Count; i++)
            {
                _playerHand.CardsPlayerHand[_selectedÑardsIndex[i]].IsSelected = false;
                _playerHand.CardsPlayerHand[_selectedÑardsIndex[i]].Suit = randomCards[i].Suit;
                _playerHand.CardsPlayerHand[_selectedÑardsIndex[i]].CardValue = randomCards[i].CardValue;
                _playerHand.CardsPlayerHand[_selectedÑardsIndex[i]].Points = randomCards[i].Points;
            }
            _selectedÑardsIndex.Clear();
            FindCurrentCombination();
        }

        void FindCurrentCombination()
        {
            var selectedÑards = new List<SlotCard>();
            foreach (var item in _selectedÑardsIndex)
                selectedÑards.Add(_playerHand.CardsPlayerHand[item]);
            var result = FindPokerHand.AnalyzeCombinations.Check(selectedÑards);
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
    }
}