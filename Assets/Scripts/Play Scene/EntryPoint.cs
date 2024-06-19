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
        [SerializeField] ScreenTournamentStatisticsView _screenTournamentStatisticsView;
        [SerializeField] ScreenVictoryView _screenVictoryView;
        [SerializeField] ScreenVictoryTournamentView _screenVictoryTournamentView;
        [SerializeField] GameObject _screenCardCombo;
        [SerializeField] GameObject _screenSettings;

        DeckRound _deckRound = new DeckRound(new DeckRoundData());
        PlayerHand _playerHand = new PlayerHand(new PlayerHandData());
        CurrentCombination _currentCombination = new CurrentCombination(new CombinationData());
        InformationPlayer _informationPlayer;
        List<Effect> _buffs;

        ScreenPlayController _screenPlayController;
        ScreenDefeatController _screenDefeatController;
        ScreenVictoryController _screenVictoryController;
        ScreenTournamentStatisticsController _screenTournamentStatisticsController;
        ScreenVictoryTournamentController _screenVictoryTournamentController;

        List<int> _selectedÑardsIndex = new();

        void Awake()
        {
            LoadLevel();
        }

        void LoadLevel()
        {
            foreach (var item in DataHolder.Deck.CardsDeck)
            {
                _deckRound.CardsDeckRound.Add(new SlotCard(new CardData { Suit = item.Suit, CardValue = item.CardValue, Points = item.Points, Sprite = item.Sprite }));
            }
            _playerHand.CardsPlayerHand = _deckRound.TakeRandomCards(8);
            SortCards();
            _informationPlayer = new InformationPlayer(new InformationPlayerData { AmountHands = DataHolder.MaxAmountHands, AmountResets = DataHolder.MaxAmountResets, NumberCardsDeckRound = 44 });
            _buffs = GetBuffs();

            _screenPlayController = new ScreenPlayController(_screenPlayView, _playerHand, _currentCombination, _informationPlayer);
            _screenDefeatController = new ScreenDefeatController(_screenDefeatView, _informationPlayer);
            _screenTournamentStatisticsController = new ScreenTournamentStatisticsController(_screenTournamentStatisticsView, _informationPlayer);
            _screenVictoryController = new ScreenVictoryController(_screenVictoryView, _informationPlayer, _buffs);
            _screenVictoryTournamentController = new ScreenVictoryTournamentController(_screenVictoryTournamentView, _informationPlayer);
        }

        void SortCards()
        {
            var cards = new List<SlotCard>();
            for (var i = 0; i < _playerHand.CardsPlayerHand.Count; i++)
            {
                cards.Add(new SlotCard(new CardData()));
                cards[i].IsSelected = _playerHand.CardsPlayerHand[i].IsSelected;
                cards[i].Suit = _playerHand.CardsPlayerHand[i].Suit;
                cards[i].CardValue = _playerHand.CardsPlayerHand[i].CardValue;
                cards[i].Points = _playerHand.CardsPlayerHand[i].Points;
                cards[i].Sprite = _playerHand.CardsPlayerHand[i].Sprite;
            }
            cards.Sort();
            for (var i = 0; i < _playerHand.CardsPlayerHand.Count; i++)
            {
                _playerHand.CardsPlayerHand[i].IsSelected = cards[i].IsSelected;
                _playerHand.CardsPlayerHand[i].Suit = cards[i].Suit;
                _playerHand.CardsPlayerHand[i].CardValue = cards[i].CardValue;
                _playerHand.CardsPlayerHand[i].Points = cards[i].Points;
                _playerHand.CardsPlayerHand[i].Sprite = cards[i].Sprite;
            }
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
                _playerHand.CardsPlayerHand[_selectedÑardsIndex[i]].Sprite = randomCards[i].Sprite;
            }
            SortCards();
            _selectedÑardsIndex.Clear();
            FindCurrentCombination();
        }

        void FindCurrentCombination()
        {
            var selectedÑards = new List<SlotCard>();
            foreach (var item in _selectedÑardsIndex)
            {
                selectedÑards.Add(_playerHand.CardsPlayerHand[item]);
            }
            if (DataHolder.Debuff != null)
                selectedÑards = DataHolder.Debuff.EnableEffectDebuff(selectedÑards);
            var result = FindPokerHand.AnalyzeCombinations.Check(selectedÑards);
            (_currentCombination.Name, _currentCombination.Chips, _currentCombination.Factor, _currentCombination.Cards) = (result.Item1, result.Item2, result.Item3, result.Item4);
        }

        int CountPlayerPoints()
        {
            var chips = _currentCombination.Chips;
            double factor = _currentCombination.Factor;
            var points = 0;
            var factorMultiply = 1d;
            for (var i = 0; i < DataHolder.Buffs.Count(); i++)
            {
                var buff = DataHolder.Buffs[i];
                var selectedÑards = new List<SlotCard>();
                foreach (var item in _selectedÑardsIndex)
                    selectedÑards.Add(_playerHand.CardsPlayerHand[item]);

                if (buff.Type == BuffType.BeforeCountingBuff)
                {
                    (var extraChips, var extraFactor, var extraFactorMultiply) = buff.EnableEffectBuff(selectedÑards);
                    factorMultiply *= extraFactorMultiply;
                    (chips, factor) = (chips + extraChips, factor + extraFactor);
                }
                else if (buff.Type == BuffType.AfterCountingBuff)
                {
                    points += buff.EnableEffectBuff(selectedÑards).Item1;
                }
            }

            foreach (var item in _currentCombination.Cards)
                chips += item.Points;
            return (int)(chips * factor * factorMultiply + points);
        }

        Effect GetBuff(Effects buffs)
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
            var list = buffs.Buffs.FindAll(b => b.Difficulty == difficulty);
            var index = random.Next(0, list.Count());
            var result = list[index];
            return result;
        }

        List<Effect> GetBuffs()
        {
            var result = new List<Effect>();
            var buffs = new Effects();
            while (result.Count() < 3)
            {
                result.Add(GetBuff(buffs));
                result = result.Distinct().ToList();
            }
            return result;
        }

        public void ClickOnBuff(int index)
        {
            DataHolder.Buffs.Add(_buffs[index]);
            _buffs[index].IsSelect = true;
            if (_buffs[index].Type == BuffType.StaticBuff)
            {
                _buffs[index].EnableEffectBuff();
            }
            Yandexholder.SaveBuffs(DataHolder.Buffs);
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
                _informationPlayer.NumberCardsDeckRound -= _selectedÑardsIndex.Count;
                _informationPlayer.AmountHands -= 1;

                var playerPoints = CountPlayerPoints();

                DataHolder.TotalNumberPointsScored += playerPoints;
                _informationPlayer.PointsPlayer += playerPoints;

                UpdateCurrentHand();
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
                _informationPlayer.NumberCardsDeckRound -= _selectedÑardsIndex.Count;
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
            DataHolder.InitializeNewGame();
            SceneManager.LoadScene(numberScene);
        }

        public void ClickOnButtonNext(int numberScene)
        {
            DataHolder.CurrentLevel += 1;
            SceneManager.LoadScene(numberScene);
        }

        public void ClickOnButtonBackComboCards(GameObject gameObject)
        {
            gameObject.SetActive(false);
        }
    }
}