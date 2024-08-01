using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace FlipFlop
{
    public class State_Win : GameStateBase
    {
        [SerializeField] private Button homeButton;
        [SerializeField] private Text statText;

        private string _statFormat;

        private void Awake()
        {
            homeButton.onClick.AddListener(OnHomeClicked);
            _statFormat = statText.text;
        }

        private void OnEnable()
        {
            UpdateStats();
        }

        private void OnHomeClicked()
        {
            CardMatchingGameHandler.BackToMainMenu();
        }

        private void UpdateStats()
        {
            int score = GameInfo.CalculateScore();
            statText.text = string.Format(_statFormat, (int)GameInfo.timer, GameInfo.comboCount, score);
        }
    }
}