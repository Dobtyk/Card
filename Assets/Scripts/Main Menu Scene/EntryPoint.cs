using Deck;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] ScreenMainMenuView _screenMainMenuView;

    ScreenMainMenuController _screenMainMenuController;

    void Awake()
    {
        Yandexholder.LoadInformation();
    }

    void LoadMainMenu()
    {
        _screenMainMenuController = new ScreenMainMenuController(_screenMainMenuView);
    }





    public void ClickOnButtonPlay(int numberScene)
    {
        DataHolder.InitializeNewGame();
        SceneManager.LoadScene(numberScene);
    }

    public void OpenWindowForButton(GameObject gameObject)
    {
        gameObject.SetActive(true);
    }

    public void CloseWindowForButton(GameObject gameObject)
    {
        gameObject.SetActive(false);
    }

    public void LoadInformation()
    {
        LoadMainMenu();
    }
}