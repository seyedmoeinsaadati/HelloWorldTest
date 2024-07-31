using System;
using UnityEngine;
using UnityEngine.UI;

namespace FlipFlop
{
    public class StatePlaying_View : MonoBehaviour
    {
        [SerializeField] private Text timeText;
        [SerializeField] private Text turnsText;
        [SerializeField] private Text matchesText;
        [SerializeField] private Button homeButton;

        public event Action onHomeClicked;

        public void Start()
        {
            homeButton.onClick.AddListener(OnClickHome);
        }

        private void OnClickHome()
        {
            onHomeClicked?.Invoke();
        }
    }
}