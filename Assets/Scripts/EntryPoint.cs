using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEditor.Progress;

namespace Deck
{
    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] ScreenPlayView _screenPlayView;

        Deck _deck = new Deck(new DeckData());
        DeckRound _deckRound = new DeckRound(new DeckRoundData());
        ScreenPlayController _screenPlayController;
        PlayerHand _playerHand = new PlayerHand(new PlayerHandData());
        CurrentCombination _currentCombination = new CurrentCombination(new CombinationData());
        InformationPlayer _informationPlayer = new InformationPlayer(new InformationPlayerData { AmountHands = 3, AmountResets = 3});

        List<int> _selected�ardsIndex = new();

        void Start()
        {
            _deck.CardsDeck = new DefaultDeck().Deck.Cards;
            _deckRound.CardsDeckRound = _deck.CardsDeck.ToList();
            _playerHand.CardsPlayerHand = _deckRound.TakeRandomCards(8);
            _screenPlayController = new ScreenPlayController(_screenPlayView, _playerHand, _currentCombination, _informationPlayer);
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
                _informationPlayer.AmountResets -= 1;
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
            (_currentCombination.Name, _currentCombination.Chips, _currentCombination.Factor) = (result.Item1, result.Item2, result.Item3);
        }

        int CountPlayerPoints()
        {
            var chips = _currentCombination.Chips;
            var factor = _currentCombination.Factor;
            foreach (var item in _selected�ardsIndex)          
                chips += _playerHand.CardsPlayerHand[item].Points;
            return chips * factor;
        }
    }
}