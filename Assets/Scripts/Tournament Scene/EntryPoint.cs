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
        [SerializeField] List<TMP_Text> texts;
        [SerializeField] GameObject indicator;
        [SerializeField] TMP_Text debuff;
        [SerializeField] TMP_Text victory;
        [SerializeField] TMP_Text points;
        [SerializeField] TMP_Text description;

        void Awake()
        {
            for (var i = 0; i < DataHolder.CurrentLevel - 1; i++)
            {
                texts[i].text = "Побеждён!";
            }

            var x = indicator.transform.localPosition.x;
            var y = indicator.transform.localPosition.y;
            var z = indicator.transform.localPosition.z;
            indicator.transform.localPosition = new Vector3 { x = x, y = y + 60 * (DataHolder.CurrentLevel - 1), z = z };

            debuff.text = "Бой " + DataHolder.CurrentLevel;
            victory.text = "Побед: " + (DataHolder.CurrentLevel - 1);
            points.text = "Миниум очков: " + DefaultLevels.Levels.FirstOrDefault(level => level.NumberLevel == DataHolder.CurrentLevel).Points;
            if (DataHolder.CurrentLevel == 8)
            {
                description.text = "Дебафф: Карты масти трефы не учитываются при подсчёте";
            }

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