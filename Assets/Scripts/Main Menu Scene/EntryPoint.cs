using Deck;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntryPoint : MonoBehaviour
{
    public void ClickOnButtonPlay(int numberScene)
    {
        DataHolder.InitializeNewGame();
        SceneManager.LoadScene(numberScene);
    }

    public void ClickOnDiscoveries(GameObject gameObject)
    {
        gameObject.SetActive(true);
    }

    public void ClickOnBack(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }
}