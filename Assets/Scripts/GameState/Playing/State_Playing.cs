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
            view.ResetView();

            CardMatchingGameHandler._OnCombo += OnCombo;
            CardMatchingGameHandler._OnGuessWrong += OnMatchHappened;
            CardMatchingGameHandler._OnGuessWrong += OnMatchHappened;
        }

        public void UpdateTime()
        {
            view.UpdateTime(GameInfo.timer);
        }

        public void OnMatches()
        {
            view.UpdateMatches(GameInfo.matchesCount);
        }

        public void OnMatchHappened()
        {
            view.UpdateTurns(GameInfo.turnCount);
        }

        public void OnCombo()
        {
            view.UpdateCombo(GameInfo.comboCount);
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

            UpdateTime();
        }
    }
}