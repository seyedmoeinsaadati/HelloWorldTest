using UnityEngine;
using UnityEngine.UI;

namespace FlipFlop
{
    public class State_Win : GameStateBase
    {
        [SerializeField] private Button homeButton;

        private void Start()
        {
            homeButton.onClick.AddListener(OnHomeClicked);
        }

        private void OnHomeClicked()
        {
            CardMatchingGameHandler.BackToMainMenu();
        }
    }
}