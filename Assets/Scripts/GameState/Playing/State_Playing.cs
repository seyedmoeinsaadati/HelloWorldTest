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

        public override void Init()
        {
            // TODO: start game
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
            GameStateManager.Instance.SetupMainMenu();
        }

        private void OnDestroy()
        {
            view.onHomeClicked -= OnBackMenu;
        }

    }
}