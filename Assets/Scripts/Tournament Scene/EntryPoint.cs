using Deck;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Tournament
{

    public class EntryPoint : MonoBehaviour
    {
        [SerializeField] ScreenTournamentView _screenTournamentView;

        ScreenTournamentController _screenTournamentController;

        void Awake()
        {
            _screenTournamentController = new ScreenTournamentController(_screenTournamentView);
        }

        public void ClickOnButtonMainMenu(int numberScene)
        {
            SceneManager.LoadScene(numberScene);
        }

        public void ClickOnButtonFight(int numberScene)
        {
            SceneManager.LoadScene(numberScene);
        }
    }
}