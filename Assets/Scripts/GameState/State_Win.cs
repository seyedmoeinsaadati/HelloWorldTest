using System;
using UnityEngine;
using UnityEngine.UI;

namespace FlipFlop
{
    public class State_Win : GameStateBase
    {
        [SerializeField] private Button homeButton;
        [SerializeField] private Text scoreText;

        private string _scoreFormat;

        private void Start()
        {
            homeButton.onClick.AddListener(OnHomeClicked);

            _scoreFormat = scoreText.text;
        }

        private void OnEnable()
        {
            UdpateScore();
        }

        private void UdpateScore()
        {
            scoreText.text = string.Format(_scoreFormat, GameInfo.CalculateScore());
        }

        private void OnHomeClicked()
        {
            CardMatchingGameHandler.BackToMainMenu();
        }
    }
}