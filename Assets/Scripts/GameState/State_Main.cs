using UnityEngine;
using UnityEngine.UI;

namespace FlipFlop
{
    public class State_Main : GameStateBase
    {
        [SerializeField] private Text levelNumberText;
        [SerializeField] private Button playButton;

        private void Start()
        {
            playButton.onClick.AddListener(StartGame);
        }

        public void Init()
        {
            levelNumberText.text = $"Level {PlayerProfile.LevelIndex + 1}";
        }

        public void StartGame()
        {
            CardMatchingGameHandler.StartGame();
        }

    }
}