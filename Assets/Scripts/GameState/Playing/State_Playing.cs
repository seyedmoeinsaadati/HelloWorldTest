using UnityEngine;

namespace FlipFlop
{
    public class State_Playing : GameStateBase
    {
        [SerializeField] private StatePlaying_View view;

        private void Start()
        {
            view.onHomeClicked += OnBackMenu;
        }

        public void UpdateTime()
        {
            // view.UpdateTime();
        }

        public void OnMatches()
        {
            // view.UpdateMatches();
        }

        public void OnTurnComplete()
        {
            // view.UpdateTurns();
        }

        public void OnCombo()
        {
            // TODO: combo effect
        }

        public void OnBackMenu()
        {
            GameStateManager.Instance.OpenMainMenu();
        }

        private void OnDestroy()
        {
            view.onHomeClicked -= OnBackMenu;
        }

#if UNITY_EDITOR

        // For test in editor (win/lose)
        private void Update()
        {
            if (Input.GetKeyUp(KeyCode.W))
            {
                CardMatchingGameHandler.GameFinished(true);
            }
            else if (Input.GetKeyUp(KeyCode.Q))
            {
                CardMatchingGameHandler.GameFinished(false);
            }
        }
#endif

    }
}