using Deck;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntryPoint : MonoBehaviour
{
    public void ClickOnButtonPlay(int numberScene)
    {
        InitializeNewGame();
        SceneManager.LoadScene(numberScene);
    }

    void InitializeNewGame()
    {
        DataHolder.CurrentLevel = 1;
        DataHolder.PlayerPoints = 0;
        DataHolder.MaxAmountHands = 3;
        DataHolder.MaxAmountResets = 3;
        DataHolder.CurrentLevelPoints = 200;
        DataHolder.MaxLevel = 8;
        DataHolder.Deck.CardsDeck = new DefaultDeck().Deck.Cards;

        DataHolder.NumberResetsUsed = 0;
        DataHolder.NumberCardsPlayed = 0;
        DataHolder.NumberPointsScored = 0;
        DataHolder.LastCombination = "";
    }
}