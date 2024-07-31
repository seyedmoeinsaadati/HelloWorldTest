using UnityEngine;

namespace FlipFlop
{

    public class State_Playing : GameStateBase
    {
        [SerializeField] private StatePlaying_View view;

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

    }
}