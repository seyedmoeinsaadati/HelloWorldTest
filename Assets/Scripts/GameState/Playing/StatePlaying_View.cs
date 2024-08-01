using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace FlipFlop
{
    public class StatePlaying_View : MonoBehaviour
    {
        [SerializeField] private Text levelNumberText;
        [SerializeField] private Text timeText;
        [SerializeField] private Text turnsText;
        [SerializeField] private Text matchesText;
        [SerializeField] private Text comboText;
        [SerializeField] private Button homeButton;

        public event Action onHomeClicked;

        private string levelNumberFormat;
        private string timeFormat;
        private string turnsFormat;
        private string matchesFormat;
        private string comboFormat;

        public void Start()
        {
            homeButton.onClick.AddListener(OnClickHome);

            levelNumberFormat = levelNumberText.text;
            timeFormat = timeText.text;
            turnsFormat = turnsText.text;
            matchesFormat = matchesText.text;
            comboFormat = comboText.text;
        }

        private void OnClickHome()
        {
            onHomeClicked?.Invoke();
        }

        public void UpdateLevel(int value)
        {
            levelNumberText.text = string.Format(levelNumberFormat, value);
        }

        public void UpdateTime(float value)
        {
            timeText.text = string.Format(timeFormat, value.ToString("0.0"));
        }

        public void UpdateTurns(int value)
        {
            turnsText.text = string.Format(turnsFormat, value);
        }

        public void UpdateMatches(int value)
        {
            matchesText.text = string.Format(matchesFormat, value);
        }

        public void UpdateCombo(int value)
        {
            comboText.text = string.Format(comboFormat, value);
        }
    }
}