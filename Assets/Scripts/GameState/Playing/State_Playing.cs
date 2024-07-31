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

        public void ResetPanel()
        {
            // view.Reset();
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
            CardMatchingGameHandler.BackToMainMenu();
        }


        private void OnDestroy()
        {
            view.onHomeClicked -= OnBackMenu;
        }


        private void Update()
        {

            CheckTime();

#if UNITY_EDITOR
            // For test in editor (win/lose)
            if (Input.GetKeyUp(KeyCode.W))
            {
                CardMatchingGameHandler.Win();
            }
            else if (Input.GetKeyUp(KeyCode.Q))
            {
                CardMatchingGameHandler.Lose();
            }
#endif
        }

        private void CheckTime()
        {
            GameInfo.timer -= Time.deltaTime;

            if (GameInfo.timer <= 0)
            {
                CardMatchingGameHandler.Lose();
            }
        }
    }
}