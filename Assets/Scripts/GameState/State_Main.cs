using UnityEngine;
using UnityEngine.UI;

namespace FlipFlop
{
    public class State_Main : GameStateBase
    {
        [SerializeField] private Text levelNumberText;
        [SerializeField] private Button playButton;

        public void Init()
        {
            levelNumberText.text = $"Level {PlayerProfile.LevelIndex + 1}";

            playButton.onClick.AddListener(StartGame);
        }

        public void StartGame()
        {
            CardMatchingGameHandler.StartGame();
        }

    }
}